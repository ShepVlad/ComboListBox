namespace RegionCity.DataLayer.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Region")]
    public partial class Region
    {
        public Region()
        {
            Cities = new HashSet<City>();
        }

        public int RegionId { get; set; }

        [Required]
        [StringLength(32)]
        public string RegionName { get; set; }

        public int UserCreateId { get; set; }

        public DateTime DateCreate { get; set; }

        public int UserModifyId { get; set; }

        public DateTime DateModify { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
