using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NobelMVC.Models
{
    [MetadataType(typeof(PremioNobelMetada))]
    public partial class PremioNobel { }

    [MetadataType(typeof(CategoriaMetada))]
    public partial class Categoria { }
}