using System.Threading.Tasks;

namespace IkeaStore.IServices
{
    public interface IServiceDialogs
    {
        // Display a prompt to the user for barcode
        Task<string> BarcodeDialog();

        // Display alert to the user wiht a custom content
        Task SingleActionCustomMessageAlert(string title, string message, string actionText);
    }
}