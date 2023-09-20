using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSystemIO
{
    public class Winner
    {
        public int index { get; set; }
        public int year { get; set; }
        public int age { get; set; }
        public string name { get; set; }
        public string movie { get; set; }

        public Winner(string input)
        {
            //parse the input string like:
            //1, 1982, 44, "Emil Jannings", "The Last Command, The Way of All Flesh"

            var comma1 = input.IndexOf(',');
            var comma2 = (input[(comma1 + 1)..].IndexOf(',')) + comma1 + 1;
            var comma3 = (input[(comma2 + 1)..].IndexOf(",")) + comma2 + 1;
            var comma4 = (input[(comma3 + 1)..].IndexOf(",")) + comma3 + 1;
            //var comma3 = input[new Range(comma2, input.IndexOf(","))];
            var indexRange = new Range(0, comma1);
            var yearRange = new Range(comma1 + 1, comma2);
            var ageRange = new Range(comma2 + 1, comma3);
            var nameRange = new Range(comma3 + 3, comma4 - 1);
            var movieRange = new Range(comma4 + 3, input.Length - 1);
            index = int.Parse(input[indexRange]);
            year = int.Parse(input[yearRange]);
            age = int.Parse(input[ageRange]);
            name = input[nameRange];
            movie = input[movieRange];

        }

        public Winner() { }
    }
}
