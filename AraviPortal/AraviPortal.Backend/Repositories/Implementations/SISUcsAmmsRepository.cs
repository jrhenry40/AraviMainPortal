using AraviPortal.Backend.Data;
using AraviPortal.Backend.Repositories.Interfaces;
using AraviPortal.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AraviPortal.Backend.Repositories.Implementations;

public class SISUcsAmmsRepository : ISISUcsAmmsRepository
{
    private readonly DataContext _context;

    public SISUcsAmmsRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SISUcsAmmsReportDTO>> GetReportDataAsync()
    {
        // El método .Select() es clave. Traduce la consulta a SQL para traer solo
        // las columnas que necesitas. ¡Es muy eficiente!
        return await _context.SISUcsAmms
            .Select(s => new SISUcsAmmsReportDTO
            {
                Requisition = s.requisition_SISUcsAmms,
                Type = s.type_SISUcsAmms,
                Priority = s.priority_SISUcsAmms,
                PartNumber = s.partnumber_SISUcsAmms,
                Description = s.description_SISUcsAmms,
                AlternatePN = s.alternatepn_SISUcsAmms,
                SN = s.sn_SISUcsAmms,
                RequestedBy = s.requestedby_SISUcsAmms,
                RequiredDate = s.requireddate_SISUcsAmms,
                PurchaseUnit = s.purchaseunit_SISUcsAmms,
                PureqQty = s.pureqqty_SISUcsAmms,
                LogRemarks = s.logremarks_SISUcsAmms,
                RequisitionDate = s.requisitiondate_SISUcsAmms,
                RepRemarks = s.repremarks_SISUcsAmms,
                AppRemarks = s.appremarks_SISUcsAmms,
                Site = s.site_SISUcsAmms,
                PartInvCost = s.partinvcost_SISUcsAmms,
                ExtendCost = s.extendcost_SISUcsAmms,
                OrderStatus = s.orderstatus_SISUcsAmms,
                PurchaseCondition = s.purchasecondition_SISUcsAmms,
                EndUse = s.enduse_SISUcsAmms,
                Name = s.name_SISUcsAmms,
                VendorName = s.vendorname_SISUcsAmms,
                VendorCode = s.vendorcode_SISUcsAmms,
                Company = s.company_SISUcsAmms,
                CreatedInMRO = s.createdinmro_SISUcsAmms,
                DateSentApp = s.datesentapp_SISUcsAmms,
                DateRcvdApp = s.datercvdapp_SISUcsAmms,
                PoNumber = s.ponumber_SISUcsAmms,
                PoDate = s.podate_SISUcsAmms,
                Edd = s.edd_SISUcsAmms,
                Awb = s.awb_SISUcsAmms,
                DateExpToVendor = s.dateexptovendor_SISUcsAmms,
                ReceivedDateFF = s.receiveddateff_SISUcsAmms,
                EstDateDepartureT4 = s.estdatedeparturet4_SISUcsAmms,
                Buyer = s.buyer_SISUcsAmms,
                LastEditedBy = s.lasteditedby_SISUcsAmms,
                Budgete = s.budgete_SISUcsAmms,
                EaRecInffinbound = s.earecinffinbound_SISUcsAmms
            })
            .ToListAsync();
    }
}