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
                throw new ArgumentException();
            if(voornamen.Count<=0)
                throw new ArgumentException();
            
            foreach(var voornaam in voornamen)
                {
                if (!regex.IsMatch(voornaam))
                    throw new ArgumentException();

                }
            if (voornamen.Count != voornamen.Distinct().Count())
            {
                    throw new ArgumentException();

            }


            Voornamen = voornamen;


        }


        public override string ToString() 
        {
            string result="";
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
