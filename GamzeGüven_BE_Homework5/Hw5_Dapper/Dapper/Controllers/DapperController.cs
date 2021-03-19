using Hw5_Dapper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Dapper.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class DapperController : ControllerBase
	{
		private readonly IConfiguration _configuration;

		public DapperController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public IActionResult DapperSelectInQuery()
		{
			IEnumerable<CountryRegion> countryRegions;
			using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				if (db.State != ConnectionState.Open)
					db.Open();

				string sql = "SELECT * FROM [Person].[CountryRegion]";

				countryRegions = db.Query<CountryRegion>(sql);

			}
			return Ok(countryRegions);
		}

		public IActionResult DapperInsert()
		{
			using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				if (db.State != ConnectionState.Open)
				{
					db.Open();

					string sql = @"INSERT INTO Person.StateProvince(StateProvinceID, StateProvinceCode, Name) 
								Values(@StateProvinceID, @StateProvinceCode, @Name);";

					var affected = db.Execute(sql, new
					{
						StateProvinceID = 182,
						StateProvinceCode = "IZ",
						Name = "Izmir"
					});
				}
			}
			return Ok();
		}

		public IActionResult DapperUpdate()
		{
			using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				if (db.State != ConnectionState.Open)
				{
					db.Open();

					string sql = "UPDATE Person.StateProvince SET Name = @NewName Where StateProvinceID = @NewStateProvinceID";
					var updateProvinces = new[]
					{
						new {NewStateProvinceID = 5, NewName = "Ankara"},
						new {NewStateProvinceID = 6, NewName = "Istanbul"}
					};

					var affected = db.Execute(sql, updateProvinces);
				}
			}
			return Ok();
		}

		public IActionResult DapperDelete()
		{
			using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				if (db.State != ConnectionState.Open)
				{
					db.Open();

					string sql = "DELETE FROM Person.StateProvince WHERE StateProvinceID = @StateProvinceID";
					var affected = db.Execute(sql,
						new { StateProvinceID = 54 }
						);
				}
			}
			return Ok();
		}

		public IActionResult DapperDeleteInQuery()
		{
			using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				if (db.State != ConnectionState.Open)
				{
					db.Open();

					string sql = "DELETE FROM Person.StateProvince WHERE StateProvinceID = @StateProvinceID";
					var affected = db.Query(sql,
						new { StateProvinceID = 32 }
						);
				}
			}
			return Ok();
		}

		public IActionResult DapperTransactionalInsert()
		{
			using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				if (db.State != ConnectionState.Open)
					db.Open();

				using (var transaction = db.BeginTransaction())
				{
					string sql = @"INSERT INTO Person.StateProvince(StateProvinceCode, Name)
								Values(@StateProvinceCode, @Name);";

					StateProvince stateProvince = new StateProvince { StateProvinceCode = "96", Name = "Pisa" };
					db.Execute(sql, stateProvince, transaction);


					CountryRegion countryRegion = new CountryRegion { Name = "Country Name", ModifiedDate = DateTime.Now};
					sql = @"INSERT INTO [Person].[CountryRegion] (Name, ModifiedDate)
							Values(@Name, @ModifiedDate);";
					db.Execute(sql, countryRegion, transaction);

					transaction.Commit();
				}
			}
			return Ok();
		}

		public IActionResult DapperResultMapping()
		{
			using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				if (db.State != ConnectionState.Open)
					db.Open();

				string sql = "SELECT SalesTaxRateId, StateProvinceId, TaxRate FROM [Sales].[SalesTaxRate]";
				IEnumerable<SalesTaxRate> salesTaxRates = db.Query<SalesTaxRate>(sql);
			}
			return Ok();
		}

		public IActionResult DapperOneToOneMapping()
		{
			using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				if (db.State != ConnectionState.Open)
					db.Open();

				string sql = "SELECT * FROM [Sales].[SalesTaxRate] as STax Inner Join [Person].[StateProvince] as SProv ON STax.SalesTaxRateID = SProv.StateProvinceID";

				var data = db.Query<SalesTaxRate, StateProvince, SalesTaxRate>(sql,
					(taxRate, province) =>
					{
						taxRate.StateProvince = province;
						return taxRate;
					},
					splitOn: "SalesTaxRatesID").Distinct().ToList();
				
				return Ok();
			}
		}

		public IActionResult DapperMultipleQueryMapping()
		{
			using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				if (db.State != ConnectionState.Open)
					db.Open();

				string sql = "SELECT * FROM [Sales].[SalesTaxRate] WHERE SalesTaxRateId = @SalesTaxRateID; " +
							"SELECT * FROM [Person].[StateProvince] WHERE StateProvinceId = @StateProvinceID";
				
				StateProvince stateProvince;

				using (var multipleQuery = db.QueryMultiple(sql, new { SalesTaxRateID = 32 }))
				{
					stateProvince = multipleQuery.Read<StateProvince>().First();
					stateProvince.stateNames = multipleQuery.Read<SalesTaxRate>().ToList();
				}
			}
			return Ok();
		}

	}
}
