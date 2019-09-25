using PruebaNetFramework.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PruebaNetFramework.Data
{
    public class CatalogosDbContext : DbContext
    {
        public CatalogosDbContext() :
         base("BDCatalogos")
        {
        }

        public static CatalogosDbContext Create()
        {
            return new CatalogosDbContext();
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<SubCategoria> SubCategoria { get; set; }

    }
}