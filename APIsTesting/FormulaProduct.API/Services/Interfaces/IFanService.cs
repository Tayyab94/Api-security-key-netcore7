using FormulaProduct.API.Models;

namespace FormulaProduct.API.Services.Interfaces
{
    public interface IFanService
    {
        Task<List<Fan>?> GetAllFans();
    }
}
