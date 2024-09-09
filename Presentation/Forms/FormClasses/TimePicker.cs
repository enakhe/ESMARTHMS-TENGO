using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.FormClasses
{
    public class TimePicker : Panel
    {
        private ComboBox hoursComboBox;
        private ComboBox minutesComboBox;
        private ComboBox amPmComboBox;

        public TimePicker()
        {
            InitializeTimePicker();
        }

        private void InitializeTimePicker()
        {
            // Hours ComboBox
            hoursComboBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 50
            };
            for (int i = 1; i <= 12; i++)
            {
                hoursComboBox.Items.Add(i.ToString("00"));
            }
            hoursComboBox.SelectedIndex = 0;

            // Minutes ComboBox
            minutesComboBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 50,
                Left = 60
            };
            for (int i = 0; i < 60; i++)
            {
                minutesComboBox.Items.Add(i.ToString("00"));
            }
            minutesComboBox.SelectedIndex = 0;

            // AM/PM ComboBox
            amPmComboBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 60,
                Left = 120
            };
            amPmComboBox.Items.Add("AM");
            amPmComboBox.Items.Add("PM");
            amPmComboBox.SelectedIndex = 0;

            // Add ComboBoxes to the control
            this.Controls.Add(hoursComboBox);
            this.Controls.Add(minutesComboBox);
            this.Controls.Add(amPmComboBox);

            // Set the size of the custom control
            this.Size = new Size(200, 50);
        }

        [Browsable(false)]
        public DateTime SelectedTime
        {
            get
            {
                int hours = int.Parse(hoursComboBox.SelectedItem.ToString());
                int minutes = int.Parse(minutesComboBox.SelectedItem.ToString());
                string amPm = amPmComboBox.SelectedItem.ToString();

                // Adjust for 12-hour format
                if (amPm == "PM" && hours < 12) hours += 12;
                if (amPm == "AM" && hours == 12) hours = 0;

                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hours, minutes, 0);
            }
            set
            {
                int hours = value.Hour;
                if (hours >= 12)
                {
                    amPmComboBox.SelectedIndex = 1; // PM
                    if (hours > 12) hours -= 12;
                }
                else
                {
                    amPmComboBox.SelectedIndex = 0; // AM
                    if (hours == 0) hours = 12;
                }

                hoursComboBox.SelectedItem = hours.ToString("00");
                minutesComboBox.SelectedItem = value.Minute.ToString("00");
            }
        }
    }
}
