namespace Magazzino.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoriaProdotti")]
    public partial class CategoriaProdotti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CategoriaProdotti()
        {
            Prodotti = new HashSet<Prodotti>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Codice { get; set; }

        [Required]
        [StringLength(50)]
        public string Descrizione { get; set; }

        public bool Attivo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prodotti> Prodotti { get; set; }
    }
}
