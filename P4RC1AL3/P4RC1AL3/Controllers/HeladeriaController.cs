using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Net.Http;

namespace P4RC1AL3.Controllers
{
    public class HeladeriaController : ApiController
    {
        // GET: Heladeria
        [System.Web.Http.HttpPost]
        // GET: Producto
        public IHttpActionResult Add()
        {
            using (Models.HeladeriaEntities1 db = new Models.HeladeriaEntities1())

            {
                var oHelado = new Models.Helado();
                oHelado.nombre = "RonConpasas";
                oHelado.precio = 1;
                oHelado.cantidad = 10;
                oHelado.descripcion = "Cono grande ";
                db.Helados.Add(oHelado);
                db.SaveChanges();
            }
            return Ok("Hecho");

        }
    }
}

// https://localhost:44351/Api/Heladeria este link poner enmpostman