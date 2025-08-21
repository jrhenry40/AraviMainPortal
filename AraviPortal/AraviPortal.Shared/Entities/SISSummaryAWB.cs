using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AraviPortal.Shared.Entities;

public class SISSummaryAWB
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("item_SISSummaryAWB")]
    public int? item_SISSummaryAWB { get; set; }

    [Column("po_SISSummaryAWB")]
    [StringLength(50)]
    public string? po_SISSummaryAWB { get; set; }

    [Column("pr_SISSummaryAWB")]
    [StringLength(50)]
    public string? pr_SISSummaryAWB { get; set; }

    [Column("partnumber_SISSummaryAWB")]
    [StringLength(150)]
    public string? partnumber_SISSummaryAWB { get; set; }

    [Column("description_SISSummaryAWB")]
    [StringLength(500)]
    public string? description_SISSummaryAWB { get; set; }

    [Column("prioridad_SISSummaryAWB")]
    [StringLength(50)]
    public string? prioridad_SISSummaryAWB { get; set; }

    [Column("altern_SISSummaryAWB")]
    [StringLength(150)]
    public string? altern_SISSummaryAWB { get; set; }

    [Column("nsn_SISSummaryAWB")]
    [StringLength(50)]
    public string? nsn_SISSummaryAWB { get; set; }

    [Column("sn_SISSummaryAWB")]
    [StringLength(100)]
    public string? sn_SISSummaryAWB { get; set; }

    [Column("cnd_SISSummaryAWB")]
    [StringLength(50)]
    public string? cnd_SISSummaryAWB { get; set; }

    [Column("qty_SISSummaryAWB")]
    public int? qty_SISSummaryAWB { get; set; }

    [Column("unit_SISSummaryAWB")]
    [StringLength(10)]
    public string? unit_SISSummaryAWB { get; set; }

    [Column("sap_SISSummaryAWB")]
    [StringLength(50)]
    public string? sap_SISSummaryAWB { get; set; }

    [Column("ubic_SISSummaryAWB")]
    [StringLength(50)]
    public string? ubic_SISSummaryAWB { get; set; }

    [Column("unitprice_SISSummaryAWB")]
    public decimal? unitprice_SISSummaryAWB { get; set; }

    [Column("unitcop_SISSummaryAWB")]
    public decimal? unitcop_SISSummaryAWB { get; set; }

    [Column("subtotalusd_SISSummaryAWB")]
    public decimal? subtotalusd_SISSummaryAWB { get; set; }

    [Column("totalcop_SISSummaryAWB")]
    public decimal? totalcop_SISSummaryAWB { get; set; }

    [Column("remarks_SISSummaryAWB")]
    [StringLength(500)]
    public string? remarks_SISSummaryAWB { get; set; }

    [Column("oh_SISSummaryAWB")]
    [StringLength(50)]
    public string? oh_SISSummaryAWB { get; set; }

    [Column("requestedby_SISSummaryAWB")]
    [StringLength(100)]
    public string? requestedby_SISSummaryAWB { get; set; }

    [Column("awb_SISSummaryAWB")]
    [StringLength(100)]
    public string? awb_SISSummaryAWB { get; set; }

    [Column("datereceived_SISSummaryAWB")]
    public DateTime? datereceived_SISSummaryAWB { get; set; }
}