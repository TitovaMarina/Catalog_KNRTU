using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Catalog
{
    public class Validation
    {
        public static bool IsValid(string field)
        {
            Regex regexSymbols = new Regex(@"\W", RegexOptions.IgnoreCase);
            Regex regexRus = new Regex(@"\p{IsCyrillic}");
            //Regex regexRusSmall = new Regex(@"\P{IsCyrillic}");
            MatchCollection matchesSymbols = regexSymbols.Matches(field);
            MatchCollection matchesRus = regexRus.Matches(field);
            //MatchCollection matchesRusSmall = regexRusSmall.Matches(field);
            if (matchesSymbols.Count > 0 || matchesRus.Count > 0 )
                return false;
            else
                return true;
        }
    }
}
