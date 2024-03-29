﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using QuickOrder.Adapters.Driven.PostgresDB.Core;

#nullable disable

namespace QuickOrder.Adapters.Driven.PostgresDB.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240129032600_Ajuste_ProdutoItem")]
    partial class Ajuste_ProdutoItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer")
                        .HasColumnName("Usuario");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Matricula")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer")
                        .HasColumnName("Usuario");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("QuantidadeItem")
                        .HasColumnType("integer");

                    b.Property<int>("TipoItem")
                        .HasColumnType("integer");

                    b.Property<double>("Valor")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CarrinhoId")
                        .HasColumnType("text");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("integer")
                        .HasColumnName("Cliente");

                    b.Property<DateTime?>("DataHoraFinalizado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataHoraInicio")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("NumeroPedido")
                        .HasColumnType("integer");

                    b.Property<string>("Observacao")
                        .HasColumnType("text");

                    b.Property<bool>("PedidoPago")
                        .HasColumnType("boolean");

                    b.Property<int?>("ProdutoItemPedidoId")
                        .HasColumnType("integer");

                    b.Property<double>("ValorPedido")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProdutoItemPedidoId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("integer");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<string>("Foto")
                        .HasColumnType("text");

                    b.Property<double>("Preco")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.ProdutoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ItemId")
                        .HasColumnType("integer")
                        .HasColumnName("Item");

                    b.Property<bool>("PermitidoAlterar")
                        .HasColumnType("boolean");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer")
                        .HasColumnName("Produto");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<int>("QuantidadeMax")
                        .HasColumnType("integer");

                    b.Property<int>("QuantidadeMin")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutoItem");
                });

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.ProdutoItemPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("PedidoId")
                        .IsRequired()
                        .HasColumnType("integer")
                        .HasColumnName("Pedido");

                    b.Property<int?>("ProdutoItemId")
                        .IsRequired()
                        .HasColumnType("integer")
                        .HasColumnName("PordutoItem");

                    b.Property<int>("QuantidadeProduto")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoItemId");

                    b.ToTable("ProdutoItemPedido");
                });

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.Cliente", b =>
                {
                    b.HasOne("QuickOrder.Core.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Clientes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("QuickOrder.Core.Domain.ValueObjects.TelefoneVo", "Telefone", b1 =>
                        {
                            b1.Property<int>("ClienteId")
                                .HasColumnType("integer");

                            b1.Property<string>("DDD")
                                .IsRequired()
                                .HasColumnType("varchar(15)")
                                .HasColumnName("DDD");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnType("varchar(15)")
                                .HasColumnName("Telefone");

                            b1.HasKey("ClienteId");

                            b1.ToTable("Cliente");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });

                    b.Navigation("Telefone")
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.Funcionario", b =>
                {
                    b.HasOne("QuickOrder.Core.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Funcionarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("QuickOrder.Core.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("QuickOrder.Core.Domain.Entities.ProdutoItemPedido", null)
                        .WithMany("Pedidos")
                        .HasForeignKey("ProdutoItemPedidoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.Produto", b =>
                {
                    b.OwnsOne("QuickOrder.Core.Domain.ValueObjects.NomeVo", "Nome", b1 =>
                        {
                            b1.Property<int>("ProdutoId")
                                .HasColumnType("integer");

                            b1.Property<string>("Nome")
                                .IsRequired()
                                .HasColumnType("varchar(150)")
                                .HasColumnName("Nome");

                            b1.HasKey("ProdutoId");

                            b1.ToTable("Produto");

                            b1.WithOwner()
                                .HasForeignKey("ProdutoId");
                        });

                    b.Navigation("Nome")
                        .IsRequired();
                });

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.ProdutoItem", b =>
                {
                    b.HasOne("QuickOrder.Core.Domain.Entities.Item", "Item")
                        .WithMany("ProdutoItens")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("QuickOrder.Core.Domain.Entities.Produto", "Produto")
                        .WithMany("ProdutoItens")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.ProdutoItemPedido", b =>
                {
                    b.HasOne("QuickOrder.Core.Domain.Entities.Pedido", "Pedido")
                        .WithMany("ProdutosItemsPedido")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("QuickOrder.Core.Domain.Entities.ProdutoItem", "ProdutoItem")
                        .WithMany("ProdutosItemsPedido")
                        .HasForeignKey("ProdutoItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("ProdutoItem");
                });

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.Usuario", b =>
                {
                    b.OwnsOne("QuickOrder.Core.Domain.ValueObjects.NomeVo", "Nome", b1 =>
                        {
                            b1.Property<int>("UsuarioId")
                                .HasColumnType("integer");

                            b1.Property<string>("Nome")
                                .IsRequired()
                                .HasColumnType("varchar(150)")
                                .HasColumnName("Nome");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("QuickOrder.Core.Domain.ValueObjects.CpfVo", "Cpf", b1 =>
                        {
                            b1.Property<int>("UsuarioId")
                                .HasColumnType("integer");

                            b1.Property<string>("CodigoCpf")
                                .IsRequired()
                                .HasColumnType("varchar(11)")
                                .HasColumnName("Cpf");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("QuickOrder.Core.Domain.ValueObjects.EmailVo", "Email", b1 =>
                        {
                            b1.Property<int>("UsuarioId")
                                .HasColumnType("integer");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Email");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.Navigation("Cpf")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Nome")
                        .IsRequired();
                });

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.Item", b =>
                {
                    b.Navigation("ProdutoItens");
                });

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.Pedido", b =>
                {
                    b.Navigation("ProdutosItemsPedido");
                });

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.Produto", b =>
                {
                    b.Navigation("ProdutoItens");
                });

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.ProdutoItem", b =>
                {
                    b.Navigation("ProdutosItemsPedido");
                });

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.ProdutoItemPedido", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("QuickOrder.Core.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Funcionarios");
                });
#pragma warning restore 612, 618
        }
    }
}
