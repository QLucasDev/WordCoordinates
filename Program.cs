using System;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

class Program
{
    static void Main(string[] args)
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Recibo_de_Venda-Teste.pdf");
        string wordToFind = "CPF";
        PdfDocument pdfDoc = new PdfDocument(new PdfReader(filePath));
        var strategy = new CustomLocationTextExtractionStrategy(wordToFind);

        for (int i = 1; i <= pdfDoc.GetNumberOfPages(); ++i)
        {
            PdfPage page = pdfDoc.GetPage(i);
            PdfTextExtractor.GetTextFromPage(page, strategy);

            Console.WriteLine($"Última ocorrência em {strategy.LastFoundX}, {strategy.LastFoundY}");
        }

        pdfDoc.Close();
    }
}

