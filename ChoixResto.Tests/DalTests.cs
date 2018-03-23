using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ChoixResto.Models;
using System.Data.Entity;

namespace ChoixResto.Tests
{
    [TestClass]
    public class DalTests
    {
        [TestInitialize]
        public void Init_AvantChaqueTest ()
        {
            IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext> ();
            Database.SetInitializer (init);
            init.InitializeDatabase (new BddContext ());
        }

        [TestMethod]
        public void CreerRestaurant_AvecUnNouveauRestaurant_ObtientTousLesRestaurantsRenvoitBienLeRestaurant ()
        {
            using (IDal dal = new Dal ())
            {
                dal.CreerRestaurant ("La bonne fourchette", "01 02 03 04 05");
                List<Resto> restos = dal.ObtientTousLesRestaurants ();

                Assert.IsNotNull (restos);
                Assert.AreEqual (1, restos.Count);
                Assert.AreEqual ("La bonne fourchette", restos[0].Nom);
                Assert.AreEqual ("01 02 03 04 05", restos[0].Telephone);
            }
        }

        [TestMethod]
        public void ModifierRestaurant_CreationDUnNouveauRestaurantEtChangementNomEtTelephone_LaModificationEstCorrecteApresRechargement ()
        {
            using (IDal dal = new Dal ())
            {
                dal.CreerRestaurant ("La bonne fourchette", "01 02 03 04 05");
                dal.ModifierRestaurant (1, "La bonne cuillère", null);

                List<Resto> restos = dal.ObtientTousLesRestaurants ();
                Assert.IsNotNull (restos);
                Assert.AreEqual (1, restos.Count);
                Assert.AreEqual ("La bonne cuillère", restos[0].Nom);
                Assert.IsNull (restos[0].Telephone);
            }
        }
    }  
}