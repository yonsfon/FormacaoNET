
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace NobelMVC.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Laureado
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Laureado()
    {

        this.PremioNobel = new HashSet<PremioNobel>();

    }


    public int LaureadoId { get; set; }

    public string LaureadoTipo { get; set; }



    public virtual LaureadoIndividuo LaureadoIndividuo { get; set; }

    public virtual LaureadoOrganizacao LaureadoOrganizacao { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<PremioNobel> PremioNobel { get; set; }

}

}