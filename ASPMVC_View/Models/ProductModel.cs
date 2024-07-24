using System.ComponentModel;

namespace ASPMVC_View.Models
{
    public class ProductModel
    {
        [DisplayName("Name of Product")]
        public string Name {  get; set; }
        public int Price { get; set; }
        [DisplayName("Category Name for New Collection")]
        public string CategoryName { get; set; }
    }
}
