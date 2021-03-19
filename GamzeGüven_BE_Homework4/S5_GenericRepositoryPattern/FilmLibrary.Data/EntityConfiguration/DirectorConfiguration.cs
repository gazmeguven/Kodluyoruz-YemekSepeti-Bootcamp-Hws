using FilmLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmLibrary.Data.EntityConfiguration
{
	public class DirectorConfiguration : IEntityTypeConfiguration<Director>
	{
		public void Configure(EntityTypeBuilder<Director> builder)
		{
			builder.ToTable("Director");
			builder.HasKey(p => p.Id);
		}
	}
}
