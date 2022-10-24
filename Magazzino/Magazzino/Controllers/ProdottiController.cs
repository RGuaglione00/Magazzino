using Magazzino.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using SelectListItem = System.Web.WebPages.Html.SelectListItem;

namespace Magazzino.Controllers
{
    
    public class ProdottiController : Controller
    {
        Model1 context = new Model1();
        // GET: Prodotti
        [HttpGet]
        public ActionResult Index()
        {
           
            List<SelectListItem>ListaCategorie = new List<SelectListItem>();
            var query = context.CategoriaProdotti.ToList();
            foreach(var item in query)
            {
                SelectListItem C = new SelectListItem();
                C.Text = item.Descrizione;
                C.Value = item.Id.ToString();
                ListaCategorie.Add(C);
            }
            ViewBag.ListaCategorie= ListaCategorie;
           

            return View();
        }
       

        public ActionResult FillProdotti()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult FillProdotti(int numeroInserimenti)
        {
            int res = -1;

            if (numeroInserimenti > 0) {
                try {
                    var param = new SqlParameter("@NumeroInserimenti", numeroInserimenti);
                    res = context.Database.ExecuteSqlCommand("spFillProdotti @NumeroInserimenti", param);
                    if (res <= 0)
                    {
                        
                        TempData["ResultMessage"] = "Errore imprevisto durante l'esecuzione";
                    }
                    else
                    {
                        TempData["ResultMessage"] = "Inserimento avvenuto con successo";
                    }
                }
                catch (Exception ex)
                {
                    TempData["ResultMessage"] = ex.Message;
                }
            }
            else
            {
                
                TempData["ResultMessage"] = "Inserire un numero positivo";
            }
               

            return RedirectToAction("Index", "Prodotti");

            
        }
        [HttpGet]
        public ActionResult EliminaProdottiByIdCategoria(int id)
        {
            int res = -1;
         
                try
                {
                    var param = new SqlParameter("@IdCategoriaDelete", id);
                    res = context.Database.ExecuteSqlCommand("spDeleteProdotti @IdCategoriaDelete", param);
                    var recordRimanenti = context.Prodotti.Count();
                    //var nomeCat = context.Prodotti.Where(x => x.IdCategoriaProdotti == id).FirstOrDefault();

                if(recordRimanenti ==0)
                {
                    if(id !=0)
                    {
                        TempData["DeleteMessage"] = "Sono stati gia' cancellati tutti i prodotti";
                        
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "Tutti i prodotti sono stati cancellati";
                    }
                    return RedirectToAction("Index", "Prodotti");
                }

                    if (res <= 0)
                    {


                        TempData["DeleteMessage"] = "Non esiste nessun prodotto di questa categoria";
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "Tutti i prodotti della categoria sono stati cancellati";
                    }
                }
                catch (Exception ex)
                {
                    TempData["DeleteMessage"] = ex.Message;
                }
            


            return RedirectToAction("Index", "Prodotti");
        }

        public JsonResult ListaProdotti(int search)
        {
            
            List<vProdotti> ListaProdotti = new List<vProdotti>();
            ListaProdotti = context.vProdotti.Where(x => x.IdCategoriaProdotti == search).ToList();
           
            List<ProdottiToReturnInJson> listaToReturn = new List<ProdottiToReturnInJson>();
            if (ListaProdotti.Count == 0)
            {
                return Json(listaToReturn);
            }
            foreach (var item in ListaProdotti)
            {
                ProdottiToReturnInJson p = new ProdottiToReturnInJson
                {
                    Codice = item.Codice,
                    Descrizione = item.Descrizione,
                    Quantita = item.Quantita.ToString(),
                    Prezzo= (decimal)item.Prezzo,
                    Dimensione = item.Dimensione,
                    Attivo = item.Attivo,
                    DataProduzione= item.DataProduzione,
                    DescProduttore= item.DescProduttori,
                    DescCategoria=item.DescCategoriaProdotti,
                };
                listaToReturn.Add(p);
            }

            return Json(listaToReturn,JsonRequestBehavior.AllowGet);
        }
        public class ProdottiToReturnInJson
        {
            public string Codice { get; set; }
            public string Descrizione { get; set; }
            public string Quantita { get; set; }
            public decimal Prezzo { get; set; }
            public string Dimensione { get; set; }
            public string Attivo { get; set; }
            public string DataProduzione { get; set; }
            public string DescProduttore { get; set; }
            public string DescCategoria { get; set; }
        }
    }
}