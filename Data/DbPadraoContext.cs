using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PrimeiroTeste.Models;

namespace PrimeiroTeste.Data;

public partial class DbPadraoContext : DbContext
{
    public DbPadraoContext()
    {
    }

    public DbPadraoContext(DbContextOptions<DbPadraoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCliente> TbClientes { get; set; }

    public virtual DbSet<TbFornecedor> TbFornecedors { get; set; }

    public virtual DbSet<TbPedido> TbPedidos { get; set; }

    public virtual DbSet<TbProduto> TbProdutos { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.;Database=db-padrao;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCliente>(entity =>
        {
            entity.HasKey(e => e.ClieId).HasName("PK__TB_CLIEN__0C8BA50F4717095D");

            entity.ToTable("TB_CLIENTE");

            entity.Property(e => e.ClieId).HasColumnName("CLIE_ID");
            entity.Property(e => e.ClieNome)
                .HasMaxLength(255)
                .HasColumnName("CLIE_NOME");
        });

        modelBuilder.Entity<TbFornecedor>(entity =>
        {
            entity.HasKey(e => e.FornId).HasName("PK__TB_FORNE__BA1EF7FBAB522D53");

            entity.ToTable("TB_FORNECEDOR");

            entity.Property(e => e.FornId).HasColumnName("FORN_ID");
            entity.Property(e => e.FornNome)
                .HasMaxLength(255)
                .HasColumnName("FORN_NOME");
        });

        modelBuilder.Entity<TbPedido>(entity =>
        {
            entity.HasKey(e => e.PedId).HasName("PK__TB_PEDID__71F47F6A9B4B7141");

            entity.ToTable("TB_PEDIDO");

            entity.Property(e => e.PedId).HasColumnName("PED_ID");
            entity.Property(e => e.ClienteIdPedido).HasColumnName("CLIENTE_ID_PEDIDO");
            entity.Property(e => e.PedData)
                .HasColumnType("datetime")
                .HasColumnName("PED_DATA");
            entity.Property(e => e.PedQuantProduto).HasColumnName("PED_QUANT_PRODUTO");
            entity.Property(e => e.PedValor)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PED_VALOR");
            entity.Property(e => e.ProdutoIdPedido).HasColumnName("PRODUTO_ID_PEDIDO");
            entity.Property(e => e.UsuarioIdPedido).HasColumnName("USUARIO_ID_PEDIDO");

            entity.HasOne(d => d.ClienteIdPedidoNavigation).WithMany(p => p.TbPedidos)
                .HasForeignKey(d => d.ClienteIdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_PEDIDO__CLIEN__46E78A0C");

            entity.HasOne(d => d.ProdutoIdPedidoNavigation).WithMany(p => p.TbPedidos)
                .HasForeignKey(d => d.ProdutoIdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_PEDIDO__PRODU__47DBAE45");

            entity.HasOne(d => d.UsuarioIdPedidoNavigation).WithMany(p => p.TbPedidos)
                .HasForeignKey(d => d.UsuarioIdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USUARIO_PEDIDO");
        });

        modelBuilder.Entity<TbProduto>(entity =>
        {
            entity.HasKey(e => e.ProdId).HasName("PK__TB_PRODU__B3271E11DC0640CB");

            entity.ToTable("TB_PRODUTO");

            entity.Property(e => e.ProdId).HasColumnName("PROD_ID");
            entity.Property(e => e.ProdDtAlteracao)
                .HasColumnType("datetime")
                .HasColumnName("PROD_DT_ALTERACAO");
            entity.Property(e => e.ProdDtInclusao)
                .HasColumnType("datetime")
                .HasColumnName("PROD_DT_INCLUSAO");
            entity.Property(e => e.ProdNome)
                .HasMaxLength(255)
                .HasColumnName("PROD_NOME");
            entity.Property(e => e.ProdQuantidade).HasColumnName("PROD_QUANTIDADE");
            entity.Property(e => e.ProdValor)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PROD_VALOR");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.HasKey(e => e.UsuId).HasName("PK__TB_USUAR__0B483FBF245F481F");

            entity.ToTable("TB_USUARIO");

            entity.Property(e => e.UsuId).HasColumnName("USU_ID");
            entity.Property(e => e.UsuNome)
                .HasMaxLength(255)
                .HasColumnName("USU_NOME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
