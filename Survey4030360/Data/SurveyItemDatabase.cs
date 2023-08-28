using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey4030360.Models;

namespace Survey4030360.Data
{
    public class SurveyItemDatabase
    {
        SQLiteAsyncConnection Database;
        public SurveyItemDatabase()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<SurveyItem>();
        }

        public async Task<List<SurveyItem>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<SurveyItem>().ToListAsync();
        }


        public async Task<SurveyItem> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<SurveyItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(SurveyItem item)
        {
            await Init();
            if (item.ID != 0)
            {
                return await Database.UpdateAsync(item);
            }
            else
            {
                return await Database.InsertAsync(item);
            }
        }

        public async Task<int> DeleteItemAsync(SurveyItem item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}