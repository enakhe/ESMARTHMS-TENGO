using ESMART_HMS.Domain.Enum;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;

namespace ESMART_HMS.Domain.Utils
{
    public class FormHelper
    {
        public static decimal GetDateInterval(DateTime startDate, DateTime endDate)
        {
            TimeSpan difference = endDate - startDate;
            return Math.Abs(difference.Days);
        }

        public static decimal GetPriceByRateAndTime(DateTime startDate, DateTime endDate, decimal rate)
        {
            decimal timeSpan = GetDateInterval(startDate, endDate);
            return timeSpan * rate;
        }

        public static string FormatNumberWithCommas(decimal number)
        {
            return number.ToString("#,##0.00");
        }

        public static bool TryConvertStringToDecimal(string input, out decimal result)
        {
            return decimal.TryParse(input, out result);
        }

        public static bool AreAnyNullOrEmpty(params string[] args)
        {
            foreach (var arg in args)
            {
                if (string.IsNullOrEmpty(arg))
                {
                    return true;
                }
            }
            return false;
        }

        public static string ByteArrayToString(byte[] byteArray)
        {
            if (byteArray == null)
                return string.Empty;

            return Encoding.ASCII.GetString(byteArray).TrimEnd('\0');
        }

        public static string FormatEnumName(MakeCardType enumName)
        {
            return Regex.Replace(enumName.ToString(), "([a-z])([A-Z])", "$1 $2");
        }

        public static MakeCardType GetCardType(int cardTypeValue)
        {
            if (System.Enum.IsDefined(typeof(MakeCardType), cardTypeValue))
            {
                return (MakeCardType)cardTypeValue;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(cardTypeValue), "Invalid card type value.");
            }
        }

        public static void ExportDataGridViewToExcel(DataGridView dataGridView, string title)
        {
            try
            {
                var filePath = $@"C:\ESMARTHMS\Exports\{title}.xlsx";
                string directoryPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                Excel.Application excelApp = new Excel.Application();

                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);

                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = title;

                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value?.ToString();
                    }
                }
                worksheet.Columns.AutoFit();
                workbook.SaveAs(filePath);
                workbook.Close();
                excelApp.Quit();

                MessageBox.Show($"Data exported successfully to {filePath}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to Excel: " + ex.Message);
            }
        }

        public static void ExportDataGridViewToPdf(DataGridView dataGridView, string title)
        {
            try
            {
                var filePath = $@"C:\ESMARTHMS\Exports\{title}.pdf";
                using (var document = new Document(PageSize.A4.Rotate()))
                {
                    var directoryPath = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    if (File.Exists(filePath))
                    {
                        MessageBox.Show("The file already exists. Please choose a different file name.", "File Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                    document.Open();

                    var font = FontFactory.GetFont(FontFactory.HELVETICA, 8);
                    var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);

                    var table = new PdfPTable(dataGridView.Columns.Count)
                    {
                        WidthPercentage = 100
                    };

                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        if (column.Visible)
                        {
                            var cell = new PdfPCell(new Phrase(column.HeaderText, headerFont))
                            {
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                VerticalAlignment = Element.ALIGN_MIDDLE,
                                BackgroundColor = BaseColor.LIGHT_GRAY
                            };
                            table.AddCell(cell);
                        }
                    }

                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.OwningColumn.Visible)
                            {
                                var pdfCell = new PdfPCell(new Phrase(cell.Value?.ToString(), font))
                                {
                                    HorizontalAlignment = Element.ALIGN_CENTER,
                                    VerticalAlignment = Element.ALIGN_MIDDLE
                                };
                                table.AddCell(pdfCell);
                            }
                        }
                    }

                    document.Add(table);
                    document.Close();
                    MessageBox.Show($"Data exported successfully to {filePath}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to PDF: " + ex.Message);
            }
        }

        public static string FormatDateTimeWithSuffix(string dateTimeString)
        {
            DateTime dateTime = DateTime.ParseExact(dateTimeString, "yyyy-MM-dd HH:mm:ss.FFFFFFF", CultureInfo.InvariantCulture);

            string formattedDate = dateTime.ToString("MMM d, yyyy h:mm tt", CultureInfo.InvariantCulture);

            return formattedDate;
        }
    }
}
