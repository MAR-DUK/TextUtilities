using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextUtilities.Utilities;

namespace TextUtilities
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo = new string[] {
                "ток", "рост", "кот", 
                "торс", "Кто", "фывап", "рок"
            };

            var result = Anagrams.FindAnagrams(demo).ToArray();

            string report = string.Join(Environment.NewLine, result
                .Select(group => string.Join(", ", group)));
        }
    }
}
