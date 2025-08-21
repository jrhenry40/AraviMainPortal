using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AraviPortal.Shared.Entities;

public class SISWSupplier
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("orgid_SISWSupplier")]
    [StringLength(50)]
    public string? orgid_SISWSupplier { get; set; }

    [Column("siteid_SISWSupplier")]
    [StringLength(50)]
    public string? siteid_SISWSupplier { get; set; }

    [Column("source_SISWSupplier")]
    [StringLength(100)]
    public string? source_SISWSupplier { get; set; }

    [Column("requestedby_SISWSupplier")]
    [StringLength(100)]
    public string? requestedby_SISWSupplier { get; set; }

    [Column("priority_SISWSupplier")]
    [StringLength(10)]
    public string? priority_SISWSupplier { get; set; }

    [Column("projectid_SISWSupplier")]
    [StringLength(100)]
    public string? projectid_SISWSupplier { get; set; }

    [Column("cpacct_SISWSupplier")]
    [StringLength(50)]
    public string? cpacct_SISWSupplier { get; set; }

    [Column("requesttype_SISWSupplier")]
    [StringLength(100)]
    public string? requesttype_SISWSupplier { get; set; }

    [Column("potype_SISWSupplier")]
    [StringLength(50)]
    public string? potype_SISWSupplier { get; set; }

    [Column("markfor_SISWSupplier")]
    [StringLength(50)]
    public string? markfor_SISWSupplier { get; set; }

    [Column("aog_SISWSupplier")]
    [StringLength(10)]
    public string? aog_SISWSupplier { get; set; }

    [Column("rod_SISWSupplier")]
    [StringLength(10)]
    public string? rod_SISWSupplier { get; set; }

    [Column("ponumber_SISWSupplier")]
    [StringLength(50)]
    public string? ponumber_SISWSupplier { get; set; }

    [Column("polinenumber_SISWSupplier")]
    public int? polinenumber_SISWSupplier { get; set; }

    [Column("vendorid_SISWSupplier")]
    [StringLength(50)]
    public string? vendorid_SISWSupplier { get; set; }

    [Column("vendorname_SISWSupplier")]
    [StringLength(100)]
    public string? vendorname_SISWSupplier { get; set; }

    [Column("niin_SISWSupplier")]
    [StringLength(50)]
    public string? niin_SISWSupplier { get; set; }

    [Column("dodn_SISWSupplier")]
    [StringLength(50)]
    public string? dodn_SISWSupplier { get; set; }

    [Column("partnumber_SISWSupplier")]
    [StringLength(100)]
    public string? partnumber_SISWSupplier { get; set; }

    [Column("serialnumber_SISWSupplier")]
    [StringLength(100)]
    public string? serialnumber_SISWSupplier { get; set; }

    [Column("description_SISWSupplier")]
    [StringLength(500)]
    public string? description_SISWSupplier { get; set; }

    [Column("category_SISWSupplier")]
    [StringLength(50)]
    public string? category_SISWSupplier { get; set; }

    [Column("rvsc_SISWSupplier")]
    [StringLength(50)]
    public string? rvsc_SISWSupplier { get; set; }

    [Column("bostatus_SISWSupplier")]
    [StringLength(50)]
    public string? bostatus_SISWSupplier { get; set; }

    [Column("pricetype_SISWSupplier")]
    [StringLength(50)]
    public string? pricetype_SISWSupplier { get; set; }

    [Column("polinestatus_SISWSupplier")]
    [StringLength(50)]
    public string? polinestatus_SISWSupplier { get; set; }

    [Column("orddate_SISWSupplier")]
    public DateTime? orddate_SISWSupplier { get; set; }

    [Column("ordqty_SISWSupplier")]
    public decimal? ordqty_SISWSupplier { get; set; }

    [Column("dueqty_SISWSupplier")]
    public decimal? dueqty_SISWSupplier { get; set; }

    [Column("pouom_SISWSupplier")]
    [StringLength(50)]
    public string? pouom_SISWSupplier { get; set; }

    [Column("niinuom_SISWSupplier")]
    [StringLength(50)]
    public string? niinuom_SISWSupplier { get; set; }

    [Column("rdd_SISWSupplier")]
    public DateTime? rdd_SISWSupplier { get; set; }

    [Column("edd_SISWSupplier")]
    public DateTime? edd_SISWSupplier { get; set; }

    [Column("dayslate_SISWSupplier")]
    public int? dayslate_SISWSupplier { get; set; }

    [Column("estimatedunitprice_SISWSupplier")]
    public decimal? estimatedunitprice_SISWSupplier { get; set; }

    [Column("percent_SISWSupplier")]
    public decimal? percent_SISWSupplier { get; set; }

    [Column("estimatedtotalpricedue_SISWSupplier")]
    public decimal? estimatedtotalpricedue_SISWSupplier { get; set; }

    [Column("supplierawb_SISWSupplier")]
    [StringLength(50)]
    public string? supplierawb_SISWSupplier { get; set; }

    [Column("suppliershippeddate_SISWSupplier")]
    public DateTime? suppliershippeddate_SISWSupplier { get; set; }

    [Column("siteawb_SISWSupplier")]
    [StringLength(50)]
    public string? siteawb_SISWSupplier { get; set; }

    [Column("siteshippeddate_SISWSupplier")]
    public DateTime? siteshippeddate_SISWSupplier { get; set; }

    [Column("shippingno_SISWSupplier")]
    [StringLength(50)]
    public string? shippingno_SISWSupplier { get; set; }

    [Column("jcn_SISWSupplier")]
    [StringLength(50)]
    public string? jcn_SISWSupplier { get; set; }

    [Column("maintcontrolno_SISWSupplier")]
    [StringLength(50)]
    public string? maintcontrolno_SISWSupplier { get; set; }

    [Column("buyer_SISWSupplier")]
    [StringLength(100)]
    public string? buyer_SISWSupplier { get; set; }

    [Column("notes_SISWSupplier")]
    [StringLength(1000)]
    public string? notes_SISWSupplier { get; set; }

    [Column("backlog_SISWSupplier")]
    public int? backlog_SISWSupplier { get; set; }

    [Column("ttdays_SISWSupplier")]
    public int? ttdays_SISWSupplier { get; set; }

    [Column("tthours_SISWSupplier")]
    public int? tthours_SISWSupplier { get; set; }

    [Column("expeditornotes_SISWSupplier")]
    [StringLength(1000)]
    public string? expeditornotes_SISWSupplier { get; set; }
}