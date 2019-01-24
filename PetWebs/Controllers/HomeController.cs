using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;/*Using para Enviar Correo*/

namespace PetWebs.Controllers
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
          

            return View();
        }
        [HttpPost]
        public ActionResult Contact(String De, String Motivo,int Fono, String Empresa, String Mensaje/*, HttpPostedFileBase Fichero*/)
        {
            String mensaje = "Enviado por: "+ Empresa+ "\r\n"+
                             "Correo: " + De + "\n" +
                             "\n"+ Fono + "\n"+
                             Mensaje;
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(De) ;
                correo.To.Add("silvanauto@gmail.com");
                correo.Subject = Motivo;
                correo.Body = mensaje;
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;

                /* Ruta de guardado de los archivos de adjunto que se envian 

                String ruta = Server.MapPath("../Temporal");
                Fichero.SaveAs(ruta + "\\" + Fichero.FileName);

                Attachment adjunto = new Attachment(ruta + "\\" + Fichero.FileName);
                correo.Attachments.Add(adjunto);
                */
                //Configuracion del servidor Smtp

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                string Correo = "clau.281andrex@gmail.com";
                string Pass = "WANRLTW224";
                smtp.Credentials = new System.Net.NetworkCredential(Correo, Pass);

                smtp.Send(correo);
                ViewBag.Mensaje = "Mensaje enviado correctamente";



            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View();
        }
    }
}