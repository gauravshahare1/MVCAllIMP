using System.Data.SqlClient;
using Task1.Models;

namespace Task1.Data
{
    public class CategoryDB
    {
        IConfiguration _configuration;
        string connectionString = null;

        public CategoryDB(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration["ConnectionStrings:B02CRUDDB"];
        }

        public List<CategoryModel> Categories()
        {
            List<CategoryModel> categories = new List<CategoryModel>();

            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from Category";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    CategoryModel category = new CategoryModel()
                    {
                        CategoryID = (int)reader["CategoryID"],
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString(),
                    };
                    categories.Add(category);
                }
            }
            con.Close();
            return categories;

        }

        public List<ProductModel> ProductByCategory(int? id) 
        { 
            List<ProductModel> products = new List<ProductModel>();
            SqlConnection con = new SqlConnection(connectionString);

            string query = $"Select * From Product Where CategoryId={id}";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    ProductModel product = new ProductModel()
                    {
                        ProductId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        UnitPrice = reader.GetInt32(2),
                        CategoryId = reader.GetInt32(3),
                    };
                    products.Add(product);
                }
            }
            con.Close();
            return products;
        }



    }
}
