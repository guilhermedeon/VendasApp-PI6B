using Microsoft.EntityFrameworkCore;
using VendasApp.Domain.Entities;

namespace VendasApp.Infra.Data;

public partial class VendasAppContext : DbContext
{
    public VendasAppContext()
    {
    }

    public VendasAppContext(DbContextOptions<VendasAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemPedido> ItemPedidos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=VendasApp;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Cliente_pkey");

            entity.HasMany<Pedido>(e => e.Pedidos).WithOne(d => d.IdClienteNavigation);

            entity.ToTable("Cliente");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Item_pkey");

            entity.ToTable("Item");
        });

        modelBuilder.Entity<ItemPedido>(entity =>
        {
            entity
                .HasKey(e => e.Id).HasName("ItemPedido_pkey");

            entity.ToTable("ItemPedido");

            entity.HasOne(d => d.IdItemNavigation).WithMany()
                .HasForeignKey(d => d.IdItem)
                .HasConstraintName("ItemId");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(e => e.ItensPedido)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("PedidoId");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pedido_pkey");

            entity.ToTable("Pedido");

            entity.HasMany(t => t.ItensPedido).WithOne(t => t.IdPedidoNavigation).HasPrincipalKey(t => t.Id);

            entity.Property(e => e.Data).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.IdVendedorNavigation).WithMany(d => d.Pedidos).HasForeignKey(d => d.IdVendedor).HasConstraintName("IdVendedor");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("IdCliente");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Usuario_pkey");

            entity.ToTable("Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}