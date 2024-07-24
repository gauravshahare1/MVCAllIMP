using System.ComponentModel;

namespace MVC_CRUD_.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Price { get; set; }

        [DisplayName("Category")]
        public string CategoryName { get; set; }

    }
}
