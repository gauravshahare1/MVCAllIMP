using Microsoft.AspNetCore.Mvc;
using MVC_CRUD_.Models;
using System.Data.SqlClient;

namespace MVC_CRUD_.Controllers
{
    public class CategoryController : Controller
    {
        // to show list of Cateogries
        public IActionResult Index()
        {
            List<CategoryModel> list = new List<CategoryModel>();
            //List<CategoryModel> list = new List<CategoryModel>()
            //{
            //    new CategoryModel() { CategoryId=1, Name="Shirt", Description="Casule Shirt"},
            //    new CategoryModel() { CategoryId=2, Name="Shoes", Description="Sport"}

            //};
            //return View(list);

            string cs = "server=.\\sqlexpress;database=MVCDB;integrated security=true;";
            SqlConnection con = new SqlConnection(cs);
            string query = "Select * From Category";
            SqlCommand cmd= new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    CategoryModel model=new CategoryModel()
                    {
                        CategoryId = (int)reader["CatergoryId"],
                        Name= reader["Name"].ToString(),
                        Description= reader["Description"].ToString()
                    };
                    list.Add(model);
                }
            }
            con.Close();
            return View(list);
        }

        // to show Details of Category
        public IActionResult Details( int? id)
        {
            CategoryModel model = new CategoryModel();
            List<CategoryModel> list = new List<CategoryModel>();
            string cs = "server=.\\sqlexpress;database=MVCDB;integrated security=true;";
            SqlConnection con = new SqlConnection(cs);
            string query = $"select * from Category where CatergoryId={id}";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader record = cmd.ExecuteReader();
            if (record.HasRows)
            {
                while (record.Read())
                {
                    model = new CategoryModel()
                    {
                        CategoryId = (int)record["CatergoryId"],
                        Name = record["Name"].ToString(),
                        Description = record["Description"].ToString()
                    };
                }

            }
            con.Close();

            return View(model);
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // to provide from the create a new category
        public IActionResult Create(CategoryModel category)
        {
            List<CategoryModel> list = new List<CategoryModel>();
           string cs = "server=.\\sqlexpress;database=MVCDB;integrated security=true;";
            SqlConnection con = new SqlConnection(cs);
            string query = $"insert into Category Values ('{category.Name}','{category.Description}')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
           int record=cmd.ExecuteNonQuery();
            if(record>0)
            {
                return RedirectToAction("Index");
            }
            con.Close();

            return View();
        }

        // to update the Category
        [HttpPost]
        public IActionResult Edit(CategoryModel category)
        {
            //List<CategoryModel> list = new List<CategoryModel>();
            string cs = "server=.\\sqlexpress;database=MVCDB;integrated security=true;";
            SqlConnection con = new SqlConnection(cs);
            string query = $"update Category set Name='{category.Name}', Description='{category.Description}' where CatergoryId= {category.CategoryId}";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int record = cmd.ExecuteNonQuery();
            if (record > 0)
            {
                return RedirectToAction("Index");
            }
            con.Close();

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CategoryModel model = new CategoryModel();
            List<CategoryModel> list = new List<CategoryModel>();
            string cs = "server=.\\sqlexpress;database=MVCDB;integrated security=true;";
            SqlConnection con = new SqlConnection(cs);
            string query = $"select * from Category where CatergoryId={id}";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader record = cmd.ExecuteReader();
            if (record.HasRows)
            {
                while (record.Read())
                {
                     model = new CategoryModel()
                    {
                        CategoryId = (int)record["CatergoryId"],
                        Name = record["Name"].ToString(),
                        Description = record["Description"].ToString()
                    };
                }
               
            }
            con.Close();

            return View(model);
        }

        // to delete  Cateogory by list
        [HttpGet]
        [ActionName("Delete")]
        public IActionResult Delete_Get(int? id)
        {
            List<CategoryModel> list = new List<CategoryModel>()
            {
                new CategoryModel() { CategoryId=1, Name="Shirt", Description="Casule Shirt"},
                new CategoryModel() { CategoryId=2, Name="Shoes", Description="Sport"}

            };
            CategoryModel model= list.Where(c=>c.CategoryId==id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete_Confirm(int? id)
        {
            return View();
        }
    }
}
