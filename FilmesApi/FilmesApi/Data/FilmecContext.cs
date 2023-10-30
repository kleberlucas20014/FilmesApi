using System;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContexOptions<FilmeContext> opts)
            : base(opts) 
        { 
        
        }
        public DbSet<Filme> Filmes { get; set; }
    }

}