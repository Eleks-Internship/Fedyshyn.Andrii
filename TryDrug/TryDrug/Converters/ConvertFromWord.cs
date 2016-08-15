using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryDrug.Converters
{
    class ConvertFromWord
    {
        public static void DocToPDF(string path)
        {

            try
            {
                Application appWord = new Application();
                var wordDocument = appWord.Documents.Open(path);
                path = path.Replace(".docx", ".pdf");
                path = path.Replace(".doc", ".pdf");
                wordDocument.ExportAsFixedFormat(path, WdExportFormat.wdExportFormatPDF);
                wordDocument.Close();
                appWord.Quit();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);//$"Close, please, process with {path}", "Error");
            }


        }

        public static void DocToXps(string path)
        {
            try
            {
                Application appWord = new Application();
                var wordDocument = appWord.Documents.Open(path);
                path = path.Replace(".docx", ".xps");
                path = path.Replace(".doc", ".xps");
                wordDocument.ExportAsFixedFormat(path, WdExportFormat.wdExportFormatXPS);
                wordDocument.Close();
                appWord.Quit();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);//$"Close, please, process with {path}", "Error");
            }
        }

        private static void FreedomProcess()
        {

        }
    }
}