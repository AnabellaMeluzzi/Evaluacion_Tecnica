using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evaluacion_Tecnica.Models;

namespace Evaluacion_Tecnica.Controllers
{
    public class ContratoController : Controller
    {
        List<Contrato> _contratos = new List<Contrato>();
        private bool _ordenado;

        public ActionResult Index()
        {
            _contratos = (List<Contrato>)Session["Contratos"];

            if (_contratos is null)
            {
                CargarContratos();
                _contratos = (List<Contrato>)Session["Contratos"];

                _ordenado = false;
                Session["Ordenado"] = _ordenado;               
                Session["EstadoOrdenado"] = _ordenado;
            }

            return View(_contratos);
        }

        /// <summary>
        /// Agrega un contrato nuevo.
        /// </summary>
        /// <param name="contrato"></param>
        /// <returns></returns>
        public ActionResult AddContrato(string contrato)
        {
            if (ModelState.IsValid)
            {
                _contratos = (List<Contrato>)Session["Contratos"];

                Contrato nuevoContrato = new Contrato(contrato, false);
                _contratos.Add(nuevoContrato);

                Session["Contratos"] = _contratos;

                return Index();
            }
            return View();
        }

        /// <summary>
        /// Ordena contratos alfabeticamente.
        /// </summary>
        /// <returns></returns>
        public ActionResult OrdenarContratos()
        {
            _contratos = (List<Contrato>)Session["Contratos"];
            _ordenado = (bool)Session["Ordenado"];

            if (_ordenado == false)
            {
                _contratos = _contratos.OrderByDescending(c => c.TipoContrato).ToList();
                _ordenado = true;
                Session["Ordenado"] = _ordenado;
            }
            else
            {
                _contratos = _contratos.OrderBy(c => c.TipoContrato).ToList();
                _ordenado = false;
                Session["Ordenado"] = _ordenado;
            }

            Session["Contratos"] = _contratos;

            return RedirectToAction("Index");
        }        
        
        /// <summary>
        /// Ordena contratos por estado.
        /// </summary>
        /// <returns></returns>
        public ActionResult OrdenarEstados()
        {
            _contratos = (List<Contrato>)Session["Contratos"];
            _ordenado = (bool)Session["EstadoOrdenado"];

            if (_ordenado == false)
            {
                _contratos = _contratos.OrderBy(c => c.Estado).ToList();
                _ordenado = true;
                Session["EstadoOrdenado"] = _ordenado;
            }
            else
            {
                _contratos = _contratos.OrderByDescending(c => c.Estado).ToList();
                _ordenado = false;
                Session["EstadoOrdenado"] = _ordenado;
            }

            Session["Contratos"] = _contratos;

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Carga lista inicial de contratos de prueba.
        /// </summary>
        private void CargarContratos()
        {
            List<Contrato> contratos = new List<Contrato>();

            Contrato c1 = new Contrato("Contrato1", true);
            Contrato c2 = new Contrato("Contrato2", true);
            Contrato c3 = new Contrato("Contrato3", false);
            Contrato c4 = new Contrato("Contrato4", true);
            Contrato c5 = new Contrato("Contrato5", false);

            contratos.Add(c1);
            contratos.Add(c2);
            contratos.Add(c3);
            contratos.Add(c4);
            contratos.Add(c5);

            Session["Contratos"] = contratos;
        }
    }
}