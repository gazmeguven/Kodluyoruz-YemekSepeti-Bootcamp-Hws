using FilmLibrary.Data.Repositories.Derived;
using FilmLibrary.Data.Repositories.Interface;
using FilmLibrary.Services.Interfaces;
using FilmLibrary.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmLibrary.Extensions
{
	public static class ServicesConfigurationExtensions
	{
		public static void AddProjectRepositories(this IServiceCollection services)
		{
			services.AddScoped<IDirectorRepository, DirectorRepository>();
			services.AddScoped<IMovieRepository, MovieRepository>();
		}

		public static void AddProjectServices(this IServiceCollection services)
		{
			services.AddTransient<IDirectorService, DirectorService>();
			services.AddTransient<IMovieService, MovieService>();
		}
	}
}
