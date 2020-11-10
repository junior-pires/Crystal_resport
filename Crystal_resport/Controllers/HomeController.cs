using Crystal_resport.Models;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crystal_resport.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Pdf()
        {
            List<usuario> usuarios = new List<usuario>()
            {
                new usuario{nome="Ernesto Junior Pires Alide",emal="junior.alide007@gmail.com"},
                new usuario{nome=" Pires Alide",emal="jpires@mozsistemas.co.mz"},
                new usuario{nome=" Pires Alide",emal="jpires@mozsistemas.co.mz"},
                new usuario{nome=" Pires Alide",emal="jpires@mozsistemas.co.mz"},
                new usuario{nome=" Pires Alide",emal="jpires@mozsistemas.co.mz"},
            };
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Content"), "crp_usuario.rpt"));

            rd.SetDataSource(usuarios);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "usuarios.pdf");
        }
    }
}