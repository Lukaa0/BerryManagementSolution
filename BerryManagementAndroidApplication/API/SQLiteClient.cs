using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BerryManagementAndroidApplication.Model;
using SQLite;

namespace BerryManagementAndroidApplication.API
{
    public class SQLiteClient<T> where T : new()
    {
        private SQLiteAsyncConnection connection;
        readonly string basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        private readonly string path;
        public string DbName { get; set; }

        public SQLiteClient()
        {
            DbName = typeof(T).Name;
            path = Path.Combine(basePath, DbName);
            connection = new SQLiteAsyncConnection(path);
           
        }

        public async Task<bool> CreateTableAsync()
        {

            try
            {
                await connection.CreateTableAsync<T>();
                return true;
                
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async System.Threading.Tasks.Task<int> insertUpdateDataAsync(T obj, bool contains)
        {

            if (!contains)
                
                return await connection.InsertAsync(obj);
            else
                return await connection.UpdateAsync(obj);
        }
        public async System.Threading.Tasks.Task<int> InsertOrReplaceAsync(T obj)
        {

            return await connection.InsertOrReplaceAsync(obj);
        }

        public async System.Threading.Tasks.Task<int> InsertAllAsnyc(IEnumerable<T> objects)
        {
            return await connection.InsertAllAsync(objects);
        }

        public Task<List<T>> selectItems()
        {
            using (var db = new SQLiteConnection(path))
            {
                var s =  connection.Table<T>().ToListAsync();
                return s;

            }
        }

        public async  Task<T> GetFirst()
        {
            var result = new T();
            try
            {
                using (var db = new SQLiteConnection(path))
                {
                    AsyncTableQuery<T> asyncTableQuery = connection.Table<T>();
                    if (asyncTableQuery != null)
                    {
                        result = await asyncTableQuery.FirstOrDefaultAsync();
                        return result;
                    }
                }
            }
            catch
            {
               
            }
            return result;
        }

        public async Task<int> UpdateLocationState(T obj)
        {
            using (var db = new SQLiteConnection(path))
            {
                return await connection.UpdateAsync(obj);

            }
        }

        public async Task InsertOrUpdateState(LocationAuthorizationState locState)
        {
            using (var db = new SQLiteConnection(path))
            {
                var state =  await connection.Table<T>().FirstOrDefaultAsync();
                if (state == null)
                    await connection.InsertAsync(locState);
                else
                    await connection.UpdateAsync(locState);
            }
        }

        public async Task DeleteAll()
        {
            using (var db = new SQLiteConnection(path))
            {
                await connection.DeleteAllAsync<T>();

            }
        }

        public async Task<int> DeleteAsync(T favObj)
        {
            using (var db = new SQLiteConnection(path))
            {
                return await connection.DeleteAsync(favObj);

            }
        }

        public async Task<T> GetById(string pk)
        {
            using (var db = new SQLiteConnection(path))
            {
                return await connection.GetAsync<T>(pk);
            }
        }

        public async Task<int> DeleteByDirection(bool condition)
        {
            using (var db = new SQLiteConnection(path))
            {
                int cond = condition ? 1 : 0;
                return await connection.ExecuteAsync("DELETE from " + DbName + " WHERE Direction=?", cond);

            }
        }
        public async Task<int> DeleteByDirection(bool condition,string contentType)
        {
            using (var db = new SQLiteConnection(path))
            {
                int cond = condition ? 1 : 0;
                return await connection.ExecuteAsync("DELETE from " + DbName + " WHERE Direction=? AND ContentType=?", cond,contentType);

            }
        }
        
        public async Task<int> DeleteByCompletionAsync(bool condition)
        {
            using (var db = new SQLiteConnection(path))
            {
                int cond = condition ? 1 : 0;

                return await connection.ExecuteAsync("DELETE from " + DbName + " WHERE Direction=? AND IsComplete=1 AND (Error is null or Error = '')", cond);

            }
        }
        public async Task<int> DeleteByCompletionAsync()
        {
            using (var db = new SQLiteConnection(path))
            {
                return await connection.ExecuteAsync("DELETE from " + DbName + " WHERE IsComplete=1 AND (Error is null or Error = '')");

            }
        }
        public async Task<int> DeleteByCompletionAsync(string contentType)
        {
            using (var db = new SQLiteConnection(path))
            {
                return await connection.ExecuteAsync(
                    "DELETE from " + DbName + " WHERE IsComplete=1 AND (Error is null or Error = '') AND ContentType=?",
                    contentType);

            }
        }
        public async Task<int> DeleteByContentType(string contentType)
        {
            using (var db = new SQLiteConnection(path))
            {
                return await connection.ExecuteAsync(
                    "DELETE from " + DbName + " WHERE ContentType=?",
                    contentType);

            }
        }
    }
}