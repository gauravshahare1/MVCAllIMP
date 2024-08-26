using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCode.Models
{
    [Table ("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        private string _country;
        [Column]
        public string Country 
        {
            get { return _country; }
            set 
            { 
                if(value == "INDIA") 
                {
                    _country = value;
                }
            }
        }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }


    }
}
