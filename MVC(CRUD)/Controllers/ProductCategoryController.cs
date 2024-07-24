using Microsoft.AspNetCore.Mvc;
using MVC_CRUD_.Models;
using System.Data;
using System.Data.SqlClient;

namespace MVC_CRUD_.Controllers
{
    public class ProductCategoryController : Controller
    {
        string _connectionstring = null;
        IConfiguration _configuration;

        public ProductCategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration["ConnectionStrings:MVCDB"];
        }
        public IActionResult Index()
        {
            #region Connection Oriented Architeture
            //SqlConnection con = new SqlConnection(_connectionstring);
            //string query = "Select * From Category; Select * From Product";
            //SqlCommand cmd= new SqlCommand(query, con);
            //con.Open();
            //SqlDataReader reader = cmd.ExecuteReader();
            //List<CategoryModel> list = new List<CategoryModel>();
            //List<ProductViewModel> products = new List<ProductViewModel>();

            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        CategoryModel model = new CategoryModel()
            //        {
            //            CategoryId = (int)reader["CatergoryId"],
            //            Name = reader["Name"].ToString(),
            //            Description = reader["Description"].ToString()
            //        };
            //        list.Add(model);
            //    }
            //    reader.NextResult(); 

            //    while (reader.Read())
            //    {
            //        ProductViewModel p = new ProductViewModel();
            //        p.ProductID = (int)reader["ProductId"];
            //        p.Name = reader["Name"].ToString();
            //        p.UnitPrice = (int)reader["UnitPrice"];

            //        products.Add(p);
            //    }
            //}
            //con.Close();
            //ProductCategoryModel catpro = new ProductCategoryModel()
            //{
            //    Categories = list,
            //    Products= products
            //};
            //return View(catpro);
            #endregion

            ProductCategoryModel catpro = new ProductCategoryModel();

            SqlConnection con = new SqlConnection(_connectionstring);
            String query = "Select * From Category; Select * From Product";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            if(ds != null && ds.Tables !=null && ds.Tables.Count > 0)
            {
                catpro.Categories = new List<CategoryModel>();
                for (int i=0; i < ds.Tables[0].Rows.Count;i++)
                {
                    
                    DataRow row = ds.Tables[0].Rows[i];
                    catpro.Categories.Add(
                        new CategoryModel()
                        {
                            Name = row["Name"].ToString(),
                            Description = row["Description"].ToString()
                        }
                        );
                }

                catpro.Products = new List<ProductViewModel>();

                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[1].Rows[i];
                    catpro.Products.Add(
                        new ProductViewModel()
                        {
                            Name = row["Name"].ToString(),
                            UnitPrice=(int) row["UnitPrice"]
                        }
                        );
                }
            }

            return View(catpro);
        }
    }
}
