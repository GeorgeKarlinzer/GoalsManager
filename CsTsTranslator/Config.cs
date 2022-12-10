using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsTsTranslator
{
    internal class RoutesConfig
    {
        public string CsFile { get; set; }
        public string TargetTsFile { get; set; }
    }

    internal class Config
    {
        public RoutesConfig Routes { get; set; }
    }
}
