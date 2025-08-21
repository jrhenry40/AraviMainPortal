using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AraviPortal.Shared.Entities;

public class SISWProgram
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("orgid_SISWProgram")]
    [StringLength(50)]
    public string? orgid_SISWProgram { get; set; }

    [Column("siteid_SISWProgram")]
    [StringLength(50)]
    public string? siteid_SISWProgram { get; set; }

    [Column("source_SISWProgram")]
    [StringLength(100)]
    public string? source_SISWProgram { get; set; }

    [Column("partnumber_SISWProgram")]
    [StringLength(100)]
    public string? partnumber_SISWProgram { get; set; }

    [Column("description_SISWProgram")]
    [StringLength(500)]
    public string? description_SISWProgram { get; set; }

    [Column("requestedby_SISWProgram")]
    [StringLength(100)]
    public string? requestedby_SISWProgram { get; set; }

    [Column("category_SISWProgram")]
    [StringLength(50)]
    public string? category_SISWProgram { get; set; }

    [Column("ponumber_SISWProgram")]
    [StringLength(50)]
    public string? ponumber_SISWProgram { get; set; }

    [Column("dodn_SISWProgram")]
    [StringLength(50)]
    public string? dodn_SISWProgram { get; set; }

    [Column("jcn_SISWProgram")]
    [StringLength(50)]
    public string? jcn_SISWProgram { get; set; }

    [Column("maintcontrolno_SISWProgram")]
    [StringLength(50)]
    public string? maintcontrolno_SISWProgram { get; set; }

    [Column("ordQty_SISWProgram")]
    public int? ordQty_SISWProgram { get; set; }

    [Column("estunitprice_SISWProgram")]
    public decimal? estunitprice_SISWProgram { get; set; }

    [Column("percent_SISWProgram")]
    public decimal? percent_SISWProgram { get; set; }

    [Column("lineprice_SISWProgram")]
    public decimal? lineprice_SISWProgram { get; set; }

    [Column("aog_SISWProgram")]
    [StringLength(10)]
    public string? aog_SISWProgram { get; set; }

    [Column("priority_SISWProgram")]
    [StringLength(10)]
    public string? priority_SISWProgram { get; set; }

    [Column("markfor_SISWProgram")]
    [StringLength(50)]
    public string? markfor_SISWProgram { get; set; }

    [Column("shippingno_SISWProgram")]
    [StringLength(50)]
    public string? shippingno_SISWProgram { get; set; }

    [Column("projectid_SISWProgram")]
    [StringLength(100)]
    public string? projectid_SISWProgram { get; set; }

    [Column("cpacct_SISWProgram")]
    [StringLength(50)]
    public string? cpacct_SISWProgram { get; set; }

    [Column("bostatus_SISWProgram")]
    [StringLength(50)]
    public string? bostatus_SISWProgram { get; set; }

    [Column("daysaging_SISWProgram")]
    public int? daysaging_SISWProgram { get; set; }

    [Column("rejecteddate_SISWProgram")]
    public DateTime? rejecteddate_SISWProgram { get; set; }

    [Column("rejectnotes_SISWProgram")]
    [StringLength(500)]
    public string? rejectnotes_SISWProgram { get; set; }
}