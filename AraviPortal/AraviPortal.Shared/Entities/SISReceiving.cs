using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AraviPortal.Shared.Entities;

public class SISReceiving
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("vendorid_SISReceiving")]
    [StringLength(100)]
    public string? vendorid_SISReceiving { get; set; }

    [Column("receiptno_SISReceiving")]
    [StringLength(100)]
    public string? receiptno_SISReceiving { get; set; }

    [Column("receipttype_SISReceiving")]
    [StringLength(100)]
    public string? receipttype_SISReceiving { get; set; }

    [Column("mfgrpn_SISReceiving")]
    [StringLength(100)]
    public string? mfgrpn_SISReceiving { get; set; }

    [Column("nsn_SISReceiving")]
    [StringLength(100)]
    public string? nsn_SISReceiving { get; set; }

    [Column("description_SISReceiving")]
    [StringLength(2000)]
    public string? description_SISReceiving { get; set; }

    [Column("unitofissue_SISReceiving")]
    [StringLength(100)]
    public string? unitofissue_SISReceiving { get; set; }

    [Column("documentnumber_SISReceiving")]
    [StringLength(100)]
    public string? documentnumber_SISReceiving { get; set; }

    [Column("issuedocno_SISReceiving")]
    [StringLength(100)]
    public string? issuedocno_SISReceiving { get; set; }

    [Column("jobcontrolno_SISReceiving")]
    [StringLength(100)]
    public string? jobcontrolno_SISReceiving { get; set; }

    [Column("markfor_SISReceiving")]
    [StringLength(100)]
    public string? markfor_SISReceiving { get; set; }

    [Column("serialnumber_SISReceiving")]
    [StringLength(500)]
    public string? serialnumber_SISReceiving { get; set; }

    [Column("receiptqty_SISReceiving")]
    public decimal? receiptqty_SISReceiving { get; set; }

    [Column("invoiceno_SISReceiving")]
    [StringLength(100)]
    public string? invoiceno_SISReceiving { get; set; }

    [Column("reclinedate_SISReceiving")]
    public DateTime? reclinedate_SISReceiving { get; set; }

    [Column("processdate_SISReceiving")]
    public DateTime? processdate_SISReceiving { get; set; }

    [Column("cancelled_SISReceiving")]
    [StringLength(100)]
    public string? cancelled_SISReceiving { get; set; }

    [Column("id_SISReceiving")]
    public Guid? id_SISReceiving { get; set; } // ✅ Corregido a Guid?

    [Column("fkrepairlines_SISReceiving")]
    public Guid? fkrepairlines_SISReceiving { get; set; } // ✅ Corregido a Guid?

    [Column("fkdolines_SISReceiving")]
    public Guid? fkdolines_SISReceiving { get; set; } // ✅ Corregido a Guid?

    [Column("notes_SISReceiving")]
    [StringLength(2000)]
    public string? notes_SISReceiving { get; set; }

    [Column("warehouselocation_SISReceiving")]
    [StringLength(100)]
    public string? warehouselocation_SISReceiving { get; set; }

    [Column("fkpolines_SISReceiving")]
    public Guid? fkpolines_SISReceiving { get; set; } // ✅ Corregido a Guid?

    [Column("awbtrackno_SISReceiving")]
    [StringLength(100)]
    public string? awbtrackno_SISReceiving { get; set; }

    [Column("assetid_SISReceiving")]
    public Guid? assetid_SISReceiving { get; set; } // ✅ Corregido a Guid?

    [Column("tagnumber_SISReceiving")]
    [StringLength(100)]
    public string? tagnumber_SISReceiving { get; set; }

    [Column("siteid_SISReceiving")]
    [StringLength(100)]
    public string? siteid_SISReceiving { get; set; }

    [Column("ponumber_SISReceiving")]
    [StringLength(100)]
    public string? ponumber_SISReceiving { get; set; }

    [Column("polinekey_SISReceiving")]
    public int? polinekey_SISReceiving { get; set; }

    [Column("applicationcode_SISReceiving")]
    [StringLength(100)]
    public string? applicationcode_SISReceiving { get; set; }

    [Column("receiptunits_SISReceiving")]
    [StringLength(100)]
    public string? receiptunits_SISReceiving { get; set; }

    [Column("shippedvia_SISReceiving")]
    [StringLength(100)]
    public string? shippedvia_SISReceiving { get; set; }

    [Column("partmodel_SISReceiving")]
    [StringLength(200)]
    public string? partmodel_SISReceiving { get; set; }

    [Column("location_SISReceiving")]
    [StringLength(100)]
    public string? location_SISReceiving { get; set; }

    [Column("localstockno_SISReceiving")]
    [StringLength(100)]
    public string? localstockno_SISReceiving { get; set; }

    [Column("vendorname_SISReceiving")]
    [StringLength(255)]
    public string? vendorname_SISReceiving { get; set; }
}