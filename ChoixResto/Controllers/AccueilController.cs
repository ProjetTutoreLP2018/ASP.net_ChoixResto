using ChoixResto.Models;
using ChoixResto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoixResto.Controllers
{
    public class AccueilController : Controller
    {
        public ActionResult Index ()
        {
            return View ();
        }

        public ActionResult ModifierRestaurant (int? id)
        {
            if (id.HasValue)
            {
                using (IDal dal = new Dal ())
                {
                    Resto restaurant = dal.ObtientTousLesRestaurants ().FirstOrDefault (r => r.Id == id.Value);
                    if (restaurant == null)
                    {
                        return View ("Error");
                    }
                    return View (restaurant);
                }
            }

            else
            {
                return View ("Error");
            }
        }

        [HttpPost]
        public ActionResult ModifierRestaurant (Resto resto)
        {
            using (IDal dal = new Dal ())
            {
                dal.ModifierRestaurant (resto.Id, resto.Nom, resto.Telephone);
                return RedirectToAction ("Index");
            }
        }
    }
}