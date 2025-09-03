using AraviPortal.Backend.Repositories.Interfaces;
using AraviPortal.Backend.UnitsOfWork.Interfaces;
using AraviPortal.Shared.DTOs;
using ClosedXML.Excel;

namespace AraviPortal.Backend.UnitsOfWork.Implementations;

public class SISUcsAmmsUnitOfWork : ISISUcsAmmsUnitOfWork
{
    private readonly ISISUcsAmmsRepository _sISUcsAmmsRepository;

    public SISUcsAmmsUnitOfWork(ISISUcsAmmsRepository sISUcsAmmsRepository)
    {
        _sISUcsAmmsRepository = sISUcsAmmsRepository;
    }

    public async Task<IEnumerable<SISUcsAmmsReportDTO>> GetSisuReportAsync()
    {
        return await _sISUcsAmmsRepository.GetReportDataAsync();
    }

    public async Task<byte[]> ExportSisuReportToExcelAsync()
    {
        var reportData = await GetSisuReportAsync();

        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Reporte SIS");

            worksheet.Cell(1, 1).InsertTable(reportData);
            worksheet.Columns().AdjustToContents();

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                return stream.ToArray();
            }
        }
    }
}