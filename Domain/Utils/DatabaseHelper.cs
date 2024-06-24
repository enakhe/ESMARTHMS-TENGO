using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Infrastructure.Data;
using System;
using System.Data.SqlClient;
using System.Linq;

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

                CreateTable("User",
                    "[Id][nvarchar](450) NOT NULL, " +
                    "[UserId][nvarchar](450) NOT NULL, " +
                    "[FirstName][nvarchar](max) NOT NULL, " +
                    "[LastName][nvarchar](max) NOT NULL, " +
                    "[FullName][nvarchar](max) NOT NULL, " +
                    "[UserName][nvarchar](256) NOT NULL, " +
                    "[Email][nvarchar](256) NULL," +
                    "[PasswordHash][nvarchar](max) NOT NULL, " +
                    "[PhoneNumber][nvarchar](max) NULL, " +
                    "[DateCreated][datetime2](7) NOT NULL, " +
                    "[DateModified][datetime2](7) NOT NULL, " +
                    "[IsTrashed][bit] NOT NULL," +
                    "CONSTRAINT[PK_User] PRIMARY KEY CLUSTERED ( [Id] ASC )");

                CreateTable("RoomType",
                    "[Id] [nvarchar](450) NOT NULL," +
                    "[RoomTypeId][nvarchar](450) NOT NULL," +
                    "[Title][nvarchar](max) NOT NULL," +
                    "[DateCreated][datetime2](7) NOT NULL," +
                    "[DateModified][datetime2](7) NOT NULL," +
                    "[IsTrashed][bit] NOT NULL," +
                    "CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED([Id] ASC)");

                CreateTable("Room",
                    "[Id][nvarchar](450) NOT NULL," +
                    "[RoomId][nvarchar](450) NOT NULL," +
                    "[RoomNo][nvarchar](max) NOT NULL," +
                    "[RoomCardNo][nvarchar](max) NOT NULL," +
                    "[RoomLockNo][nvarchar](max) NOT NULL," +
                    "[RoomTypeId][nvarchar](450) NOT NULL," +
                    "[AdultPerRoom][int] NOT NULL," +
                    "[ChildrenPerRoom][int] NOT NULL," +
                    "[Description][nvarchar](max) NULL," +
                    "[Rate][decimal](10, 2) NOT NULL," +
                    "[Status][nvarchar](450) NOT NULL," +
                    "[DateCreated][datetime2](7) NOT NULL," +
                    "[DateModified][datetime2](7) NOT NULL, " +
                    "[IsTrashed][bit] NOT NULL," +
                    "FOREIGN KEY (RoomTypeId) REFERENCES RoomType(Id), " +
                    "CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED([Id] ASC)");

                CreateTable("Customer",
                    "[Id][nvarchar](450) NOT NULL," +
                    "[CustomerId][nvarchar](450) NOT NULL," +
                    "[Title][nvarchar](50) NOT NULL," +
                    "[FirstName][nvarchar](max) NOT NULL," +
                    "[LastName][nvarchar](max) NOT NULL," +
                    "[FullName][nvarchar](max) NOT NULL," +
                    "[Email][nvarchar](256) NOT NULL," +
                    "[PhoneNumber][nvarchar](max) NOT NULL," +
                    "[Street][nvarchar](max) NULL," +
                    "[City][nvarchar](max) NULL," +
                    "[Company][nvarchar](max) NULL," +
                    "[State][nvarchar](max) NULL," +
                    "[Country][nvarchar](max) NULL," +
                    "[Gender][nvarchar](50) NOT NULL," +

                    "[IdNumber][nvarchar](450) NULL," +
                    "[IdType][nvarchar](450) NULL," +
                    "[IdentificationDocumentFront][varbinary] (max) NULL," +
                    "[IdentificationDocumentBack][varbinary] (max) NULL," +
                    "[CustomerImage][varbinary] (max) NULL," +
                    "[DateCreated][datetime2](7) NOT NULL," +
                    "[DateModified][datetime2](7) NOT NULL," +
                    "[IsTrashed][bit] NOT NULL," +
                    "CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Id] ASC)");

                CreateTable("Reservation",
                    "[Id][nvarchar](450) NOT NULL," +
                    "[ReservationId][nvarchar](450) NOT NULL," +
                    "[CustomerId][nvarchar](450) NOT NULL," +
                    "[RoomId][nvarchar](450) NOT NULL," +
                    "[CheckInDate][datetime2](7) NOT NULL," +
                    "[CheckOutDate][datetime2](7) NOT NULL," +
                    "[PaymentMethod][nvarchar](450) NOT NULL," +
                    "[Amount][decimal](10, 2) NOT NULL," +
                    "[DateCreated][datetime2](7) NOT NULL," +
                    "[DateModified][datetime2](7) NOT NULL," +
                    "[IsTrashed][bit] NOT NULL," +
                    "FOREIGN KEY (CustomerId) REFERENCES Customer(Id), " +
                    "FOREIGN KEY (RoomId) REFERENCES Room(Id), " +
                    "CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED ([Id] ASC)");
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
