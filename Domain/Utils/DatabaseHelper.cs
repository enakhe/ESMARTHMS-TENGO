using MaterialSkin;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ESMART_HMS
{
    public static class DatabaseHelper
    {
        private static readonly string connectionString = @"data source=localhost;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True";

        public static void InitializeDatabase()
        {
            if (!DatabaseExists())
            {
                CreateDatabase();
                CreateTable("User", "[Id][nvarchar](450) NOT NULL, [UserId][nvarchar](450) NOT NULL, [FirstName][nvarchar](max) NOT NULL, [LastName][nvarchar](max) NOT NULL, [FullName][nvarchar](max) NOT NULL, [UserName][nvarchar](256) NOT NULL, [Email][nvarchar](256) NULL,[PasswordHash][nvarchar](max) NOT NULL, [PhoneNumber][nvarchar](max) NULL, [DateCreated][datetime2](7) NOT NULL, [DateModified][datetime2](7) NOT NULL, CONSTRAINT[PK_User] PRIMARY KEY CLUSTERED ( [Id] ASC )");

                CreateTable("RoomType", "[Id] [nvarchar](450) NOT NULL,[RoomTypeId] [nvarchar](450) NOT NULL,[Title] [nvarchar](max) NOT NULL,[Description] [nvarchar](max) NOT NULL,[RateBase] [decimal](10,2) NOT NULL,[DateCreated] [datetime2](7) NOT NULL,[DateModified] [datetime2](7) NOT NULL,CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED([Id] ASC)");

                CreateTable("Room", "[Id] [nvarchar](450) NOT NULL,[RoomId] [nvarchar](450) NOT NULL,[RoomName] [nvarchar](max) NOT NULL,[RoomCardNo] [nvarchar](max) NOT NULL,[RoomLockNo] [nvarchar](max) NOT NULL,[RoomTypeId] [nvarchar](450) NOT NULL,[AdultPerRoom] [int] NOT NULL,[ChildrenPerRoom] [int] NOT NULL,[Description] [nvarchar](max) NOT NULL,[Rate] [decimal](10, 2) NOT NULL,[IsAvailable][bit] NOT NULL,[DateCreated] [datetime2](7) NOT NULL,[DateModified] [datetime2](7) NOT NULL, FOREIGN KEY (RoomTypeId) REFERENCES RoomType(Id), CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED([Id] ASC)");

                CreateTable("Customer", "[Id] [nvarchar](450) NOT NULL,[CustomerId] [nvarchar](450) NOT NULL,[Title] [nvarchar](max) NOT NULL,[FirstName] [nvarchar](max) NOT NULL,[LastName] [nvarchar](max) NOT NULL,[FullName] [nvarchar](max) NOT NULL,[Email] [nvarchar](256) NOT NULL,[PhoneNumber] [nvarchar](max) NOT NULL,[Street] [nvarchar](max) NOT NULL,[City] [nvarchar](max) NOT NULL,[Company] [nvarchar](max) NOT NULL,[State] [nvarchar](max) NOT NULL,[Country] [nvarchar](max) NOT NULL,[IdentificationDocument] [varbinary] (max) NULL,[IdentitificationDocumentName] [nvarchar](256) NULL,[DateCreated] [datetime2](7) NOT NULL,[DateModified] [datetime2](7) NOT NULL, CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Id] ASC)");
            }
        }

        private static bool DatabaseExists()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM sys.databases WHERE name = 'ESMART_HMSDB'";
                int result = (int)command.ExecuteScalar();
                return result > 0;
            }
        }

        private static void CreateDatabase()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "CREATE DATABASE ESMART_HMSDB";
                command.ExecuteNonQuery();
            }
        }

        private static void CreateTable(string tableName, string tableDefinition)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"USE ESMART_HMSDB; CREATE TABLE [{tableName}] ({tableDefinition})";
                command.ExecuteNonQuery();
            }
        }

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
        }
    }
}
