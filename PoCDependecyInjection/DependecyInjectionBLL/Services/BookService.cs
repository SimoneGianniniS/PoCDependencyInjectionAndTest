using PoCDependecyInjection.BLL.Interface;
using PoCDependecyInjection.DAL;

namespace PoCDependecyInjection.BLL.Services
{
    public class BookService : IBookService, IDisposable
    {
        private IDBContext _dbContext;
        private IFormatService? _formatService;

        public BookService(IDBContext dbContext, IFormatService? formatService = null ) 
        {
            _dbContext = dbContext;
            _formatService = formatService;
        }

        public List<string> GetBook()
        {
            return _formatService?.FormatListOfString(_dbContext.GetBookNames()) ?? _dbContext.GetBookNames();
        }

        public void Dispose()
        {
        }
    }
}
