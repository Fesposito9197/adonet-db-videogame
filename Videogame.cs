using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlClient
{
    public  record Videogame
    {
        public Videogame(long id, string name, DateTime releaseDate)
        {
            Id = id;
            Name = name;
            ReleaseDate = releaseDate;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
