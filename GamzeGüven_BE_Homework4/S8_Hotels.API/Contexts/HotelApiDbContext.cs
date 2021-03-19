using Microsoft.EntityFrameworkCore;
using S8_Hotels.API.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S8_Hotels.API.Contexts
{
	public class HotelApiDbContext : DbContext
	{
            public HotelApiDbContext(DbContextOptions options) : base(options)
            {

            }

            public DbSet<RoomEntity> Rooms { get; set; }
            public DbSet<UserEntity> Users { get; set; }
    }
}
