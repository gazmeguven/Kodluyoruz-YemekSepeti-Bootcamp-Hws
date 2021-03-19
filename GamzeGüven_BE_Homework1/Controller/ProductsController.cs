using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstHomework.Model;
using FirstHomework.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;

namespace FirstHomework.Controller
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductsController : ControllerBase
	{
        //private readonly List<ProductModel> _data = new List<ProductModel>();
        //private readonly DummyDataOld _dummyDataOld;
		
        private readonly IDatabase _database;

		public ProductsController(Database database)
		{
            _database = database;
		}

        [HttpGet]
        public List<ProductModel> Get()
        {
            return _database.Products.ToList();
        }

        [HttpGet("{id}")]
        public ProductModel Get(int id)
        {
            var data = _database.Products.FirstOrDefault(c => c.Id == id);
            return data;
        }

        [HttpPost]
        public void Post([FromBody] ProductModel product)
        {
            _database.Products.Add(product);
        }

        [HttpPut]
        public void Put(int id, [FromBody] ProductModel product)
		{
            _database.Products[id] = product;
		}

        [HttpDelete]
        public void Delete(int id)
		{
            _database.Products.RemoveAt(id);
		}

        [HttpOptions]
        public HttpResponseMessage Options()
		{
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow-Method", "GET,DELETE");

            return response;
		}
    }
}
