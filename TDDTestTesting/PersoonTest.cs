using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TDDTestLibrary;


namespace TDDTestTesting
{
    [TestClass]
    public class PersoonTest
    {
        private List<string> naam;
        private Persoon persoon1;

        [TestInitialize]
        public void Initialize()
        {
            naam = new List<string>();
        }


        [TestMethod]
        public void normalUitVoerenMetListVanVoornamen()
        {
            naam.Add(" Ana");
            naam.Add("Liza");
            naam.Add("Maria");

            persoon1 = new Persoon(naam);

            string persoonVooranaam = "";
            foreach (var voornaam in naam)
            {
                if (persoonVooranaam != "")
                    persoonVooranaam += " ";

                persoonVooranaam += voornaam;

            }
            Assert.AreEqual(persoonVooranaam, persoon1.ToString());
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]

        public void voornamenListMoetMinsteEenVoornaamBevat()
        {
            persoon1 = new Persoon(naam);

        }



        [TestMethod, ExpectedException(typeof(ArgumentException))]

        public void voornamenListMetEenVoornaamBevatMistenEenTeken()
        {
            naam.Add("Liza");
            naam.Add("Maria");
            naam.Add("");
            persoon1 = new Persoon(naam);

        }



        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ListVanVoornamenBevatNietHerhalendeVoornaman()
        {
            naam.Add("Maria");
            naam.Add("Liza");
            naam.Add("maria");
            persoon1 = new Persoon(naam);

        }



        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void NullListVoornamenNotAccepted()
        {
            naam = null;
            persoon1 = new Persoon(naam);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void NullValueInVoornamenListNotAccepted()
        {
            naam.Add("Liza");
            naam.Add(null);
            naam.Add("Maria");
            persoon1 = new Persoon(naam);
        }
    }
}
