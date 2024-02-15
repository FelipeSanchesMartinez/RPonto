using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPonto.Data.Repositories
{
    public class PontoContext : IPontoContext
    {
        protected SQLiteAsyncConnection Database;

        public PontoContext()
        {

        }
        public virtual async Task Init()
        {

            if (Database == null)
            {
                Database = new SQLiteAsyncConnection(SQLiteConstants.DatabasePath, SQLiteConstants.Flags);
                await Database.CreateTableAsync<Ponto>();

            }
            return;


        }
        public virtual async Task Cadastrar(Ponto model)
        {
            await Database.InsertAsync(model);
        }
        public virtual async Task<List<Ponto>> ObterPorPeriodo(DateTime dataI, DateTime dataF)
        {
            return await Database.Table<Ponto>()
                                .Where(obj => obj.DataEHora >= dataI && obj.DataEHora <= dataF)
                                .ToListAsync();
        }

        public virtual async Task<List<Ponto>> ObterPorDia(DateTime data)
        {
            return await Database.Table<Ponto>()
                                .Where(obj => obj.DataEHora.Day == data.Day)
                                .ToListAsync();
        }
        public virtual async Task Atualizar(Ponto model)
        {
            await Database.UpdateAsync(model);

        }
        //public virtual async Task Deletar(long id)
        //{
        //    await Database.Table<Ponto>().DeleteAsync(obj => obj.Id == id);

        //}

    }
}
