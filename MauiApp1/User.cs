using SQLite;

namespace MauiApp1
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string? Username { get; set; }  // Make Username nullable
        public string? Password { get; set; }  // Make Password nullable
        public string? ImagePath { get; set; }
        public static int CurrentUserId { get; set; }

    }
}
