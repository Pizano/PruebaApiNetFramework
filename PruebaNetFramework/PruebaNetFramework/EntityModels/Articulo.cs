﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PruebaNetFramework.EntityModels
{
    [Table("Articulo")]
    public class Articulo
    {
        [Key]
        public int Sku_ID { get; set; }
        public string Sku_Codigo { get; set; }
        public string Sku_NumeroSerie { get; set; }
        public string Sku_Descripcion { get; set; }
        public string Sku_Cantidad { get; set; }

        public int Sku_Cat_ID { get; set; }

        public int Sku_Sub_Cat_ID { get; set; }
        public string Sku_Latitud { get; set; }
        public string Sku_Longitud { get; set; }
    }
}