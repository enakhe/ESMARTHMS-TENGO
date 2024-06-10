using ESMART_HMS.Models;
using ESMART_HMS.Repositories;
using System;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace ESMART_HMS
{
    public static class DatabaseHelper
    {
        //private static string connectionString = @"Data Source=..\..\Files\HotelManagementSystem.db;Version=3;";

        //public static void InitializeDatabase()
        //{
        //    try
        //    {

        //        if (!File.Exists(@"..\..\Files\HotelManagementSystem.db"))
        //        {
        //            SQLiteConnection.CreateFile(@"..\..\Files\HotelManagementSystem.db");
        //            using (var connection = new SQLiteConnection(connectionString))
        //            {
        //                connection.Open();

        //                // Create tables for data
        //                string createApplicationUsersTableQuery = @"
        //                   CREATE TABLE IF NOT EXISTS Users (
        //                           Id INTEGER PRIMARY KEY AUTOINCREMENT,
        //                           UserId TEXT NOT NULL,
        //                           Username TEXT NOT NULL,
        //                           PasswordHash TEXT NOT NULL,
        //                           FirstName TEXT NOT NULL,
        //                           LastName TEXT NOT NULL,
        //                           Email TEXT UNIQUE NOT NULL,
        //                           PhoneNumber TEXT NOT NULL,
        //                           DateCreated DATETIME DEFAULT CURRENT_TIMESTAMP,
        //                           DateModified DATETIME DEFAULT CURRENT_TIMESTAMP
        //                  );";

        //                string createCustomersTableQuery = @"
        //                   CREATE TABLE IF NOT EXISTS Customers (
        //                           Id INTEGER PRIMARY KEY AUTOINCREMENT,
        //                           CustomerId TEXT NOT NULL,
        //                           Title TEXT NOT NULL,
        //                           FirstName TEXT NOT NULL,
        //                           LastName TEXT NOT NULL,
        //                           Email TEXT UNIQUE NOT NULL,
        //                           City TEXT NOT NULL,
        //                           State TEXT NOT NULL,
        //                           Country TEXT NOT NULL,
        //                           PhoneNumber TEXT NOT NULL,
        //                           MembershipStatus TEXT NOT NULL,
        //                           DateCreated DATETIME DEFAULT CURRENT_TIMESTAMP,
        //                           DateModified DATETIME DEFAULT CURRENT_TIMESTAMP
        //                   );";


        //                using (var command = new SQLiteCommand(connection))
        //                {
        //                    command.CommandText = createApplicationUsersTableQuery;
        //                    command.ExecuteNonQuery();

        //                    command.CommandText = createCustomersTableQuery;
        //                    command.ExecuteNonQuery();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log error
        //        File.WriteAllText("error_log.txt", ex.ToString());
        //    }
            
        //}

        public static void AddSampleUser() 
        {
            User user = new User();

            user.UserName = "SuperAdmin";
            user.FirstName = "";
            user.LastName = "";
            user.FullName = "";
            user.Email = "";
            user.PhoneNumber = "";
            user.PasswordHash = "Admin123";
            user.DateCreated = DateTime.Now;
            user.DateModified = DateTime.Now;

            using (ESMART_HMSDBEntities db = new ESMART_HMSDBEntities())
            {
                var foundUser = db.Users.FirstOrDefault(u => u.UserName == user.UserName);
                if (foundUser == null)
                {
                    UserRepository userRepository = new UserRepository(db);
                    userRepository.AddUser(user);
                }
                
            }

            //using (SQLiteConnection connection = new SQLiteConnection(connectionString)) 
            //{
            //    connection.Open();

                

            //    using (SQLiteCommand command = new SQLiteCommand(connection))
            //    {
            //        command.CommandText =
            //            @"
            //                WITH UserExists AS (
            //                    SELECT 1 FROM Users WHERE Email = @Email
            //                )
            //                INSERT INTO Users (UserId, Username, PasswordHash, FirstName, LastName, Email, PhoneNumber, DateCreated, DateModified)
            //                SELECT @UserId, @Username, @PasswordHash, @FirstName, @LastName, @Email, @PhoneNumber, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP
            //                WHERE NOT EXISTS (SELECT 1 FROM UserExists);";

            //        command.Parameters.AddWithValue("@UserId", userId);
            //        command.Parameters.AddWithValue("@Username", username);
            //        command.Parameters.AddWithValue("@FirstName", firstName);
            //        command.Parameters.AddWithValue("@LastName", lastName);
            //        command.Parameters.AddWithValue("@Email", email);
            //        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
            //        command.Parameters.AddWithValue("@PasswordHash", password);
            //        command.Parameters.AddWithValue("@DateCreated", dateCreated);
            //        command.Parameters.AddWithValue("@DateModified", dateModified);


            //        command.ExecuteNonQuery();
            //        command.Parameters.Clear();
            //    }
            //}
        }
    }
}
