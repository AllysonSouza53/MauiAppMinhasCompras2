using MauiAppMinhasCompras.Models;
using SQLite;

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

        public Task<int> Deletar(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Produto>> ColetarTodos()
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> Pesquisar(string q)
        {
            string sql = "SELECT * Produto WHERE descricao LIKE '%"+q+"%'";
            return _conn.QueryAsync<Produto>(sql);
        }
    }
}
