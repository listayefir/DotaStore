namespace DotaStore.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Badge
    {
        [Key]
        public Guid BadgeID { get; set; }

        public virtual Item Items { get; set; }
    }
}
