using ESMART_HMS.Forms.Companies;
using ESMART_HMS.Forms.Dashboard;
using ESMART_HMS.Forms.Guests;
using ESMART_HMS.Forms.RoomBooking;
using ESMART_HMS.Forms.Rooms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Forms
{
    public partial class Home : Form
    {
        DashboardForm dashboardForm;
        CustomersForm customerForm;
        CompaniesForm companiesForm;
        RoomBookingForm roomBookingForm;
        RoomsForm roomsForm;

        public Home()
        {
            InitializeComponent();
        }

        bool menuExpand = false;
        bool sidebarExpand = true;

        private void menuTransition_Tick(object sender, EventArgs e)
        {
            //if (menuExpand == false)
            //{
            //    menuContainer.Height += 10;
            //    if (menuContainer.Height >= 181)
            //    {
            //        menuTransition.Stop();
            //        menuExpand = true;
            //    }
            //} else
            //{
            //    menuContainer.Height -= 10;
            //    if (menuContainer.Height <= 60)
            //    {
            //        menuTransition.Stop();
            //        menuExpand = false;
            //    }
            //}
        }

        private void manageGuest_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if(sidebar.Width <= 51)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();

                    //pnDashboard.Width = sidebar.Width;
                    //pnRoomBooking.Width = sidebar.Width;
                    //menuContainer.Width = sidebar.Width;
                }
            } else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 251)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();

                    //pnDashboard.Width = sidebar.Width;
                    //pnRoomBooking.Width = sidebar.Width;
                    //menuContainer.Width = sidebar.Width;
                }
            }
        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (dashboardForm == null)
            {
                dashboardForm = new DashboardForm();
                dashboardForm.FormClosed += Dashboard_FormClosed;
                dashboardForm.MdiParent = this;
                dashboardForm.Dock = DockStyle.Fill;
                dashboardForm.Show();
            } else
            {
                dashboardForm.Activate();
            }
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            dashboardForm = null;
        }

        private void btnGuests_Click(object sender, EventArgs e)
        {
            if (customerForm == null)
            {
                customerForm = new CustomersForm();
                customerForm.FormClosed += Guests_FormClosed;
                customerForm.MdiParent = this;
                customerForm.Dock = DockStyle.Fill;
                customerForm.Show();
                menuTransition.Start();

            }
            else
            {
                customerForm.Activate();
                menuTransition.Start();

            }
        }

        private void Guests_FormClosed(object sender, FormClosedEventArgs e)
        {
            customerForm = null;
        }

        private void btnRoomBooking_Click(object sender, EventArgs e)
        {
            if (roomBookingForm == null)
            {
                roomBookingForm = new RoomBookingForm();
                roomBookingForm.FormClosed += RoomBooking_FormClosed;
                roomBookingForm.MdiParent = this;
                roomBookingForm.Dock = DockStyle.Fill;
                roomBookingForm.Show();
            }
            else
            {
                roomBookingForm.Activate();
            }
        }

        private void RoomBooking_FormClosed(object sender, FormClosedEventArgs e)
        {
            roomBookingForm = null;
        }

        private void btnGuests_Click_1(object sender, EventArgs e)
        {
            if (customerForm == null)
            {
                customerForm = new CustomersForm();
                customerForm.FormClosed += Guest_FormClosed;
                customerForm.MdiParent = this;
                customerForm.Dock = DockStyle.Fill;
                customerForm.Show();
            }
            else
            {
                customerForm.Activate();
            }
        }

        private void Guest_FormClosed(object sender, FormClosedEventArgs e)
        {
            customerForm = null;
        }

        private void btnCompanies_Click(object sender, EventArgs e)
        {
            if (companiesForm == null)
            {
                companiesForm = new CompaniesForm();
                companiesForm.FormClosed += Company_FormClosed;
                companiesForm.MdiParent = this;
                companiesForm.Dock = DockStyle.Fill;
                companiesForm.Show();
                menuTransition.Start();

            }
            else
            {
                companiesForm.Activate();
                menuTransition.Start();

            }
        }

        private void Company_FormClosed(object sender, FormClosedEventArgs e)
        {
            companiesForm = null;
        }


        private void addCustonerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (customerForm == null)
            {
                customerForm = new CustomersForm();
                customerForm.FormClosed += Guest_FormClosed;
                customerForm.MdiParent = this;
                customerForm.Dock = DockStyle.Fill;
                customerForm.Show();
            }
            else
            {
                customerForm.Activate();
            }
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (roomsForm == null)
            {
                roomsForm = new RoomsForm();
                roomsForm.FormClosed += Room_FormClosed;
                roomsForm.MdiParent = this;
                roomsForm.Dock = DockStyle.Fill;
                roomsForm.Show();
            }
            else
            {
                roomsForm.Activate();
            }
        }

        private void Room_FormClosed(object sender, FormClosedEventArgs e)
        {
            roomsForm = null;
        }
    }
}
