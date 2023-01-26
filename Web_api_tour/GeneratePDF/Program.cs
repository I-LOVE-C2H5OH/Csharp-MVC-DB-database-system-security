using System.Reflection.Metadata;

using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Document = iTextSharp.text.Document;

namespace GeneratePDF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            Document pdfDoc = new Document(PageSize.A4, 25, 10, 25, 10);

        }
    }
}