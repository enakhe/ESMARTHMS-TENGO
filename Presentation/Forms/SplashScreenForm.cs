using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using ESMART_HMS.Presentation.Sessions;
using System.Windows.Forms;
using ESMART_HMS.Presentation.Controllers;
using System.Collections.Generic;
using ESMART_HMS.Presentation.Middleware;
using ESMART_HMS.Presentation.Forms.RoleHome;

namespace ESMART_HMS.Presentation.Forms
{
    public partial class SplashScreenForm : Form
    {
        private Timer timer;
        private readonly LicenseController _licenseController;
        private readonly ApplicationUserController _applicationUserController;

        public SplashScreenForm(LicenseController licenseController, ApplicationUserController userController)
        {
            _licenseController = licenseController;
            _applicationUserController = userController;
            InitializeComponent();
            Shown += SplashScreenForm_Shown;
        }

        private async void SplashScreenForm_Shown(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            this.Hide();

            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            string hotelName, productKey;
            DateTime expirationDate;

            bool isLoaded = SecureFileHelper.TryLoadProductKey(out hotelName, out productKey, out expirationDate);

            if (isLoaded)
            {
                bool isValid = LicenceHelper.ValidateProductKey(hotelName, productKey);
                if (isValid)
                {
                    if (expirationDate > DateTime.Now)
                    {
                        var loginForm = serviceProvider.GetRequiredService<LoginForm>();
                        var loginResult = loginForm.ShowDialog();
                        if (loginResult == DialogResult.OK)
                        {
                            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);

                            if (AuthorizationMiddleware.IsInRole(user, "SuperAdmin") || AuthorizationMiddleware.IsInRole(user, "Admin"))
                            {
                                var homeForm = serviceProvider.GetRequiredService<Home>();
                                homeForm.ShowDialog();
                            }
                            else if (AuthorizationMiddleware.IsInRole(user, "FRONT DESK"))
                            {
                                var frontDeskHomeForm = serviceProvider.GetRequiredService<FrontDeskHomeForm>();
                                frontDeskHomeForm.ShowDialog();
                            }
                            else if(AuthorizationMiddleware.IsInRole(user, "ACCOUNTANT"))
                            {
                                var accountingHomeForm = serviceProvider.GetRequiredService<AccountantHomeForm>();
                                accountingHomeForm.ShowDialog();
                            }
                            else if (AuthorizationMiddleware.IsInRole(user, "BAR"))
                            {
                                var barHomeForm = serviceProvider.GetRequiredService<BarHomeForm>();
                                barHomeForm.ShowDialog();
                            }
                            else if (AuthorizationMiddleware.IsInRole(user, "RESTAURANT"))
                            {
                                var restaurantHomeForm = serviceProvider.GetRequiredService<RestaurantHomeForm>();
                                restaurantHomeForm.ShowDialog();
                            }
                            else if (AuthorizationMiddleware.IsInRole(user, "INVENTORY"))
                            {
                                var inventoryHomeForm = serviceProvider.GetRequiredService<InventoryHomeForm>();
                                inventoryHomeForm.ShowDialog();
                            }
                            else if (AuthorizationMiddleware.IsInRole(user, "STORE KEEPER"))
                            {
                                var storeKeeperHomeForm = serviceProvider.GetRequiredService<StoreKeeperHomeForm>();
                                storeKeeperHomeForm.ShowDialog();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("License has expired.", "License Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        var licence = serviceProvider.GetRequiredService<LicenseForm>();
                        var result = licence.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            var loginForm = serviceProvider.GetRequiredService<LoginForm>();
                            var loginResult = loginForm.ShowDialog();
                            if (loginResult == DialogResult.OK)
                            {
                                ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);

                                if (AuthorizationMiddleware.IsInRole(user, "SuperAdmin") || AuthorizationMiddleware.IsInRole(user, "Admin"))
                                {
                                    var homeForm = serviceProvider.GetRequiredService<Home>();
                                    homeForm.ShowDialog();
                                }
                                else if (AuthorizationMiddleware.IsInRole(user, "FRONT DESK"))
                                {
                                    var frontDeskHomeForm = serviceProvider.GetRequiredService<FrontDeskHomeForm>();
                                    frontDeskHomeForm.ShowDialog();
                                }
                                else if (AuthorizationMiddleware.IsInRole(user, "ACCOUNTANT"))
                                {
                                    var accountingHomeForm = serviceProvider.GetRequiredService<AccountantHomeForm>();
                                    accountingHomeForm.ShowDialog();
                                }
                                else if (AuthorizationMiddleware.IsInRole(user, "BAR"))
                                {
                                    var barHomeForm = serviceProvider.GetRequiredService<BarHomeForm>();
                                    barHomeForm.ShowDialog();
                                }
                                else if (AuthorizationMiddleware.IsInRole(user, "RESTAURANT"))
                                {
                                    var restaurantHomeForm = serviceProvider.GetRequiredService<RestaurantHomeForm>();
                                    restaurantHomeForm.ShowDialog();
                                }
                                else if (AuthorizationMiddleware.IsInRole(user, "INVENTORY"))
                                {
                                    var inventoryHomeForm = serviceProvider.GetRequiredService<InventoryHomeForm>();
                                    inventoryHomeForm.ShowDialog();
                                }
                                else if (AuthorizationMiddleware.IsInRole(user, "STORE KEEPER"))
                                {
                                    var storeKeeperHomeForm = serviceProvider.GetRequiredService<StoreKeeperHomeForm>();
                                    storeKeeperHomeForm.ShowDialog();
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid product key.", "License Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    var licence = serviceProvider.GetRequiredService<LicenseForm>();
                    var result = licence.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        var loginForm = serviceProvider.GetRequiredService<LoginForm>();
                        var loginResult = loginForm.ShowDialog();
                        if (loginResult == DialogResult.OK)
                        {
                            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);

                            if (AuthorizationMiddleware.IsInRole(user, "SuperAdmin") || AuthorizationMiddleware.IsInRole(user, "Admin"))
                            {
                                var homeForm = serviceProvider.GetRequiredService<Home>();
                                homeForm.ShowDialog();
                            }
                            else if (AuthorizationMiddleware.IsInRole(user, "FRONT DESK"))
                            {
                                var frontDeskHomeForm = serviceProvider.GetRequiredService<FrontDeskHomeForm>();
                                frontDeskHomeForm.ShowDialog();
                            }
                            else if (AuthorizationMiddleware.IsInRole(user, "ACCOUNTANT"))
                            {
                                var accountingHomeForm = serviceProvider.GetRequiredService<AccountantHomeForm>();
                                accountingHomeForm.ShowDialog();
                            }
                            else if (AuthorizationMiddleware.IsInRole(user, "BAR"))
                            {
                                var barHomeForm = serviceProvider.GetRequiredService<BarHomeForm>();
                                barHomeForm.ShowDialog();
                            }
                            else if (AuthorizationMiddleware.IsInRole(user, "RESTAURANT"))
                            {
                                var restaurantHomeForm = serviceProvider.GetRequiredService<RestaurantHomeForm>();
                                restaurantHomeForm.ShowDialog();
                            }
                            else if (AuthorizationMiddleware.IsInRole(user, "INVENTORY"))
                            {
                                var inventoryHomeForm = serviceProvider.GetRequiredService<InventoryHomeForm>();
                                inventoryHomeForm.ShowDialog();
                            }
                            else if (AuthorizationMiddleware.IsInRole(user, "STORE KEEPER"))
                            {
                                var storeKeeperHomeForm = serviceProvider.GetRequiredService<StoreKeeperHomeForm>();
                                storeKeeperHomeForm.ShowDialog();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No valid license found. Please enter a valid product key.", "License Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var licence = serviceProvider.GetRequiredService<LicenseForm>();
                var result = licence.ShowDialog();

                if (result == DialogResult.OK)
                {
                    var loginForm = serviceProvider.GetRequiredService<LoginForm>();
                    var loginResult = loginForm.ShowDialog();
                    if (loginResult == DialogResult.OK)
                    {
                        ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);

                        if(AuthorizationMiddleware.IsInRole(user, "SuperAdmin") || AuthorizationMiddleware.IsInRole(user, "Admin"))
                        {
                            var homeForm = serviceProvider.GetRequiredService<Home>();
                            homeForm.ShowDialog();
                        } 
                        else if (AuthorizationMiddleware.IsInRole(user, "FRONT DESK"))
                        {
                            var frontDeskHomeForm = serviceProvider.GetRequiredService<FrontDeskHomeForm>();
                            frontDeskHomeForm.ShowDialog();
                        }
                        else if (AuthorizationMiddleware.IsInRole(user, "ACCOUNTANT"))
                        {
                            var accountingHomeForm = serviceProvider.GetRequiredService<AccountantHomeForm>();
                            accountingHomeForm.ShowDialog();
                        }
                        else if (AuthorizationMiddleware.IsInRole(user, "BAR"))
                        {
                            var barHomeForm = serviceProvider.GetRequiredService<BarHomeForm>();
                            barHomeForm.ShowDialog();
                        }
                        else if (AuthorizationMiddleware.IsInRole(user, "RESTAURANT"))
                        {
                            var restaurantHomeForm = serviceProvider.GetRequiredService<RestaurantHomeForm>();
                            restaurantHomeForm.ShowDialog();
                        }
                        else if (AuthorizationMiddleware.IsInRole(user, "INVENTORY"))
                        {
                            var inventoryHomeForm = serviceProvider.GetRequiredService<InventoryHomeForm>();
                            inventoryHomeForm.ShowDialog();
                        }
                        else if (AuthorizationMiddleware.IsInRole(user, "STORE KEEPER"))
                        {
                            var storeKeeperHomeForm = serviceProvider.GetRequiredService<StoreKeeperHomeForm>();
                            storeKeeperHomeForm.ShowDialog();
                        }
                    }
                }
            }
            this.Close();
        }
    }
}
