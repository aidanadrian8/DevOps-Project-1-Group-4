using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace devops_project.Models
{
    public class Part
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Vendor")]
        public int VendorId { get; set; }

        [Required]
        [ForeignKey("Plant")]
        public int PlantId { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8)]
        public string SKU { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Name { get; set;  }

        [Required]
        [StringLength(255)]
        public string Specs { get; set;  }

        [Required]
        [RegularExpression("^(\\$)?(([1-9]\\d{0,2}(\\,\\d{3})*)|([1-9]\\d*)|(0))(\\.\\d{2})?$")]
        public decimal? SalePrice { get; set;  }

        [Required]
        [RegularExpression("^(\\$)?(([1-9]\\d{0,2}(\\,\\d{3})*)|([1-9]\\d*)|(0))(\\.\\d{2})?$")]
        public decimal? ManufacturingPrice { get; set;  }

        [NotMapped]
        public Image? Image { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        [NotMapped]
        public Vendor Vendor { get; set; }

        [Required]
        [NotMapped]
        public Plant Plant { get; set; }

        public Part(int vendorId, int plantId, string sku, string name, string specs, decimal salePrice, decimal manufacturingPrice, string imagePath)
        {
            VendorId = vendorId;
            PlantId = plantId;
            SKU = sku;
            Name = name;
            Specs = specs;
            SalePrice = salePrice;
            ManufacturingPrice = manufacturingPrice;
            ImagePath = imagePath;
        }
    }
}
