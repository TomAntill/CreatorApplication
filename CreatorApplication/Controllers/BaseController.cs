using CreatorApplication.BLL.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorApplication.Controllers
{
    [ApiController]
    public class BaseController<AddVm, Vm, UpdateVm> : Controller
    {
        private IBaseBLL<Vm, UpdateVm, AddVm> _BLL = null;

        public BaseController(IBaseBLL<Vm, UpdateVm, AddVm> bll)
        {
            _BLL = bll ?? throw new ArgumentNullException(nameof(bll));
        }

        [HttpPost]
        [Route("Add")]
        public async Task<int> Add(AddVm addVm)
        {
            return await _BLL.Add(addVm);
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<List<Vm>> GetAll()
        {
            return await _BLL.GetAllAsync();
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<Vm> GetById(int id)
        {
            return await _BLL.GetByIdAsync(id);
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<bool> Delete(int id)
        {
            return await _BLL.Delete(id);
        }
        [HttpPost]
        [Route("Update")]
        public async Task<bool> Update([FromBody] UpdateVm updateVm)
        {
            return await _BLL.Update(updateVm);
        }
    }
}
