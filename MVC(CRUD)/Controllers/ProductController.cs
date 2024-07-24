using Microsoft.AspNetCore.Mvc;
using MVC_CRUD_.Models;
using System.Data;
using System.Data.SqlClient;

namespace MVC_CRUD_.Controllers
{
    public class ProductController : Controller
    {
        IConfiguration _config;
        string connectionStrings = null;
        public ProductController(IConfiguration config)
        {
            _config = config;
            connectionStrings = _config["ConnectionStrings:MVCDB"];
        }
        //List of product from DB
        public IActionResult Index()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            //string Cs = "Server=.\\sqlexpress;database=MVCDB;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionStrings);
            connection.Open();
            SqlCommand command = new SqlCommand($"Select * from Product",connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while(reader.Read())
                {
                    ProductViewModel p = new ProductViewModel();
                    p.ProductID = (int)reader["ProductId"];
                    p.Name = reader["Name"].ToString();
                    p.UnitPrice = (int)reader["UnitPrice"];

                    products.Add(p);
                }
            }
            connection.Close();
            return View(products);
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Edit( int id)
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // to provide from the create a new category
        public IActionResult Create(ProductViewModel product)
        {
            #region inline Query
            //List<ProductViewModel> list = new List<ProductViewModel>();
            //string cs = "server=.\\sqlexpress;database=MVCDB;integrated security=true;";
            //SqlConnection con = new SqlConnection(cs);
            ////string query = $"insert into Category Values ('{category.Name}','{category.Description}')";
            //SqlCommand cmd = new SqlCommand($"insert into Product Values ('{product.Name}','{product.UnitPrice}')", con);
            //con.Open();
            //int record = cmd.ExecuteNonQuery();
            //if (record > 0)
            //{
            //    return RedirectToAction("Index");
            //}
            //con.Close();

            //return View();
            #endregion
            List<ProductViewModel> list = new List<ProductViewModel>();
            //string cs = "server=.\\sqlexpress;database=MVCDB;integrated security=true;";
            SqlConnection con = new SqlConnection(connectionStrings);
            string cmdText = "usp_InsertProduct";
            SqlCommand cmd = new SqlCommand(cmdText, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@price", product.UnitPrice);

            SqlParameter status = new SqlParameter()
            {
                ParameterName = "@status",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Output,
            };
            cmd.Parameters.Add(status);
            con.Open();
            int record = cmd.ExecuteNonQuery();
            if ((bool)status.Value)
            {
                return RedirectToAction("Index");
            }
            con.Close();

            return View();
        }

        //public IActionResult Create(ProductViewModel product)
        //{
        //    List<ProductViewModel> list = new List<ProductViewModel>();
        //    string cs = "server=.\\sqlexpress;database=MVCDB;integrated security=true;";
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        string cmdText = "usp_InsertProduct";
        //        using (SqlCommand cmd = new SqlCommand(cmdText, con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@name", product.Name);
        //            cmd.Parameters.AddWithValue("@price", product.UnitPrice);

        //            SqlParameter status = new SqlParameter
        //            {
        //                ParameterName = "@status",
        //                SqlDbType = SqlDbType.Bit,
        //                Direction = ParameterDirection.Output
        //            };
        //            cmd.Parameters.Add(status);

        //            con.Open();
        //            int record = cmd.ExecuteNonQuery();
        //            con.Close();

        //            if (status.Value != DBNull.Value && (bool)status.Value)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //        }
        //    }

        //    return View();
        //}
    }
}
