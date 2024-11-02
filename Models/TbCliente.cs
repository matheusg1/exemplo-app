using System;
using System.Collections.Generic;

namespace PrimeiroTeste.Models;

public partial class TbCliente
{
    public long ClieId { get; set; }

    public string ClieNome { get; set; } = null!;

    public virtual ICollection<TbPedido> TbPedidos { get; set; } = new List<TbPedido>();
}
