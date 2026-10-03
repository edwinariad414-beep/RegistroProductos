
using RegistroProductos.Models;
using SQLite;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RegistroProductos.Data
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Producto>().Wait();
        }

        public Task<int> GuardarProductoAsync(Producto producto)
        {
            if (producto.Id != 0)
            {
                return _database.UpdateAsync(producto);
            }

            return _database.InsertAsync(producto);
        }

        public Task<List<Producto>> ObtenerProductosAsync()
        {
            return _database.Table<Producto>().ToListAsync();
        }

        public Task<int> EliminarProductoAsync(Producto producto)
        {
            return _database.DeleteAsync(producto);
        }
    }
}

