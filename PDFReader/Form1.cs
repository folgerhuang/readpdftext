using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenPDF_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog() { Filter="PDF files|*.pdf",ValidateNames=true,Multiselect=false})
            {
                if(ofd.ShowDialog()==DialogResult.OK)
                {
                    try
                    {
                        iTextSharp.text.pdf.PdfReader read = new iTextSharp.text.pdf.PdfReader(ofd.FileName);
                        StringBuilder sb = new StringBuilder();
                        for (int i = 1; i <= read.NumberOfPages; i++)
                        {
                            sb.Append(PdfTextExtractor.GetTextFromPage(read, i));
                        }
                        richTextBox1.Text = sb.ToString();
                        read.Close();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message,"Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
