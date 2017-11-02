using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NobelApi.Controllers
{
    public partial class PremioNobelDetailsDTO
    {
        public int PremioNobelId { get; set; }
        public int Ano { get; set; }
        public string Titulo { get; set; }
        public string Motivacao { get; set; }

        public virtual CategoriaDTO Categoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LaureadoIndividuoDTO> Individuo { get; set; }
        public virtual ICollection<LaureadoOrganizacaoDTO> Organizacao { get; set; }
    }
}