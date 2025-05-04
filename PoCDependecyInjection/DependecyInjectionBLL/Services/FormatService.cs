using PoCDependecyInjection.BLL.Helper;
using PoCDependecyInjection.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoCDependecyInjection.BLL.Services
{
    public class FormatService : IFormatService, IDisposable
    {
        public FormatService()
        {
        }

        public void Dispose()
        {
           
        }

        public List<string> FormatListOfString(List<string> listOfStringToFormat)
        {
            var ret = new List<string>();
            foreach (var item in listOfStringToFormat)
            {
                ret.Add(item.ToUpper());
            }
            return ret;
        }

        public string FormatString(string? stringToFormat)
        {
            return stringToFormat.HasValue() ? stringToFormat.ToUpper() : string.Empty;            
        }
    }
}
