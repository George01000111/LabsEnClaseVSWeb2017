using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebMvc.Models;

namespace WebMvc.Data
{
    public class MovieDbContext: DbContext
    {
        //la cadena de conexion se llamara MovieConnection
        public MovieDbContext():base("MovieConnection")
        {

        }

        public virtual DbSet<Movie> Movies { get; set; }
    }
}