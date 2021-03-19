using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S8_Hotels.API.Entites
{
	public class RoomEntity
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
        public bool IsMigrate { get; set; }
    }
}
