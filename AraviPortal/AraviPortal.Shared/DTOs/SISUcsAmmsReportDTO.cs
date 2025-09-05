namespace AraviPortal.Shared.DTOs;

public class SISUcsAmmsReportDTO
{
    public SISUcsAmmsReportDTO()
    { }

    public string? Requisition { get; set; }
    public string? Type { get; set; }
    public string? Priority { get; set; }
    public string? PartNumber { get; set; }
    public string? Description { get; set; }
    public string? AlternatePN { get; set; }
    public string? SN { get; set; }
    public string? RequestedBy { get; set; }
    public DateTime? RequiredDate { get; set; }

    public object? RequiredDateForReport
    {
        get
        {
            if (RequiredDate.HasValue)
            {
                return RequiredDate.Value.Date;
            }
            return null;
        }
    }

    public string? PurchaseUnit { get; set; }
    public decimal? PureqQty { get; set; }
    public string? LogRemarks { get; set; }
    public DateTime? RequisitionDate { get; set; }

    public object? RequisitionDateForReport
    {
        get
        {
            if (RequisitionDate.HasValue)
            {
                return RequisitionDate.Value.Date;
            }
            return null;
        }
    }

    public string? RepRemarks { get; set; }
    public string? AppRemarks { get; set; }
    public string? Site { get; set; }
    public decimal? PartInvCost { get; set; }
    public decimal? ExtendCost { get; set; }
    public string? OrderStatus { get; set; }
    public string? PurchaseCondition { get; set; }
    public string? EndUse { get; set; }
    public string? Name { get; set; }
    public string? VendorName { get; set; }
    public string? VendorCode { get; set; }
    public string? Company { get; set; }
    public DateTime? CreatedInMRO { get; set; }

    public object? CreatedInMROForReport
    {
        get
        {
            if (CreatedInMRO.HasValue)
            {
                return CreatedInMRO.Value.Date;
            }
            return null;
        }
    }

    public DateTime? DateSentApp { get; set; }

    public object? DateSentAppForReport
    {
        get
        {
            if (DateSentApp.HasValue)
            {
                return DateSentApp.Value.Date;
            }
            return null;
        }
    }

    public DateTime? DateRcvdApp { get; set; }

    public object? DateRcvdAppForReport
    {
        get
        {
            if (DateRcvdApp.HasValue)
            {
                return DateRcvdApp.Value.Date;
            }
            return null;
        }
    }

    public string? PoNumber { get; set; }
    public DateTime? PoDate { get; set; }

    public object? PoDateForReport
    {
        get
        {
            if (PoDate.HasValue)
            {
                return PoDate.Value.Date;
            }
            return null;
        }
    }

    public DateTime? Edd { get; set; }

    public object? EddForReport
    {
        get
        {
            if (Edd.HasValue)
            {
                return Edd.Value.Date;
            }
            return null;
        }
    }

    public string? Awb { get; set; }
    public DateTime? DateExpToVendor { get; set; }

    public object? DateExpToVendorForReport
    {
        get
        {
            if (DateExpToVendor.HasValue)
            {
                return DateExpToVendor.Value.Date;
            }
            return null;
        }
    }

    public DateTime? ReceivedDateFF { get; set; }

    public object? ReceivedDateFFForReport
    {
        get
        {
            if (ReceivedDateFF.HasValue)
            {
                return ReceivedDateFF.Value.Date;
            }
            return null;
        }
    }

    public DateTime? EstDateDepartureT4 { get; set; }

    public object? EstDateDepartureT4ForReport
    {
        get
        {
            if (EstDateDepartureT4.HasValue)
            {
                return EstDateDepartureT4.Value.Date;
            }
            return null;
        }
    }

    public string? Buyer { get; set; }
    public string? LastEditedBy { get; set; }
    public string? Budgete { get; set; }
    public int? EaRecInffinbound { get; set; }
}