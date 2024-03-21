using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCPROJECT.Models;
using Microsoft.Data.SqlClient;

namespace MVCPROJECT.Controllers;

public class AdminController : Controller
  {

    SqlConnection con=new SqlConnection();

    SqlCommand com=new SqlCommand();
    

    SqlDataReader? dr;


    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

  
    public IActionResult About()
    {
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }
    public IActionResult Product()
    {
        return View();
    }
    public IActionResult create()
    {
        return View();
    }
    [HttpGet]
     public IActionResult Login()
    {
        return View();
    }



    void connectionstring(){
        con.ConnectionString="data source=192.168.1.240\\SQLEXPRESS; database=CAD_OFS; User Id= CADBATCH01; Password=CAD@123pass; TrustServerCertificate=True;";

    }
    [HttpPost]

    public IActionResult VerifyLogin(LoginModel lmodel){
        connectionstring();
        con.Open();
        com.Connection=con;
        com.CommandText="select * from ofs_login  where Username='"+lmodel.username+"' and password='"+lmodel.password+"' ";
        dr=com.ExecuteReader();

        if(dr.Read()){
            con.Close();
            return View("Success");

        }
        else{
              con.Close();
            return View("Error");


        }
       
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
 }
