using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDataBaseHelper
    {
        readonly SQLiteAsyncConnection _conn;
        public SQLiteDataBaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }
        public Task<int> inserir(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        public Task<List<Produto>> Editar(Produto p)
        {
            string sql = "UPDATE Produto SET Descricao=? , Quantidade=?. Preco=? WHERE Id=?";
            return _conn.QueryAsync<Produto>(sql, p.Descricao, p.Quantidade, p.preco, p.Id);
        }

        public void Deletar(int id)
        {

        }

        public void ColetarTodos()
        {

        }

        public void Pesquisar(string q)
        {

        }
    }
}
