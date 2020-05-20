namespace PavilionsDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EnablePavilion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EnablePavilion()
        {
            Arendas = new HashSet<Arenda>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SCID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string PavilionNum { get; set; }

        public double? Floor { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        public double? Square { get; set; }

        public double? PriceForMeter { get; set; }

        public double? CoeffOfAddedValue { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Arenda> Arendas { get; set; }

        public virtual SC SC { get; set; }
    }
}
