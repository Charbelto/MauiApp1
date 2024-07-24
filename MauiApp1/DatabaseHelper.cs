using System;
using System.IO;
using System.Threading.Tasks;
using SQLite;

namespace MauiApp1
{
    public class DatabaseHelper
    {
        readonly SQLiteAsyncConnection _database;

        public DatabaseHelper(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait(); // Ensure table is created
        }

        public async Task<User> GetUserAsync(int userId)
        {
            try
            {
                return await _database.Table<User>()
                    .Where(u => u.ID == userId)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving user: {ex.Message}");
                return null;
            }
        }

        public async Task<int> UpdateUserAsync(User user)
        {
            try
            {
                return await _database.UpdateAsync(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
                return -1;
            }
        }
        public async Task<int> InsertUserAsync(User user)
        {
            try
            {
                return await _database.InsertAsync(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting user: {ex.Message}");
                return -1;
            }
            // Add other methods as needed


        }
        public async Task<User> GetUserAsync(string username, string password)
        {
            try
            {
                return await _database.Table<User>()
                    .Where(u => u.Username == username && u.Password == password)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving user: {ex.Message}");
                return null;
            }
        }

    }
}
