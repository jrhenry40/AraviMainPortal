using AraviPortal.Backend.Repositories.Interfaces;
using AraviPortal.Backend.UnitsOfWork.Interfaces;
using AraviPortal.Shared.DTOs;
using Microsoft.Reporting.NETCore;

namespace AraviPortal.Backend.UnitsOfWork.Implementations;

public class SISUcsAmmsUnitOfWork : ISISUcsAmmsUnitOfWork
{
    private readonly ISISUcsAmmsRepository _sISUcsAmmsRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public SISUcsAmmsUnitOfWork(ISISUcsAmmsRepository sISUcsAmmsRepository, IWebHostEnvironment webHostEnvironment)
    {
        _sISUcsAmmsRepository = sISUcsAmmsRepository;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IEnumerable<SISUcsAmmsReportDTO>> GetSisuReportAsync()
    {
        return await _sISUcsAmmsRepository.GetReportDataAsync();
    }

    public async Task<byte[]> ExportSisuReportToExcelAsync()
    {
        //var reportData = await GetSisuReportAsync();

        //using (var workbook = new XLWorkbook())
        //{
        //    var worksheet = workbook.Worksheets.Add("Reporte SIS");

        //    worksheet.Cell(1, 1).InsertTable(reportData);
        //    worksheet.Columns().AdjustToContents();

        //    using (var stream = new MemoryStream())
        //    {
        //        workbook.SaveAs(stream);
        //        return stream.ToArray();
        //    }
        //}

        var reportData = await _sISUcsAmmsRepository.GetReportDataAsync();

        // 1. Define la ruta a tu plantilla de reporte
        string reportPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "SISUcsAmmsReport.rdlc");

        var localReport = new LocalReport();
        localReport.ReportPath = reportPath;

        // 2. Proporciona los datos al reporte
        var reportDataSource = new ReportDataSource("SISUcsAmmsDS", reportData); // "DataSetName" debe coincidir con el nombre que le diste en el diseñador
        localReport.DataSources.Add(reportDataSource);

        // 3. Renderiza el reporte en el formato deseado (Excel)
        // Otros formatos: "PDF", "WORDOPENXML"
        byte[] result = localReport.Render("EXCELOPENXML");
        return result;
    }
}