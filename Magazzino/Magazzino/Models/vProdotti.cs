namespace Magazzino.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vProdotti")]
    public partial class vProdotti
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string Codice { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(200)]
        public string Descrizione { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Quantita { get; set; }

        [Column(TypeName = "money")]
        public decimal? Prezzo { get; set; }

        [StringLength(92)]
        public string Dimensione { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(2)]
        public string Attivo { get; set; }

        [StringLength(30)]
        public string DataProduzione { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string DescCategoriaProdotti { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string DescProduttori { get; set; }

        public int? IdCategoriaProdotti { get; set; }

        public int? IdProduttori { get; set; }
    }
}
