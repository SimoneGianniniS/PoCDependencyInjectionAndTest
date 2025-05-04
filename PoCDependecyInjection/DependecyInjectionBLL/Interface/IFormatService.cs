using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoCDependecyInjection.BLL.Interface
{
    public interface IFormatService
    {
        public string FormatString(string? stringToFormat);
        public List<string> FormatListOfString(List<string> listOfStringToFormat);

    }
}
