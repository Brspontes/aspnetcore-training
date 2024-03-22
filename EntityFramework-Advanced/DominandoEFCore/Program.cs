using DominandoEFCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GapEnsureCreated();
        }

        /// <summary>
        /// Método utilizado para ambientes de desenvolvimento ou locais
        /// EnsureCreated => Permite criar um banco de dados e todas as tabelas de forma rápida
        /// EnsureDeleted => Permite que remova tudo que foi criado no banco de dados não deixando rastros
        /// </summary>
        static void EnsureCreatedAndDeleted()
        {
            using var db = new ApplicationContext();
            //db.Database.EnsureCreated();
            db.Database.EnsureDeleted();
        }

        static void GapEnsureCreated()
        {
            using var db = new ApplicationContext();
            using var db2 = new ApplicationContextCidade();

            db.Database.EnsureCreated();
            db2.Database.EnsureCreated();

            var dataBaseCreated = db2.GetService<IRelationalDatabaseCreator>();
            dataBaseCreated.CreateTables();
        }

        static void HelthCheckDatabase()
        {
            using var db = new ApplicationContext();

            //Método default do Entity Framework para validar conexão
            var canConnect = db.Database.CanConnect();

            try
            {
                //Modo 1
                var connection = db.Database.GetDbConnection();
                connection.Open();

                //Modo 2
                db.Departamentos.Any();

                Console.WriteLine("Conexão Ok");
            }
            catch (Exception ex) { }
        }


    }
}

