using Dapper;
using Dapper1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Dapper1.Controllers
{
    public class OgrenciController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddOgrenci() => View();

        [HttpPost]
        public IActionResult AddOgrenci(OgrenciTanim model)
        {

            using (SqlConnection con = new SqlConnection("Server=.;Database=DapperMicroOrm;User Id=yusuf;Password=123"))
            {
                con.Open();
                con.Execute("insert into OgrenciTanim(Id,Isim,Soyisim,DogumTarih) values(@Id,@Isim,@Soyisim,@DogumTarih)", new OgrenciTanim()
                {
                    //Id = Guid.NewGuid(),
                    //Isim = "Ali",
                    //Soyisim = "Yıldızöz",
                    //DogumTarih = DateTime.Now

                    Id = Guid.NewGuid().ToString(),
                    Isim = model.Isim,
                    Soyisim = model.Soyisim,
                    DogumTarih = model.DogumTarih,

                });
                con.Close();
            }

            return View();


        }

        public IActionResult ShowOgrenci()
        {
            
            using (SqlConnection con = new SqlConnection("Server=.;Database=DapperMicroOrm;User Id=yusuf;Password=123"))
            {
                con.Open();
               var data = con.Query("select * from OgrenciTanim");
                List<OgrenciTanim> ogrenciTanimlar = con.Query<OgrenciTanim>("select * from OgrenciTanim").ToList();
              
               // IEnumerable<OgrenciTanim> ogrenciTanimlar = con.Query<OgrenciTanim>("select * from OgrenciTanim");
                con.Close();
                return View(ogrenciTanimlar);
            }
           
        }

    }
}
