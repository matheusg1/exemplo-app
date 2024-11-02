using Microsoft.EntityFrameworkCore;
using PrimeiroTeste.Data;
using PrimeiroTeste.Models;

namespace PrimeiroTeste.Repository
{
    public class ProdutoRepository : Repository<TbProduto>
    {
        public ProdutoRepository(DbPadraoContext context) : base(context)
        {
        }
    }
}
