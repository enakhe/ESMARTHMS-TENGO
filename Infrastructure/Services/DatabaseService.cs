using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Infrastructure.Data;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace ESMART_HMS.Infrastructure.Services
{
    public static class DatabaseService
    {
        private static readonly string connectionString = @"data source=localhost;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True";

        public static void InitializeDatabase()
        {
            if (!DatabaseExists())
            {
                CreateDatabase();
            }

            EnsureTablesExist();
        }

        private static bool DatabaseExists()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT COUNT(*) FROM sys.databases WHERE name = 'ESMART_HMSDB'";
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
                command.CommandText = $"CREATE DATABASE ESMART_HMSDB";
                command.ExecuteNonQuery();
            }
        }

        private static void EnsureTablesExist()
        {
            CreateTableIfNotExists("ApplicationUser",
                    "[Id][nvarchar](450) NOT NULL," +
                    "[UserId][nvarchar](450) NOT NULL," +
                    "[FirstName][nvarchar](max) NOT NULL," +
                    "[LastName][nvarchar](max) NOT NULL," +
                    "[FullName][nvarchar](max) NOT NULL," +
                    "[UserName][nvarchar](256) NOT NULL," +
                    "[Email][nvarchar](256) NULL," +
                    "[PasswordHash][nvarchar](max) NOT NULL," +
                    "[PhoneNumber][nvarchar](max) NULL," +
                    "[DateCreated][datetime2](7) NOT NULL," +
                    "[DateModified][datetime2](7) NOT NULL," +
                    "[IsTrashed][bit] NOT NULL," +
                    "CONSTRAINT[PK_ApplicationUser] PRIMARY KEY CLUSTERED ([Id] ASC)");

            CreateTableIfNotExists("Role",
                "[Id][nvarchar](450) NOT NULL," +
                "[RoleId][nvarchar](450) NOT NULL," +
                "[Title][nvarchar](450) NOT NULL," +
                "[Description][nvarchar](max) NULL," +
                "[DateCreated][datetime2](7) NOT NULL," +
                "[DateModified][datetime2](7) NOT NULL," +
                "[IsTrashed][bit] NOT NULL," +
                "CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([Id] ASC)");

            CreateTableIfNotExists("ApplicationUserRole",
                "[Id][nvarchar](450) NOT NULL," +
                "[UserRoleId][nvarchar](450) NOT NULL," +
                "[UserId][nvarchar](450) NOT NULL," +
                "[RoleId][nvarchar](450) NOT NULL," +
                "[DateCreated][datetime2](7) NOT NULL," +
                "[DateModified][datetime2](7) NOT NULL," +
                "[IsTrashed][bit] NOT NULL," +
                "FOREIGN KEY (UserId) REFERENCES ApplicationUser(Id)," +
                "FOREIGN KEY (RoleId) REFERENCES Role(Id)," +
                "CONSTRAINT [PK_ApplicationUserRole] PRIMARY KEY CLUSTERED ([Id] ASC)");

            CreateTableIfNotExists("Permission",
                "[Id][nvarchar](450) NOT NULL," +
                "[PermissionId][nvarchar](450) NOT NULL," +
                "[Title][nvarchar](450) NOT NULL," +
                "[DateCreated][datetime2](7) NOT NULL," +
                "[DateModified][datetime2](7) NOT NULL," +
                "[IsTrashed][bit] NOT NULL," +
                "CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED ([Id] ASC)");

            CreateTableIfNotExists("RolePermission",
                "[Id][nvarchar](450) NOT NULL," +
                "[RoleId][nvarchar](450) NOT NULL," +
                "[PermissionId][nvarchar](450) NOT NULL," +
                "[DateCreated][datetime2](7) NOT NULL," +
                "[DateModified][datetime2](7) NOT NULL," +
                "[IsTrashed][bit] NOT NULL," +
                "FOREIGN KEY (RoleId) REFERENCES Role(Id)," +
                "FOREIGN KEY (PermissionId) REFERENCES Permission(Id)," +
                "CONSTRAINT [PK_RolePermission] PRIMARY KEY CLUSTERED ([Id] ASC)");

            CreateTableIfNotExists("RoomType",
                "[Id] [nvarchar](450) NOT NULL," +
                "[RoomTypeId][nvarchar](450) NOT NULL," +
                "[Title][nvarchar](max) NOT NULL," +
                "[DateCreated][datetime2](7) NOT NULL," +
                "[DateModified][datetime2](7) NOT NULL," +
                "[IsTrashed][bit] NOT NULL," +
                "CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED([Id] ASC)");

            CreateTableIfNotExists("Building",
                "[Id] [nvarchar](450) NOT NULL," +
                "[BuildingName][nvarchar](450) NOT NULL," +
                "[BuildingNo][nvarchar](max) NOT NULL," +
                "[Remark][nvarchar](max) NOT NULL," +
                "[DateCreated][datetime2](7) NOT NULL," +
                "[DateModified][datetime2](7) NOT NULL," +
                "[IsTrashed][bit] NOT NULL," +
                "CONSTRAINT [PK_Building] PRIMARY KEY CLUSTERED([Id] ASC)");

            CreateTableIfNotExists("Floor",
                "[Id] [nvarchar](450) NOT NULL," +
                "[FloorNo][nvarchar](450) NOT NULL," +
                "[Remark][nvarchar](max) NOT NULL," +
                "[BuildingId][nvarchar](450) NOT NULL," +
                "[DateCreated][datetime2](7) NOT NULL," +
                "[DateModified][datetime2](7) NOT NULL," +
                "[IsTrashed][bit] NOT NULL," +
                "FOREIGN KEY (BuildingId) REFERENCES Building(Id)," +
                "CONSTRAINT [PK_Floor] PRIMARY KEY CLUSTERED([Id] ASC)");

            CreateTableIfNotExists("Area",
                "[Id] [nvarchar](450) NOT NULL," +
                "[AreaName][nvarchar](450) NOT NULL," +
                "[AreaNo][nvarchar](max) NOT NULL," +
                "[Remark][nvarchar](max) NOT NULL," +
                "[DateCreated][datetime2](7) NOT NULL," +
                "[DateModified][datetime2](7) NOT NULL," +
                "[IsTrashed][bit] NOT NULL," +
                "CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED([Id] ASC)");

            CreateTableIfNotExists("Room",
                "[Id][nvarchar](450) NOT NULL," +
                "[RoomId][nvarchar](450) NOT NULL," +
                "[RoomNo][nvarchar](max) NOT NULL," +
                "[RoomTypeId][nvarchar](450) NOT NULL," +
                "[BuildingId][nvarchar](450) NOT NULL," +
                "[FloorId][nvarchar](450) NOT NULL," +
                "[AreaId][nvarchar](450) NOT NULL," +
                "[AdultPerRoom][int] NOT NULL," +
                "[ChildrenPerRoom][int] NOT NULL," +
                "[Description][nvarchar](max) NULL," +
                "[Rate][decimal](10, 2) NOT NULL," +
                "[Status][nvarchar](450) NOT NULL," +
                "[CreatedBy][nvarchar](450) NOT NULL," +
                "[DateCreated][datetime2](7) NOT NULL," +
                "[DateModified][datetime2](7) NOT NULL," +
                "[IsTrashed][bit] NOT NULL," +
                "FOREIGN KEY (RoomTypeId) REFERENCES RoomType(Id)," +
                "FOREIGN KEY (BuildingId) REFERENCES Building(Id)," +
                "FOREIGN KEY (FloorId) REFERENCES Floor(Id)," +
                "FOREIGN KEY (AreaId) REFERENCES Area(Id)," +
                "FOREIGN KEY (CreatedBy) REFERENCES ApplicationUser(Id)," +
                "CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED([Id] ASC)");

            CreateTableIfNotExists("Guest",
                "[Id][nvarchar](450) NOT NULL," +
                "[GuestId][nvarchar](450) NOT NULL," +
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
                "[GuestImage][varbinary] (max) NULL," +
                "[CreatedBy][nvarchar](450) NOT NULL," +
                "[DateCreated][datetime2](7) NOT NULL," +
                "[DateModified][datetime2](7) NOT NULL," +
                "[IsTrashed][bit] NOT NULL," +
                "FOREIGN KEY (CreatedBy) REFERENCES ApplicationUser(Id), " +
                "CONSTRAINT [PK_Guest] PRIMARY KEY CLUSTERED ([Id] ASC)");

            CreateTableIfNotExists("Reservation",
                "[Id][nvarchar](450) NOT NULL," +
                "[ReservationId][nvarchar](450) NOT NULL," +
                "[GuestId][nvarchar](450) NOT NULL," +
                "[RoomId][nvarchar](450) NOT NULL," +
                "[CheckInDate][datetime2](7) NOT NULL," +
                "[CheckOutDate][datetime2](7) NOT NULL," +
                "[PaymentMethod][nvarchar](450) NOT NULL," +
                "[Amount][decimal](10, 2) NOT NULL," +
                "[AmountPaid][decimal](10, 2) NOT NULL," +
                "[Status][nvarchar](450) NOT NULL," +
                "[CreatedBy][nvarchar](450) NOT NULL," +
                "[DateCreated][datetime2](7) NOT NULL," +
                "[DateModified][datetime2](7) NOT NULL," +
                "[IsTrashed][bit] NOT NULL," +
                "FOREIGN KEY (GuestId) REFERENCES Guest(Id), " +
                "FOREIGN KEY (RoomId) REFERENCES Room(Id), " +
                "FOREIGN KEY (CreatedBy) REFERENCES ApplicationUser(Id), " +
                "CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED ([Id] ASC)");

            CreateTableIfNotExists("Booking",
                "[Id][nvarchar](450) NOT NULL," +
                "[BookingId][nvarchar](450) NOT NULL," +
                "[GuestId][nvarchar](450) NOT NULL," +
                "[RoomId][nvarchar](450) NOT NULL," +
                "[ReservationId][nvarchar](450) NULL," +
                "[CheckInDate][datetime2](7) NOT NULL," +
                "[CheckOutDate][datetime2](7) NOT NULL," +
                "[PaymentMethod][nvarchar](450) NOT NULL," +
                "[Amount][decimal](10, 2) NOT NULL," +
                "[NoOfPerson][int] NOT NULL," +
                "[Duration][int] NOT NULL," +
                "[Discount][decimal](10, 2) NOT NULL," +
                "[VAT][decimal](10, 2) NOT NULL," +
                "[TotalAmount][decimal](10, 2) NOT NULL," +
                "[CreatedBy][nvarchar](450) NOT NULL," +
                "[DateCreated][datetime2](7) NOT NULL," +
                "[DateModified][datetime2](7) NOT NULL," +
                "[IsTrashed][bit] NOT NULL," +
                "FOREIGN KEY (GuestId) REFERENCES Guest(Id), " +
                "FOREIGN KEY (RoomId) REFERENCES Room(Id), " +
                "FOREIGN KEY (CreatedBy) REFERENCES ApplicationUser(Id), " +
                "CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED ([Id] ASC)");

            CreateTableIfNotExists("Transaction",
                "[Id][nvarchar](450) NOT NULL," +
                "[TransactionId][nvarchar](450) NOT NULL," +
                "[GuestId][nvarchar](450) NOT NULL," +
                "[ServiceId][nvarchar](450) NOT NULL," +
                "[Date][datetime2](7) NOT NULL," +
                "[BankAccount][nvarchar](450) NULL," +
                "[Amount][decimal](10, 2) NOT NULL," +
                "[Status][nvarchar](450) NULL," +
                "[Description][nvarchar](max) NULL," +
                "[Type][nvarchar](50) NULL," +
                "[IsTrashed][bit] NOT NULL," +
                "FOREIGN KEY (GuestId) REFERENCES Guest(Id), " +
                "CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED ([Id] ASC)");

            CreateTableIfNotExists("Invoice",
                "[Id][nvarchar](450) NOT NULL," +
                "[InvoiceId][nvarchar](450) NOT NULL," +
                "[GuestId][nvarchar](450) NOT NULL," +
                "[BookingId][nvarchar](450) NOT NULL," +
                "[Date][datetime2](7) NOT NULL," +
                "[TotalAmount][decimal](10, 2) NOT NULL," +
                "[VATAmount][decimal](10, 2) NULL," +
                "[Status][nvarchar](50) NULL," +
                "[IsTrashed][bit] NOT NULL," +
                "FOREIGN KEY (GuestId) REFERENCES Guest(Id), " +
                "FOREIGN KEY (BookingId) REFERENCES Booking(Id), " +
                "CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED ([Id] ASC)");

            CreateTableIfNotExists("BarItem",
                "[Id][nvarchar](450) NOT NULL," +
                "[BarItemId][nvarchar](450) NOT NULL," +
                "[Barcode][nvarchar](max) NOT NULL," +
                "[ItemName][nvarchar](max) NOT NULL," +
                "[CostPrice][decimal](10, 2) NOT NULL," +
                "[SellingPrice][decimal](10, 2) NULL," +
                "[Quantity][int] NOT NULL," +
                "[Type][nvarchar](450) NOT NULL," +
                "[Measurement][nvarchar](450) NOT NULL," +
                "[CreatedBy][nvarchar](450) NOT NULL," +
                "[IsTrashed][bit] NOT NULL," +
                "[DateCreated][datetime2](7) NOT NULL," +
                "[DateModified][datetime2](7) NOT NULL," +
                "FOREIGN KEY (CreatedBy) REFERENCES ApplicationUser(Id), " +
                "CONSTRAINT [PK_BarItem] PRIMARY KEY CLUSTERED ([Id] ASC)");

            CreateTableIfNotExists("Order",
                "[Id][nvarchar](450) NOT NULL," +
                "[OrderId][nvarchar](450) NOT NULL," +
                "[ItemId][nvarchar](450) NOT NULL," +
                "[Quantity][int] NOT NULL," +
                "[TotalAmount][decimal](10, 2) NULL," +
                "[IsTrashed][bit] NOT NULL," +
                "[CustomerId][nvarchar](450)NOT NULL," +
                "[IssuedBy][nvarchar](450) NOT NULL," +
                "[DateCreated][datetime2](7) NOT NULL," +
                "[DateModified][datetime2](7) NOT NULL," +
                "FOREIGN KEY (IssuedBy) REFERENCES ApplicationUser(Id), " +
                "FOREIGN KEY (CustomerId) REFERENCES Guest(Id), " +
                "FOREIGN KEY (ItemId) REFERENCES BarItem(Id), " +
                "CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id] ASC)");

            CreateTableIfNotExists("IngredientItem",
                "[Id][nvarchar](450) NOT NULL," +
                "[IngredientItemId][nvarchar](450) NOT NULL," +
                "[Name][nvarchar](450) NOT NULL," +
                "[IsTrashed][bit] NOT NULL," +
                "[CreatedBy][nvarchar](450) NOT NULL," +
                "[DateCreated][datetime2](7) NOT NULL," +
                "[DateModified][datetime2](7) NOT NULL," +
                "FOREIGN KEY (CreatedBy) REFERENCES ApplicationUser(Id), " +
                "CONSTRAINT [PK_IngredientItem] PRIMARY KEY CLUSTERED ([Id] ASC)");

            CreateTableIfNotExists("CompanyInformation",
                "[Id][nvarchar](450) NOT NULL," +
                "[CompanyId][nvarchar](450) NOT NULL," +
                "[Name][nvarchar](450) NULL," +
                "[AddressLine1][nvarchar](max) NULL," +
                "[AddressLine2][nvarchar](max) NULL," +
                "[PhoneNumber][nvarchar](450) NULL," +
                "[Email][nvarchar](450) NULL," +
                "[WebsiteURL][nvarchar](450) NULL," +
                "[TaxNumber][nvarchar](450) NULL," +
                "[NoOfEmployees][nvarchar](450) NULL," +
                "[Logo][varbinary](max) NULL," +
                "[DateCreated][datetime2](7) NOT NULL," +
                "[DateModified][datetime2](7) NOT NULL," +
                "CONSTRAINT [PK_CompanyInformation] PRIMARY KEY CLUSTERED ([Id] ASC)");

            CreateTableIfNotExists("BankAccount",
                "[Id][nvarchar](450) NOT NULL," +
                "[BankAccNo][nvarchar](450) NOT NULL," +
                "[BankName][nvarchar](450) NULL," +
                "[BankAccName][nvarchar](450) NULL," +
                "[IsTrashed][bit] NOT NULL," +
                "[CreatedBy][nvarchar](450) NOT NULL," +
                "[DateCreated][datetime2](7) NOT NULL," +
                "[DateModified][datetime2](7) NOT NULL," +
                "FOREIGN KEY (CreatedBy) REFERENCES ApplicationUser(Id), " +
                "CONSTRAINT [PK_BankAccount] PRIMARY KEY CLUSTERED ([Id] ASC)");

            CreateTableIfNotExists("AuthorizationCard",
                "[Id][nvarchar](450) NOT NULL," +
                "[ComputerName][nvarchar](450) NOT NULL," +
                "[AuthId][nvarchar](450) NULL," +
                "[IsTrashed][bit] NOT NULL," +
                "[CreatedBy][nvarchar](450) NOT NULL," +
                "[DateCreated][datetime2](7) NOT NULL," +
                "[DateModified][datetime2](7) NOT NULL," +
                "FOREIGN KEY (CreatedBy) REFERENCES ApplicationUser(Id), " +
                "CONSTRAINT [PK_AuthorizationCard] PRIMARY KEY CLUSTERED ([Id] ASC)");

            CreateTableIfNotExists("SpecialCard",
                "[Id][nvarchar](450) NOT NULL," +
                "[CardNo][nvarchar](450) NOT NULL," +
                "[CardType][nvarchar](450) NULL," +
                "[IssueTime][datetime2](7) NOT NULL," +
                "[RefundTime][datetime2](7) NOT NULL," +
                "[IssuedBy][nvarchar](450) NOT NULL," +
                "[CanOpenDeadLocks][bit] NOT NULL," +
                "[PassageMode][bit] NOT NULL," +
                "[IsTrashed][bit] NOT NULL," +
                "[DateCreated][datetime2](7) NOT NULL," +
                "[DateModified][datetime2](7) NOT NULL," +
                "FOREIGN KEY (IssuedBy) REFERENCES ApplicationUser(Id), " +
                "CONSTRAINT [PK_SpecialCard] PRIMARY KEY CLUSTERED ([Id] ASC)");

            CreateTableIfNotExists("GuestCard",
                "[Id][nvarchar](450) NOT NULL," +
                "[CardNo][nvarchar](450) NOT NULL," +
                "[CardType][nvarchar](450) NULL," +
                "[IssueTime][datetime2](7) NOT NULL," +
                "[RefundTime][datetime2](7) NOT NULL," +
                "[IssuedBy][nvarchar](450) NOT NULL," +
                "[CanOpenDeadLocks][bit] NOT NULL," +
                "[PassageMode][bit] NOT NULL," +
                "[IsTrashed][bit] NOT NULL," +
                "[DateCreated][datetime2](7) NOT NULL," +
                "[DateModified][datetime2](7) NOT NULL," +
                "FOREIGN KEY (IssuedBy) REFERENCES ApplicationUser(Id), " +
                "CONSTRAINT [PK_GuestCard] PRIMARY KEY CLUSTERED ([Id] ASC)");

            CreateTableIfNotExists("LicenseInfo",
                "[Id][nvarchar](450) NOT NULL," +
                "[HotelName][nvarchar](450) NOT NULL," +
                "[ProductKey][nvarchar](450) NULL," +
                "[ExpiryDate][datetime2](7) NOT NULL," +
                "[DateCreated][datetime2](7) NOT NULL," +
                "[DateModified][datetime2](7) NOT NULL," +
                "CONSTRAINT [PK_LicenseInfo] PRIMARY KEY CLUSTERED ([Id] ASC)");

            CreateTableIfNotExists("Configuration",
                "[Key][nvarchar](450) NOT NULL," +
                "[Value][nvarchar](450) NOT NULL," +
                "CONSTRAINT [PK_Configuration] PRIMARY KEY CLUSTERED ([Key] ASC)");
        }

        private static void CreateTableIfNotExists(string tableName, string tableDefinition)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $@"
                    USE ESMART_HMSDB;
                    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = '{tableName}')
                    BEGIN
                        CREATE TABLE [{tableName}] ({tableDefinition})
                    END";
                command.ExecuteNonQuery();
            }
        }

        public static void SeedData()
        {
            SeedUser();
            SeedRole();
            SeedUserToRole();
            SeedVAT();
            SeedDiscount();
        }

        public static void SeedUser()
        {
            using (ESMART_HMSDBEntities db = new ESMART_HMSDBEntities())
            {
                var foundUser = db.ApplicationUsers.FirstOrDefault(u => u.UserName == "SuperAdmin");
                if (foundUser == null)
                {
                    ApplicationUser user = new ApplicationUser
                    {
                        UserName = "SuperAdmin",
                        FirstName = "",
                        LastName = "",
                        FullName = "Super Admin",
                        Email = "",
                        PhoneNumber = "",
                        PasswordHash = "Admin123",
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    };
                    UserRepository userRepository = new UserRepository(db);
                    userRepository.AddUser(user);
                    db.SaveChanges();
                    SeedAnonymous(user.Id);
                }
            }
        }


        public static void SeedAnonymous(string appUser)
        {
            using (ESMART_HMSDBEntities db = new ESMART_HMSDBEntities())
            {
                var foundGuest = db.Guests.FirstOrDefault(g => g.GuestId == "ANO");
                if (foundGuest == null)
                {
                    Guest guest = new Guest
                    {
                        Id = Guid.NewGuid().ToString(),
                        GuestId = "ANO",
                        Title = "Mr/Mrs",
                        FirstName = "",
                        LastName = "",
                        FullName = "Anonymous Guest",
                        Email = "",
                        PhoneNumber = "",
                        Gender = "Other",
                        CreatedBy = appUser,
                        IsTrashed = true,
                        ApplicationUser = db.ApplicationUsers.Find(appUser),
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    };

                    GuestRepository guestRepository = new GuestRepository(db);
                    guestRepository.AddGuest(guest);
                    db.SaveChanges();
                }
            }
        }


        public static void SeedRole()
        {
            Random random = new Random();

            Role role = new Role()
            {
                Id = Guid.NewGuid().ToString(),
                RoleId = "ROL" + random.Next(1000, 5000),
                Title = "SuperAdmin",
                Description = "SuperAdmin Role",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            using (ESMART_HMSDBEntities db = new ESMART_HMSDBEntities())
            {
                var foundRole = db.Roles.FirstOrDefault(r => r.Title == role.Title);
                if (foundRole == null)
                {
                    RoleRepository roleRepository = new RoleRepository(db);
                    roleRepository.AddRole(role);
                }
            }
        }

        public static void SeedUserToRole()
        {
            ESMART_HMSDBEntities db = new ESMART_HMSDBEntities();

            Random random = new Random();
            ApplicationUserRole userRole = new ApplicationUserRole()
            {
                Id = Guid.NewGuid().ToString(),
                UserRoleId = "USR" + random.Next(1000, 5000),
                Role = db.Roles.FirstOrDefault(r => r.Title == "SuperAdmin"),
                ApplicationUser = db.ApplicationUsers.FirstOrDefault(u => u.UserName == "SuperAdmin"),
                RoleId = db.Roles.FirstOrDefault(r => r.Title == "SuperAdmin").Id,
                UserId = db.ApplicationUsers.FirstOrDefault(r => r.UserName == "SuperAdmin").Id,
                IsTrashed = false,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
            };

            var foundUserRole = db.ApplicationUserRoles.FirstOrDefault(ur => ur.Role.Id == userRole.Role.Id && ur.ApplicationUser.Id == userRole.ApplicationUser.Id);
            if (foundUserRole == null)
            {
                UserRoleRepository userRoleRepository = new UserRoleRepository(db);
                userRoleRepository.AssignUserToRole(userRole);
            }
        }

        public static void SeedVAT()
        {
            Configuration vatConfiguration = new Configuration();
            vatConfiguration.Key = "VAT";
            vatConfiguration.Value = "0.00";
            using (ESMART_HMSDBEntities db = new ESMART_HMSDBEntities())
            {
                var foundVatConf = db.Configurations.FirstOrDefault(fv => fv.Key == "VAT");
                if (foundVatConf == null)
                {
                    ConfigurationRepository configurationRepository = new ConfigurationRepository(db);
                    configurationRepository.AddConfiguration(vatConfiguration);
                }
            }
        }

        public static void SeedDiscount()
        {
            Configuration vatConfiguration = new Configuration();
            vatConfiguration.Key = "Discount";
            vatConfiguration.Value = "0.00";
            using (ESMART_HMSDBEntities db = new ESMART_HMSDBEntities())
            {
                var foundVatConf = db.Configurations.FirstOrDefault(fv => fv.Key == "Discount");
                if (foundVatConf == null)
                {
                    ConfigurationRepository configurationRepository = new ConfigurationRepository(db);
                    configurationRepository.AddConfiguration(vatConfiguration);
                }
            }
        }

        public static void SeedTrialMode()
        {
            Configuration vatConfiguration = new Configuration();
            vatConfiguration.Key = "Trial Mode";
            vatConfiguration.Value = "False";
            using (ESMART_HMSDBEntities db = new ESMART_HMSDBEntities())
            {
                var foundVatConf = db.Configurations.FirstOrDefault(fv => fv.Key == "Trial Mode");
                if (foundVatConf == null)
                {
                    ConfigurationRepository configurationRepository = new ConfigurationRepository(db);
                    configurationRepository.AddConfiguration(vatConfiguration);
                }
            }
        }
    }
}
