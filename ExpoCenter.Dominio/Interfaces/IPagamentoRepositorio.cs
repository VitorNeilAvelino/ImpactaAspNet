using ExpoCenter.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpoCenter.Dominio.Interfaces
{
    public interface IPagamentoRepositorio
    {
        Task Delete(int id);
        Task<List<Pagamento>> Get();
        Task<Pagamento> Get(int id);
        Task<Pagamento> Post(Pagamento pagamento);
        Task Put(Pagamento pagamento);
    }
}