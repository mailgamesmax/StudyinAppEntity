using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyinAppEntity.Models
{
    internal class CommonFunctions
    {
        public static List<string> NormalizeInputForTitle()
        {
            var userInput = Console.ReadLine();

            List<string> inputedElements = userInput.Split(',').Select(x => x.Trim()).ToList();
            if (inputedElements[inputedElements.Count - 1] == "")
            {
                inputedElements.RemoveAt(inputedElements.Count - 1);
            }

            List<string> inputNormalized = new List<string>();

            foreach (var e in inputedElements)
            {
                string normalizeElement = char.ToUpper(e[0]) + (e.Substring(1)).ToLower();
                inputNormalized.Add(normalizeElement);
            }
            return inputNormalized;
        }

        public static List<int> InputedNrToList()
        {
            var userInput = Console.ReadLine();

            List<string> inputedElements = userInput.Split(',').Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToList();
            /*if (inputedElements[inputedElements.Count - 1] == "")
            {
                inputedElements.RemoveAt(inputedElements.Count - 1);
            }*/

            List<int> inputNormalized = new List<int>();

            foreach (var e in inputedElements)
            {                
                bool convertedToInt = int.TryParse(e, out int normalizedElement);
                if (convertedToInt)
                {
                inputNormalized.Add(normalizedElement);
                }
                else
                {
                    Console.WriteLine($"{e} <- klaidingas pasirinkimas, bus ignoruotas");
                }
            }
            if (inputedElements.Count > 0) 
            {
                return inputNormalized; 
            }
            else
            {
                Console.WriteLine("įvedimo arba pasirinkimo klaida");
                return inputNormalized = null;
            }
        }

    }
}
