namespace PavilionsDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Plancton")]
    public partial class Plancton
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plancton()
        {
            Arendas = new HashSet<Arenda>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlanctonID { get; set; }

        [StringLength(255)]
        public string SecontName { get; set; }

        [StringLength(255)]
        public string FirstName { get; set; }

        [StringLength(255)]
        public string LastName { get; set; }

        [StringLength(255)]
        public string Login { get; set; }

        [StringLength(255)]
        public string Password { get; set; }

        [StringLength(255)]
        public string Role { get; set; }

        [StringLength(255)]
        public string Gender { get; set; }

        public byte[] Photo { get; set; }

        [StringLength(255)]
        public string PnoneNum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Arenda> Arendas { get; set; }
    }
}
