using FastReport;

namespace ExemploRelatorio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string caminhoRelatorio = Path.Combine(Directory.GetCurrentDirectory(), @"Relatorios\PrimeiroRelatorio.frx");
            Report report = Report.FromFile(caminhoRelatorio);

            //Parâmetros do relatório
            report.SetParameterValue("nome", "Gilseone Moraes");
            report.SetParameterValue("email", "contato@programacaopratica.com.br");
            report.SetParameterValue("mensagem", "Eu amo o canal Programação Prática");

            report.Prepare();

            using var pdfExport = new FastReport.Export.PdfSimple.PDFSimpleExport();
            using var reportStream = new MemoryStream();
            pdfExport.Export(report, reportStream);
            File.WriteAllBytes("MeuRelatorio.PDF", reportStream.ToArray());
        }
    }
}