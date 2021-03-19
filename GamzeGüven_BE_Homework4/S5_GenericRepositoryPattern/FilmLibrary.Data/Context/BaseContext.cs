using FilmLibrary.Data.EntityConfiguration;
using FilmLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmLibrary.Data.Context
{
	public class BaseContext : DbContext
	{
		public BaseContext()
		{

		}

		public BaseContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Movie> Movies { get; set; }
		public DbSet<Director> Directors { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				IConfigurationRoot configuration = new ConfigurationBuilder()
					.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
					.AddJsonFile("appsettings.json")
					.Build();


				var connectionString = configuration.GetConnectionString("MsSqlDB");
				optionsBuilder.UseSqlServer(connectionString);
			}

			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new DirectorConfiguration());
			modelBuilder.ApplyConfiguration(new MovieConfiguration());
		}
	}
}
