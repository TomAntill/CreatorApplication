using CreatorApplication.Data.DataModels;
using CreatorApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorApplication.DAL.Contracts
{
    public interface IBaseDAL<T, TUpdate, TAdd>
    {
        public Task<int> Add(TAdd t);
        public Task<bool> Update(TUpdate t);
        public Task<bool> Delete(int id);
        public Task<T> GetById(int id);
        public Task<List<T>> GetAll();
    }
}
