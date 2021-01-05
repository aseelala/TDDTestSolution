using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TDDTestLibrary
{
    public class Persoon
    {
        private List<String> Voornamen = new List<String>();

        private static string pattern = @"^.*\S.*$";
        private static readonly Regex regex = new Regex(pattern);


        public Persoon(List<String> voornamen)
        {
            if (voornamen == null)
                throw new ArgumentNullException();

            if (voornamen.Count <= 0)
                throw new ArgumentException();

            foreach (var voornaam in voornamen)
            {
                if (voornaam == null)
                    throw new ArgumentNullException();

                if (!regex.IsMatch(voornaam))
                    throw new ArgumentException();
            }

            checkRpeated(voornamen);
            Voornamen = voornamen;
        }

        private void checkRpeated(List<string> voornamen)
        {
            List<string> lowervoornamen = voornamen.ConvertAll(x => x.ToLower());
            if (lowervoornamen.Count != lowervoornamen.Distinct().Count())
                throw new ArgumentException();
        }

        public override string ToString()
        {
            string result = "";
            foreach (var voornaam in Voornamen)
            {
                if (result != "")
                    result += " ";
                result += voornaam;
            }
            return result;
        }
    }
}
