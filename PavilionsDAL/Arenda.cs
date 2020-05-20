namespace PavilionsDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Arenda")]
    public partial class Arenda
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ArendaID { get; set; }

        public int? ArendatorID { get; set; }

        public int? SCID { get; set; }

        [StringLength(255)]
        public string PavilionNum { get; set; }

        public int? PlanctonID { get; set; }

        public DateTime? ArendaStart { get; set; }

        public DateTime? ArendaEnd { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        public virtual Arendator Arendator { get; set; }

        public virtual EnablePavilion EnablePavilion { get; set; }

        public virtual Plancton Plancton { get; set; }
    }
}
