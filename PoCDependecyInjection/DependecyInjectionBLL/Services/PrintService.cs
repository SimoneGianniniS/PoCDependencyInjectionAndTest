using PoCDependecyInjection.BLL.Interface;
using PoCDependecyInjection.DAL;
using System.Diagnostics;
using System.Text;

namespace PoCDependecyInjection.BLL.Services
{
    public class PrintService :IPrintService, IDisposable
    {
        private IDBContext _dbContext;
        private IFormatService? _formatService;

        public PrintService(IDBContext dbContext, IFormatService? formatService=null) 
        {
            _dbContext = dbContext;
            _formatService = formatService;
        }

        public string PrintNames(string? text)
        {
            var sb = new StringBuilder("Hello ");           
            sb.Append(_formatService?.FormatString(text) ?? text);
            sb.Append("!!!");
            Debug.Print(sb.ToString());
            return sb.ToString();
        }

        public string ComposeStringWithStringBuilder(List<string> inputs)
        {
            var sb = new StringBuilder();
            foreach (var input in inputs)
            {
                sb.AppendLine(input);
            }
            return sb.ToString();
        }

        public void Dispose()
        {
        }
    }
}
