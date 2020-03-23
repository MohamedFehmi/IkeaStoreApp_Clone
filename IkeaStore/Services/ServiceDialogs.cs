using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using IkeaStore.IServices;

namespace IkeaStore.Services
{
    /// <summary>
    /// All user dialogs must be implemented here in oreder to avoid refrencing App class from the view models
    /// </summary>
    public class ServiceDialogs : IServiceDialogs
    {
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

        public async Task SingleActionCustomMessageAlert(string title, string message, string actionText)
        {
            await AppShell.Current.DisplayAlert(title, message, actionText);
        }
    }
}