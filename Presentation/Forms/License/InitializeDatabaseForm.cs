using ESMART_HMS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.License
{
    public partial class InitializeDatabaseForm : Form
    {
        public InitializeDatabaseForm()
        {
            InitializeComponent();
        }


        public void SeedDatabase(ProgressBar progressBar)
        {
            progressBar.Invoke(new Action(() => progressBar.Value = 0));


            DatabaseService.InitializeDatabase();
            progressBar.Invoke(new Action(() => progressBar.PerformStep()));

            DatabaseService.SeedData();
            progressBar.Invoke(new Action(() => progressBar.PerformStep()));
        }

        private async void InitializeDatabaseForm_Load(object sender, EventArgs e)
        {
            ProgressBar progressBarSeed = new ProgressBar
            {
                Width = InitializationPanal.Width - 20,
                Height = 20,
                Location = new Point(10, 10),
                Minimum = 0,
                Maximum = 4,
                Step = 2,
            };

            InitializationPanal.Controls.Add(progressBarSeed);

            var isDatabaseExit = DatabaseService.DatabaseExists();
            if (isDatabaseExit)
            {
                MessageBox.Show("Database already exist. Exiting...", "Seeding Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                await Task.Run(() =>
                {
                    SeedDatabase(progressBarSeed);
                }).ContinueWith(t =>
                {
                    this.Invoke((Action)(() =>
                    {
                        MessageBox.Show("Database seeding completed successfully!", "Seeding Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                });
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
