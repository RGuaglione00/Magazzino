namespace Magazzino.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;

    [Table("Prodotti")]
    public partial class Prodotti : DbContext
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Codice { get; set; }

        [Required]
        [StringLength(200)]
        public string Descrizione { get; set; }

        public int Quantita { get; set; }

        [Column(TypeName = "money")]
        public decimal? Prezzo { get; set; }

        public int? Profondita { get; set; }

        public int? Larghezza { get; set; }

        public int? Altezza { get; set; }

        public bool Attivo { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataProduzione { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataCessazione { get; set; }

        public int? IdCategoriaProdotti { get; set; }

        public int? IdProduttori { get; set; }

        public virtual CategoriaProdotti CategoriaProdotti { get; set; }

        public virtual Produttori Produttori { get; set; }
    }
}
