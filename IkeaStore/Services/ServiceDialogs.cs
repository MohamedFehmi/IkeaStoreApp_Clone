using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using IkeaStore.IServices;

namespace IkeaStore.Services
{
    public class ServiceDialogs : IServiceDialogs
    {
        public ServiceDialogs()
        {
        }

        public async Task<string> BarcodeDialog()
        {
            PromptResult result = await UserDialogs.Instance.PromptAsync(new PromptConfig() { Title = "Enter barcode", OkText = "OK", CancelText = "Cancel" });

            if (result.Ok)
            {
                if (!string.IsNullOrEmpty(result.Text))
                {
                    return result.Text;
                }
            }
            
            return string.Empty;
        }
    }
}
