namespace PavilionsDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SC")]
    public partial class SC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SC()
        {
            EnablePavilions = new HashSet<EnablePavilion>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SCID { get; set; }

        [StringLength(255)]
        public string SCName { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        public int? PavilNum { get; set; }

        [StringLength(255)]
        public string City { get; set; }

        public double? Price { get; set; }

        public double? CoeffOfAddedValue { get; set; }

        public int? FlorNum { get; set; }

        public byte[] Photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnablePavilion> EnablePavilions { get; set; }
    }
}
