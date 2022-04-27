using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHobbyListMvc.Domain.Interfaces
{
    public interface IHobbyRepository<T>
    {
        Task<IEnumerable<T>> GetList();
        Task<T> GetById(int? id);
        Task<T> Create(T t);
        Task<T> Update(T t);
        Task<T> Remove(T t);
    }
}
