using System;
using System.Collections.Generic;

namespace PrimeiroTeste.Models;

public partial class TbProduto
{
    public long ProdId { get; set; }

    public string ProdNome { get; set; } = null!;

    public decimal ProdValor { get; set; }

    public int ProdQuantidade { get; set; }

    public DateTime ProdDtInclusao { get; set; }

    public DateTime? ProdDtAlteracao { get; set; }

    public virtual ICollection<TbPedido> TbPedidos { get; set; } = new List<TbPedido>();
}
