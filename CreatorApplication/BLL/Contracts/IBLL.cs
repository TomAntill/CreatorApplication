using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorApplication.BLL.Contracts
{
    public interface IBLL<T, TUpdate>
    {
        public Task<int> Add(T t);
        public Task<bool> Delete(int id);
        public Task<bool> Update(TUpdate t);
        public Task<T> GetByIdAsync(int id);
        public Task<List<T>> GetAllAsync();
    }
}
