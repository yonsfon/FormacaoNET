
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
    
public partial class Filiacao
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Filiacao()
    {

        this.LaureadoIndividuo = new HashSet<LaureadoIndividuo>();

    }


    public int FiliacaoId { get; set; }

    public string Nome { get; set; }

    public int CidadeId { get; set; }



    public virtual Cidade Cidade { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<LaureadoIndividuo> LaureadoIndividuo { get; set; }

}

}
