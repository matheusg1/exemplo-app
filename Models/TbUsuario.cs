using System;
using System.Collections.Generic;

namespace PrimeiroTeste.Models;

public partial class TbUsuario
{
    public long UsuId { get; set; }

    public string UsuNome { get; set; } = null!;

    public virtual ICollection<TbPedido> TbPedidos { get; set; } = new List<TbPedido>();
}
