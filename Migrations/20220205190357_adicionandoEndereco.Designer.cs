﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoFinalVolvo;

#nullable disable

namespace ProjetoFinalVolvo.Migrations
{
    [DbContext(typeof(ConcessionariaContexto))]
    [Migration("20220205190357_adicionandoEndereco")]
    partial class adicionandoEndereco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjetoFinalVolvo.Proprietario", b =>
                {
                    b.Property<int>("proprietarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("proprietarioId"), 1L, 1);

                    b.Property<string>("cpfCnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("enderecoCidade")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("enderecoNumero")
                        .HasColumnType("int");

                    b.Property<string>("enderecoRua")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("proprietarioId");

                    b.ToTable("Proprietarios");
                });

            modelBuilder.Entity("ProjetoFinalVolvo.Veiculo", b =>
                {
                    b.Property<int>("veiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("veiculoId"), 1L, 1);

                    b.Property<string>("acessorios")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("ano")
                        .HasColumnType("smallint");

                    b.Property<string>("cor")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("modelo")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("numeroChassi")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<int>("proprietarioId")
                        .HasColumnType("int");

                    b.Property<int>("quilometragem")
                        .HasColumnType("int");

                    b.Property<float>("valor")
                        .HasColumnType("real");

                    b.Property<int>("vendedorId")
                        .HasColumnType("int");

                    b.Property<string>("versaoSistema")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("veiculoId");

                    b.HasIndex("proprietarioId");

                    b.HasIndex("vendedorId");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("ProjetoFinalVolvo.Vendedor", b =>
                {
                    b.Property<int>("vendedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("vendedorId"), 1L, 1);

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<float>("salario")
                        .HasColumnType("real");

                    b.HasKey("vendedorId");

                    b.ToTable("Vendedores");
                });

            modelBuilder.Entity("ProjetoFinalVolvo.Veiculo", b =>
                {
                    b.HasOne("ProjetoFinalVolvo.Proprietario", "Proprietario")
                        .WithMany()
                        .HasForeignKey("proprietarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinalVolvo.Vendedor", "Vendedor")
                        .WithMany()
                        .HasForeignKey("vendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proprietario");

                    b.Navigation("Vendedor");
                });
#pragma warning restore 612, 618
        }
    }
}
