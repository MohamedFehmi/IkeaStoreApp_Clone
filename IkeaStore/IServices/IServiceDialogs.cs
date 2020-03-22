using System.Threading.Tasks;

namespace IkeaStore.IServices
{
    public interface IServiceDialogs
    {
        // Display a prompt to the user for barcode
        Task<string> BarcodeDialog();
    }
}