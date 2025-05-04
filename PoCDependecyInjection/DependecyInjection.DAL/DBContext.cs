


namespace PoCDependecyInjection.DAL
{
    public class DBContext : IDBContext, IDisposable
    {
        public DBContext()
        {
        }

        public List<string> GetBookNames()
        {
            return new List<string>() { "La divina commedia", "Il decamerone", "I promessi sposi" };
        }

        public List<string> GetPersonNames()
        {
            return new List<string>() { "Pippo", "Paperino", "Pluto", "Topolino" };
        }

        public void Dispose()
        {
           
        }
    }
}
