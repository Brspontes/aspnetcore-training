using EFCore.Domain;
using EFCore.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //InserirDados();
            //InserirDadosMassa();
            //ConsultarDados();
            CarregamentoAdiantado();
        }

        private static void CarregamentoAdiantado()
        {
            using var db = new Data.ApplicationContext();

            var consulta = db.Pedidos
                .Include(pedido => pedido.Itens) //Primeiro nivel
                .ThenInclude(pedidoItem => pedidoItem.Produto) //Segundo nível
                .FirstOrDefault();

            Console.WriteLine(consulta);
        }

        private static void InserirDados()
        {
            var produto = new Produto
            {
                CodigoBarras = "123456789",
                Descricao = "Smartphone",
                Valor = "599.99",
                TipoProduto = TipoProduto.Embalagem,
                Ativo = true
            };

            using var db = new Data.ApplicationContext();

            //MANEIRAS DE INSERIR DADOS NO BANCO
            db.Produtos.Add(produto);
            //db.Set<Produto>().Add(produto);
            //db.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            //db.Add(produto);

            var registros = db.SaveChanges();
            Console.WriteLine(registros);
        }

        private static void InserirDadosMassa()
        {
            var produto = new Produto
            {
                CodigoBarras = "123456789",
                Descricao = "Smartphone",
                Valor = "599.99",
                TipoProduto = TipoProduto.Embalagem,
                Ativo = true
            };

            var cliente = new Cliente
            {
                Nome = "João da Silva",
                Telefone = "1112345678",
                CEP = "18077362",
                Estado = "SP",
                Cidade = "São Paulo",
                Email = "joao.silva@example.com"
            };

            using var db = new Data.ApplicationContext();
            db.AddRange(produto, cliente);
            var registros = db.SaveChanges();
            Console.WriteLine(registros);
        }

        private static void ConsultarDados()
        {
            using var db = new Data.ApplicationContext();
            //var consulta = (from c in db.Clientes where c.Id > 0 select c).ToList();
            var consulta = db.Clientes.AsNoTracking().Where(cliente => cliente.Id > 0).ToList();
            foreach (var item in consulta)
            {
                Console.WriteLine($">>>>>>>>>>>>>> {item.Id}");
                db.Clientes.Find(item.Id);
            }
        }

        private static void CadastrarPedido()
        {
            using var db = new Data.ApplicationContext();
            var cliente = db.Clientes.FirstOrDefault(cliente => cliente.Id > 0);
            var produto = db.Produtos.FirstOrDefault(produto => produto.Id > 0);

            var pedido = new Pedido
            {
                ClientId = cliente.Id,
                IniciadoEm = DateTime.Now,
                FinalizadoEm = DateTime.Now,
                Observacao = "Pedido de teste",
                StatusPedido = StatusPedido.Analise,
                TipoFrete = TipoFrete.CIF,
                Itens = new List<PedidoItem>
                {
                    new PedidoItem
                    {
                        ProdutoId = produto.Id,
                        Desconto = 0,
                        Quantidade = 1,
                        Valor = 100
                    }
                }
            };

            db.Add(pedido);
            db.SaveChanges();
        }
    }
}
