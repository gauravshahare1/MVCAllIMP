using FilterDemo.Filter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddMvc(options =>
options.Filters.Add(typeof(MyExceptionFilter)));

var app = builder.Build();


app.UseHttpsRedirection(); // by default, all req. will use https protocol
app.UseStaticFiles(); // to use static file from wwwroot folder


app.UseAuthorization(); // to enale authorization at application level

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");
//app.UseRouting(); // to enable routing 

app.Run();
