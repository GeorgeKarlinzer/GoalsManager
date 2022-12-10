using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CsTsTranslator
{
    internal partial class RoutesTranslator
    {
        [GeneratedRegex("public const string (\\S.+);")]
        private static partial Regex MatchConstRoute();

        public string Translate(string csContent)
        {
            var routes = new List<string>();

            foreach (Match match in MatchConstRoute().Matches(csContent).Cast<Match>())
            {
                var val = match.Groups[1].Value;

                var tsVal = $"{char.ToLower(val[0])}{val[1..]}";
                routes.Add(tsVal);
            }

            var tsEnum = $$"""
                export enum ApplicationRoutes {
                    {{string.Join(",\n\t", routes)}}
                }
                """;

            return tsEnum;
        }
    }
}
