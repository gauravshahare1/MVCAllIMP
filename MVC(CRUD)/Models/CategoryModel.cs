using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD_.Models
{
    public class CategoryModel
    {
        [DisplayName("Category id")]
        public int? CategoryId{ get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
