namespace AraviPortal.Shared.DTOs;

public class SISUcsAmmsReportDTO
{
    public string? Requisition { get; set; }
    public string? Type { get; set; }
    public string? Priority { get; set; }
    public string? PartNumber { get; set; }
    public string? Description { get; set; }
    public string? AlternatePN { get; set; }
    public string? SN { get; set; }
    public string? RequestedBy { get; set; }
    public DateTime? RequiredDate { get; set; }
    public string? PurchaseUnit { get; set; }
    public decimal? PureqQty { get; set; }
    public string? LogRemarks { get; set; }
    public DateTime? RequisitionDate { get; set; }
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
    public DateTime? DateSentApp { get; set; }
    public DateTime? DateRcvdApp { get; set; }
    public string? PoNumber { get; set; }
    public DateTime? PoDate { get; set; }
    public DateTime? Edd { get; set; }
    public string? Awb { get; set; }
    public DateTime? DateExpToVendor { get; set; }
    public DateTime? ReceivedDateFF { get; set; }
    public DateTime? EstDateDepartureT4 { get; set; }
    public string? Buyer { get; set; }
    public string? LastEditedBy { get; set; }
    public string? Budgete { get; set; }
    public int? EaRecInffinbound { get; set; }
}