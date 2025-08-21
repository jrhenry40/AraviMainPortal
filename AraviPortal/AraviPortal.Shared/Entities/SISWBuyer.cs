using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AraviPortal.Shared.Entities;

public class SISWBuyer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("orgid_SISWBuyer")]
    [StringLength(50)]
    public string? orgid_SISWBuyer { get; set; }

    [Column("siteid_SISWBuyer")]
    [StringLength(50)]
    public string? siteid_SISWBuyer { get; set; }

    [Column("source_SISWBuyer")]
    [StringLength(100)]
    public string? source_SISWBuyer { get; set; }

    [Column("buyer_SISWBuyer")]
    [StringLength(100)]
    public string? buyer_SISWBuyer { get; set; }

    [Column("daysapproved_SISWBuyer")]
    public int? daysapproved_SISWBuyer { get; set; }

    [Column("requestedby_SISWBuyer")]
    [StringLength(100)]
    public string? requestedby_SISWBuyer { get; set; }

    [Column("priority_SISWBuyer")]
    [StringLength(10)]
    public string? priority_SISWBuyer { get; set; }

    [Column("projectid_SISWBuyer")]
    [StringLength(100)]
    public string? projectid_SISWBuyer { get; set; }

    [Column("cpacct_SISWBuyer")]
    [StringLength(50)]
    public string? cpacct_SISWBuyer { get; set; }

    [Column("requesttype_SISWBuyer")]
    [StringLength(100)]
    public string? requesttype_SISWBuyer { get; set; }

    [Column("potype_SISWBuyer")]
    [StringLength(50)]
    public string? potype_SISWBuyer { get; set; }

    [Column("markfor_SISWBuyer")]
    [StringLength(50)]
    public string? markfor_SISWBuyer { get; set; }

    [Column("aog_SISWBuyer")]
    [StringLength(10)]
    public string? aog_SISWBuyer { get; set; }

    [Column("ponumber_SISWBuyer")]
    [StringLength(50)]
    public string? ponumber_SISWBuyer { get; set; }

    [Column("polinenumber_SISWBuyer")]
    public int? polinenumber_SISWBuyer { get; set; }

    [Column("vendorid_SISWBuyer")]
    [StringLength(50)]
    public string? vendorid_SISWBuyer { get; set; }

    [Column("vendorname_SISWBuyer")]
    [StringLength(100)]
    public string? vendorname_SISWBuyer { get; set; }

    [Column("niin_SISWBuyer")]
    [StringLength(50)]
    public string? niin_SISWBuyer { get; set; }

    [Column("dodn_SISWBuyer")]
    [StringLength(50)]
    public string? dodn_SISWBuyer { get; set; }

    [Column("partnumber_SISWBuyer")]
    [StringLength(100)]
    public string? partnumber_SISWBuyer { get; set; }

    [Column("serialnumber_SISWBuyer")]
    [StringLength(100)]
    public string? serialnumber_SISWBuyer { get; set; }

    [Column("description_SISWBuyer")]
    [StringLength(500)]
    public string? description_SISWBuyer { get; set; }

    [Column("category_SISWBuyer")]
    [StringLength(50)]
    public string? category_SISWBuyer { get; set; }

    [Column("rvsc_SISWBuyer")]
    [StringLength(50)]
    public string? rvsc_SISWBuyer { get; set; }

    [Column("bostatus_SISWBuyer")]
    [StringLength(50)]
    public string? bostatus_SISWBuyer { get; set; }

    [Column("quoteduedateutc_SISWBuyer")]
    public DateTime? quoteduedateutc_SISWBuyer { get; set; }

    [Column("pricetype_SISWBuyer")]
    [StringLength(50)]
    public string? pricetype_SISWBuyer { get; set; }

    [Column("approveddate_SISWBuyer")]
    public DateTime? approveddate_SISWBuyer { get; set; }

    [Column("polinestatus_SISWBuyer")]
    [StringLength(50)]
    public string? polinestatus_SISWBuyer { get; set; }

    [Column("orddate_SISWBuyer")]
    public DateTime? orddate_SISWBuyer { get; set; }

    [Column("ordqty_SISWBuyer")]
    public decimal? ordqty_SISWBuyer { get; set; }

    [Column("dueqty_SISWBuyer")]
    public decimal? dueqty_SISWBuyer { get; set; }

    [Column("pouom_SISWBuyer")]
    [StringLength(50)]
    public string? pouom_SISWBuyer { get; set; }

    [Column("niinuom_SISWBuyer")]
    [StringLength(50)]
    public string? niinuom_SISWBuyer { get; set; }

    [Column("rdd_SISWBuyer")]
    public DateTime? rdd_SISWBuyer { get; set; }

    [Column("edd_SISWBuyer")]
    public DateTime? edd_SISWBuyer { get; set; }

    [Column("estimatedunitprice_SISWBuyer")]
    public decimal? estimatedunitprice_SISWBuyer { get; set; }

    [Column("percent_SISWBuyer")]
    public decimal? percent_SISWBuyer { get; set; }

    [Column("estimatedtotalpricedue_SISWBuyer")]
    public decimal? estimatedtotalpricedue_SISWBuyer { get; set; }

    [Column("siteawb_SISWBuyer")]
    [StringLength(50)]
    public string? siteawb_SISWBuyer { get; set; }

    [Column("siteshippeddate_SISWBuyer")]
    public DateTime? siteshippeddate_SISWBuyer { get; set; }

    [Column("shippingno_SISWBuyer")]
    [StringLength(50)]
    public string? shippingno_SISWBuyer { get; set; }

    [Column("jcn_SISWBuyer")]
    [StringLength(50)]
    public string? jcn_SISWBuyer { get; set; }

    [Column("maintcontrolno_SISWBuyer")]
    [StringLength(50)]
    public string? maintcontrolno_SISWBuyer { get; set; }

    [Column("reqgroupno_SISWBuyer")]
    [StringLength(50)]
    public string? reqgroupno_SISWBuyer { get; set; }

    [Column("notes_SISWBuyer")]
    [StringLength(1000)]
    public string? notes_SISWBuyer { get; set; }

    [Column("obligated_SISWBuyer")]
    [StringLength(10)]
    public string? obligated_SISWBuyer { get; set; }
}