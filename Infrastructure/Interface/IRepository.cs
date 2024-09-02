using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<int> Adicionar(T entity);
        Task<int> Alterar(T entity);
        Task<int> Apagar(int Id);
        Task<T> LeituraPorId(int Id);
        Task<List<T>> ListaTodos();
    }
}
