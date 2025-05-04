namespace PoCDependecyInjection.BLL.Interface
{
    public interface IPrintService
    {
        string PrintNames(string? text);

        string ComposeStringWithStringBuilder (List<string> inputs);
    }
}
