using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFXmlTest.JobXml
{
    /// <summary>
    /// Работа с pdf документами
    /// </summary>
    class JobInPdf
    {
        JobInXml servis;

        /// <summary>
        /// Создание pdf документа
        /// </summary>
        public void ReportInPdf(string textPdf)
        {

         try
          {
        servis = new JobInXml();

        var document = new Document(PageSize.A4, 20, 20, 30, 20);

        string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");// "ARIALNBI.TTF"
        var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED); //NOT_EMBEDDED
        var font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);


                //using (var writer = PdfWriter.GetInstance(document, new FileStream("ResultInPFD.pdf", FileMode.Create)))
                using (var writer = PdfWriter.GetInstance(document, new FileStream("Report.pdf", FileMode. Create)))
                {
                document.Open();
                document.NewPage();
                document.Add(new Paragraph($"{textPdf}", font)); ;
                //document.Add(new Paragraph($"{textPdf}")); ;
                document.Close();
                writer.Close();
            }
                servis.WrateText("Преобразование в PDF документ прошло успешно!");

            }
            catch (Exception ex)
            {
                servis.WrateText($"Ошибка при работе с PDF \n{ex}\n");
            }

            finally
            {
               
            }
        }

    }
}
