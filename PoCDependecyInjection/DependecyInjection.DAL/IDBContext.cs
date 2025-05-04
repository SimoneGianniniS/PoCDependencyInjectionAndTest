namespace PoCDependecyInjection.DAL
{
    public interface IDBContext
    {
        public List<string> GetPersonNames();
        public List<string> GetBookNames();
    }
}
