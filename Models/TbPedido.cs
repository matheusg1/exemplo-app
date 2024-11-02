using System;
using System.Collections.Generic;

namespace PrimeiroTeste.Models;

public partial class TbPedido
{
    public long PedId { get; set; }

    public DateTime PedData { get; set; }

    public decimal PedValor { get; set; }

    public int PedQuantProduto { get; set; }

    public long ClienteIdPedido { get; set; }

    public long ProdutoIdPedido { get; set; }

    public long UsuarioIdPedido { get; set; }

    public virtual TbCliente ClienteIdPedidoNavigation { get; set; } = null!;

    public virtual TbProduto ProdutoIdPedidoNavigation { get; set; } = null!;

    public virtual TbUsuario UsuarioIdPedidoNavigation { get; set; } = null!;
}
