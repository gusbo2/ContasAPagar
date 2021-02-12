using System.Threading.Tasks;
using ContasAPagar.Dtos.Bills;
using ContasAPagar.Services.Bills;
using Microsoft.AspNetCore.Mvc;
namespace ContasAPagar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;
        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddBillDto billDto) => Ok(await _billService.AddBill(billDto));

        [HttpGet]
        public async Task<ActionResult> Get() => Ok(await _billService.GetAllBill());

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSingle(int id) => Ok(await _billService.GetBill(id));

        [HttpPut]
        public async Task<ActionResult> Update(UpdatedBillDto billDto) => Ok(await _billService.UpdateBill(billDto));

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) => Ok(await _billService.DeleteBill(id));

    }
}