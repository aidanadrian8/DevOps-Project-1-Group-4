using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace devops_project.Models
{
    public class Plant
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Location { get; set; }

        [MaxLength(50)]
        public ICollection<Part> Parts { get; set; }

        public Plant(string name, string location)
        {
            Name = name;
            Location = location;
            Parts = new List<Part>();
        }

        public List<string> GetPartNames()
        {
            return Parts.Select(x => x.Name).ToList();
        }

        public List<string> GetPartNames(List<string> skus)
        {
            List<string> partNames = new List<string>();

            foreach(string sku in skus)
            {
                string name = Parts.Where(x => x.SKU == sku).Select(x => x.Name).FirstOrDefault();

                if(name != null)
                    partNames.Add(name);
            }

            return partNames;
        }
    }
}
