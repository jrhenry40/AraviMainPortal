using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AraviPortal.Shared.Entities;

public class SISUcsAmms
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    //1
    [Column("requisition_SISUcsAmms")]
    [StringLength(50)]
    public string? requisition_SISUcsAmms { get; set; }

    //2
    [Column("type_SISUcsAmms")]
    [StringLength(10)]
    public string? type_SISUcsAmms { get; set; }

    //3
    [Column("priority_SISUcsAmms")]
    [StringLength(10)]
    public string? priority_SISUcsAmms { get; set; }

    //4
    [Column("partnumber_SISUcsAmms")]
    [StringLength(100)]
    public string? partnumber_SISUcsAmms { get; set; }

    //5
    [Column("description_SISUcsAmms")]
    [StringLength(500)]
    public string? description_SISUcsAmms { get; set; }

    //6
    [Column("alternatepn_SISUcsAmms")]
    [StringLength(100)]
    public string? alternatepn_SISUcsAmms { get; set; }

    //7
    [Column("sn_SISUcsAmms")]
    [StringLength(50)]
    public string? sn_SISUcsAmms { get; set; }

    //8
    [Column("requestedby_SISUcsAmms")]
    [StringLength(100)]
    public string? requestedby_SISUcsAmms { get; set; }

    //9
    [Column("requireddate_SISUcsAmms")]
    public DateTime? requireddate_SISUcsAmms { get; set; }

    //10
    [Column("purchaseunit_SISUcsAmms")]
    [StringLength(10)]
    public string? purchaseunit_SISUcsAmms { get; set; }

    //11
    [Column("pureqqty_SISUcsAmms")]
    public decimal? pureqqty_SISUcsAmms { get; set; }

    //12
    [Column("logremarks_SISUcsAmms")]
    [StringLength(255)]
    public string? logremarks_SISUcsAmms { get; set; }

    //13
    [Column("requisitiondate_SISUcsAmms")]
    public DateTime? requisitiondate_SISUcsAmms { get; set; }

    //14
    [Column("repremarks_SISUcsAmms")]
    [MaxLength]
    public string? repremarks_SISUcsAmms { get; set; }

    //15
    [Column("appremarks_SISUcsAmms")]
    [StringLength(500)]
    public string? appremarks_SISUcsAmms { get; set; }

    //16
    [Column("site_SISUcsAmms")]
    [StringLength(50)]
    public string? site_SISUcsAmms { get; set; }

    //17
    [Column("partinvcost_SISUcsAmms")]
    public decimal? partinvcost_SISUcsAmms { get; set; }

    //18
    [Column("extendcost_SISUcsAmms")]
    public decimal? extendcost_SISUcsAmms { get; set; }

    //19
    [Column("orderstatus_SISUcsAmms")]
    [StringLength(50)]
    public string? orderstatus_SISUcsAmms { get; set; }

    //20
    [Column("purchasecondition_SISUcsAmms")]
    [StringLength(10)]
    public string? purchasecondition_SISUcsAmms { get; set; }

    //21
    [Column("enduse_SISUcsAmms")]
    [StringLength(30)]
    public string? enduse_SISUcsAmms { get; set; }

    //22
    [Column("name_SISUcsAmms")]
    [StringLength(60)]
    public string? name_SISUcsAmms { get; set; }

    //23
    [Column("vendorname_SISUcsAmms")]
    [StringLength(70)]
    public string? vendorname_SISUcsAmms { get; set; }

    //24
    [Column("vendorcode_SISUcsAmms")]
    [StringLength(40)]
    public string? vendorcode_SISUcsAmms { get; set; }

    //25
    [Column("company_SISUcsAmms")]
    [StringLength(10)]
    public string? company_SISUcsAmms { get; set; }

    //26
    [Column("createdinmro_SISUcsAmms")]
    public DateTime? createdinmro_SISUcsAmms { get; set; }

    //27
    [Column("datesentapp_SISUcsAmms")]
    public DateTime? datesentapp_SISUcsAmms { get; set; }

    //28
    [Column("datercvdapp_SISUcsAmms")]
    public DateTime? datercvdapp_SISUcsAmms { get; set; }

    //29
    [Column("ponumber_SISUcsAmms")]
    [StringLength(20)]
    public string? ponumber_SISUcsAmms { get; set; }

    //30
    [Column("podate_SISUcsAmms")]
    public DateTime? podate_SISUcsAmms { get; set; }

    //31
    [Column("edd_SISUcsAmms")]
    public DateTime? edd_SISUcsAmms { get; set; }

    //32
    [Column("awb_SISUcsAmms")]
    [StringLength(30)]
    public string? awb_SISUcsAmms { get; set; }

    //33
    [Column("dateexptovendor_SISUcsAmms")]
    public DateTime? dateexptovendor_SISUcsAmms { get; set; }

    //34
    [Column("receiveddateff_SISUcsAmms")]
    public DateTime? receiveddateff_SISUcsAmms { get; set; }

    //35
    [Column("estdatedeparturet4_SISUcsAmms")]
    public DateTime? estdatedeparturet4_SISUcsAmms { get; set; }

    //36
    [Column("buyer_SISUcsAmms")]
    [StringLength(30)]
    public string? buyer_SISUcsAmms { get; set; }

    //37
    [Column("lasteditedby_SISUcsAmms")]
    [StringLength(20)]
    public string? lasteditedby_SISUcsAmms { get; set; }

    //38
    [Column("budgete_SISUcsAmms")]
    [StringLength(10)]
    public string? budgete_SISUcsAmms { get; set; }

    //39
    [Column("earecinffinbound_SISUcsAmms")]
    public int? earecinffinbound_SISUcsAmms { get; set; }

    //40
    [Column("assetid_SISUcsAmms")]
    public Guid? assetid_SISUcsAmms { get; set; }

    //41
    [Column("qtyawb_SISUcsAmms")]
    public int? qtyawb_SISUcsAmms { get; set; }
}