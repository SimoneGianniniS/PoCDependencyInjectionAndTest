using Microsoft.Extensions.DependencyInjection;
using PoCDependecyInjection.BLL.Interface;
using PoCDependecyInjection.DAL;
using System.Diagnostics;

namespace PoCDependecyInjection.BLL.Services
{
    public class PrintServiceSingleton : IPrintService, IDisposable
    {
        private readonly IServiceProvider serviceProvider;
        public PrintServiceSingleton(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string PrintNames(string? text)
        {
            var ret = string.Empty;
            //di base non posso iniettare uno scoped all'interno di un signleton, si genera un errore, perchè in pratica lo scoped verrebbe convertito in singleton
            //nel caso in cui abbia la necessità di farlo posso procedere come segue
            //installare questo pacchetto nuget per poter avere il metodo create scope Microsoft.Extensions.DependencyInjection.Abstractions
            //senza mi fa recuperare il servizio ma non creare lo scope e quindi mi troverei sempre nel contesto del singleton e non risolverei
            //il "problema", potrei crearmelo e poi dopo averlo utilizzato farne il dispose, ma è meglio lavorare con gli scope, perchè altrimenti andremo contro
            //il princio della DI non creo oggetti (new) e non li distruggo (dispose)
            using (var scope = serviceProvider.CreateScope()){
                var dbContext = scope.ServiceProvider.GetRequiredService<IDBContext>();
                var names = dbContext.GetPersonNames();
                ret = string.Join(", ", names);
            }
            Debug.Print(ret);
            return ret;
        }

        public string ComposeStringWithStringBuilder(List<string> inputs)
        {
            return string.Empty;
        }

        public void Dispose()
        {
        }        
    }
}
