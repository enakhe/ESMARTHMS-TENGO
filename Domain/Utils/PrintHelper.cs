using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ESMART_HMS.Domain.Utils
{
    public class PrintHelper
    {
        private PrintDocument printDocument;
        private string printContent;
        private string title;
        private string companyName;
        private string[,] tableData;

        public PrintHelper(string companyName)
        {
            this.companyName = companyName;
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }

        public void Print(string title, string content)
        {
            this.title = title;
            this.printContent = content;
            tableData = null;
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog
            {
                Document = printDocument,
                Width = 800,
                Height = 600
            };
            printPreviewDialog.ShowDialog();
        }

        public void PrintTable(string title, string[,] data)
        {
            this.title = title;
            this.tableData = data;
            printContent = null;
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog
            {
                Document = printDocument,
                Width = 800,
                Height = 600
            };
            printPreviewDialog.ShowDialog();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int y = 50;

            // Print Company Name
            g.DrawString(companyName, new Font("Segoe UI", 16, FontStyle.Bold), Brushes.Black, new PointF(e.PageBounds.Width / 2 - g.MeasureString(companyName, new Font("Segoe UI", 16, FontStyle.Bold)).Width / 2, y));
            y += 50;

            // Print Title
            g.DrawString(title, new Font("Segoe UI", 14, FontStyle.Bold), Brushes.Black, new PointF(e.PageBounds.Width / 2 - g.MeasureString(title, new Font("Segoe UI", 14, FontStyle.Bold)).Width / 2, y));
            y += 50;

            // Print Content or Table
            if (tableData == null)
            {
                g.DrawString(printContent, new Font("Segoe UI", 12), Brushes.Black, new PointF(100, y));
            }
            else
            {
                PrintTableContent(g, e.PageBounds, y);
            }
        }

        private void PrintTableContent(Graphics g, Rectangle pageBounds, int startY)
        {
            int numRows = tableData.GetLength(0);
            int numCols = tableData.GetLength(1);
            int cellHeight = 30;
            int cellWidth = pageBounds.Width / numCols;

            // Draw Table Headers
            for (int col = 0; col < numCols; col++)
            {
                Rectangle cellRect = new Rectangle(col * cellWidth, startY, cellWidth, cellHeight);
                g.FillRectangle(Brushes.LightBlue, cellRect);
                g.DrawRectangle(Pens.Black, cellRect);
                g.DrawString(tableData[0, col], new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Black, cellRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }
            startY += cellHeight;

            // Draw Table Rows
            for (int row = 1; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    Rectangle cellRect = new Rectangle(col * cellWidth, startY, cellWidth, cellHeight);
                    g.DrawRectangle(Pens.Black, cellRect);
                    g.DrawString(tableData[row, col], new Font("Segoe UI", 12), Brushes.Black, cellRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
                startY += cellHeight;
            }
        }

        public static void PrintDataGridView(DataGridView dataGridView, string documentTitle, string companyName)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.Landscape = true;
            printDocument.PrintPage += (sender, e) => PrintDocumentTemplate(e, dataGridView, documentTitle, companyName);

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog
            {
                Document = printDocument,
                Width = 2480,
                Height = 3508
            };
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private static void PrintDocumentTemplate(PrintPageEventArgs e, DataGridView dataGridView, string documentTitle, string companyName)
        {
            int leftMargin = e.MarginBounds.Left;
            int topMargin = e.MarginBounds.Top;
            int cellHeight = 40;
            int tableWidth = e.MarginBounds.Width;

            Font headerFont = new Font("Segoe UI", 9, FontStyle.Bold);
            Font headerFont2 = new Font("Segoe UI", 20, FontStyle.Bold);
            Font companyFont = new Font("Segoe UI", 50, FontStyle.Bold);
            Font cellFont = new Font("Segoe UI", 7, FontStyle.Regular);
            int headerHeight = 50;

            // Draw Document Title
            e.Graphics.DrawString(companyName, companyFont, Brushes.Black, new PointF(leftMargin, 0));
            e.Graphics.DrawString(documentTitle, headerFont2, Brushes.Black, new PointF(leftMargin + (tableWidth / 2) - 100, topMargin));

            topMargin += headerHeight;

            // Column Headers
            int[] columnWidths = new int[dataGridView.Columns.Count];
            int totalWidth = 0;

            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                if (dataGridView.Columns[i].Name != "Id" || dataGridView.Columns[i].Name != "idDataGridViewTextBoxColumn")
                {
                    columnWidths[i] = (int)Math.Floor((double)tableWidth / (dataGridView.Columns.Count - 1));
                    totalWidth += columnWidths[i];
                }
            }

            // Ensure width fits the page
            if (totalWidth < tableWidth)
            {
                int diff = tableWidth - totalWidth;
                for (int i = 0; i < columnWidths.Length; i++)
                {
                    if (dataGridView.Columns[i].Name != "Id" || dataGridView.Columns[i].Name != "idDataGridViewTextBoxColumn")
                    {
                        columnWidths[i] += diff / (dataGridView.Columns.Count - 1);
                    }
                }
            }

            // Print headers
            int currentX = leftMargin;
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                if (dataGridView.Columns[i].Name != "Id" || dataGridView.Columns[i].Name != "idDataGridViewTextBoxColumn")
                {
                    e.Graphics.FillRectangle(Brushes.LightBlue, new Rectangle(currentX, topMargin, columnWidths[i], cellHeight));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(currentX, topMargin, columnWidths[i], cellHeight));
                    e.Graphics.DrawString(dataGridView.Columns[i].HeaderText, headerFont, Brushes.Black, new RectangleF(currentX, topMargin, columnWidths[i], cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    currentX += columnWidths[i];
                }
            }

            topMargin += cellHeight;

            // Print rows
            for (int row = 0; row < dataGridView.Rows.Count; row++)
            {
                currentX = leftMargin;
                for (int col = 0; col < dataGridView.Columns.Count; col++)
                {
                    if (dataGridView.Columns[col].Name != "Id" || dataGridView.Columns[col].Name != "idDataGridViewTextBoxColumn")
                    {
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(currentX, topMargin, columnWidths[col], cellHeight));
                        e.Graphics.DrawString(dataGridView.Rows[row].Cells[col].Value?.ToString() ?? "", cellFont, Brushes.Black, new RectangleF(currentX, topMargin, columnWidths[col], cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                        currentX += columnWidths[col];
                    }
                }
                topMargin += cellHeight;

                // Check if the page is full
                if (topMargin + cellHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return; // Print the rest in the next page
                }
            }

            e.HasMorePages = false;
        }
    }
}
