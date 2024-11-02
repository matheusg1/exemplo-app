using Microsoft.EntityFrameworkCore;
using PrimeiroTeste.Data;
using PrimeiroTeste.Models;

namespace PrimeiroTeste.Repository
{
    public class ClienteRepository : Repository<TbCliente>
    {
        public ClienteRepository(DbPadraoContext context) : base(context)
        {
        }
    }
}
