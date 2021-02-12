using System.Collections.Generic;
using System.Threading.Tasks;
using ContasAPagar.Dtos.Bills;
using ContasAPagar.Models;

namespace ContasAPagar.Services.Bills
{
    public interface IBillService
    {
        Task<ResponseModel<GetBillDto>> AddBill(AddBillDto newBill);
        Task<ResponseModel<List<GetBillDto>>> GetAllBill();
        Task<ResponseModel<GetBillDto>> GetBill(int id);
        Task<ResponseModel<GetBillDto>> UpdateBill(UpdatedBillDto billDto);
        Task<ResponseModel<GetBillDto>> DeleteBill(int id);
    }
}