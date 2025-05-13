using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Modelo.Domain.Entidades;
using static System.Net.Mime.MediaTypeNames;

namespace Modelo.Infra.Data
{

    namespace Desafio_BackEnd_WL_Consultings.Data
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }

            // Adicione DbSets para suas entidades
            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<Transferencias> Transferencias { get; set; }
        }
    }
}
