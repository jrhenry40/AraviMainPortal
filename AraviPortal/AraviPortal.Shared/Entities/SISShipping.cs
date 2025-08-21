using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AraviPortal.Shared.Entities;

public class SISShipping
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("headerid_SISShipping")]
    public Guid? headerid_SISShipping { get; set; }

    [Column("lineid_SISShipping")]
    public Guid? lineid_SISShipping { get; set; }

    [Column("siteid_SISShipping")]
    [StringLength(50)]
    public string? siteid_SISShipping { get; set; }

    [Column("documentnumber_SISShipping")]
    [StringLength(50)]
    public string? documentnumber_SISShipping { get; set; }

    [Column("issuedocno_SISShipping")]
    [StringLength(50)]
    public string? issuedocno_SISShipping { get; set; }

    [Column("jobcontrolno_SISShipping")]
    [StringLength(50)]
    public string? jobcontrolno_SISShipping { get; set; }

    [Column("fkassetlcf_SISShipping")]
    public Guid? fkassetlcf_SISShipping { get; set; }

    [Column("fkpartslcf_SISShipping")]
    public Guid? fkpartslcf_SISShipping { get; set; }

    [Column("serialnumber_SISShipping")]
    [StringLength(100)]
    public string? serialnumber_SISShipping { get; set; }

    [Column("warehousereceipt_SISShipping")]
    [StringLength(100)]
    public string? warehousereceipt_SISShipping { get; set; }

    [Column("ownerid_SISShipping")]
    [StringLength(50)]
    public string? ownerid_SISShipping { get; set; }

    [Column("mfgrpn_SISShipping")]
    [StringLength(100)]
    public string? mfgrpn_SISShipping { get; set; }

    [Column("nsn_SISShipping")]
    [StringLength(50)]
    public string? nsn_SISShipping { get; set; }

    [Column("description_SISShipping")]
    [StringLength(255)]
    public string? description_SISShipping { get; set; }

    [Column("mfgrcode_SISShipping")]
    [StringLength(50)]
    public string? mfgrcode_SISShipping { get; set; }

    [Column("unitofissue_SISShipping")]
    [StringLength(10)]
    public string? unitofissue_SISShipping { get; set; }

    [Column("awbtrackingno_SISShipping")]
    [StringLength(100)]
    public string? awbtrackingno_SISShipping { get; set; }

    [Column("mawb_SISShipping")]
    [StringLength(100)]
    public string? mawb_SISShipping { get; set; }

    [Column("donumber_SISShipping")]
    [StringLength(100)]
    public string? donumber_SISShipping { get; set; }

    [Column("shippeddatetime_SISShipping")]
    public DateTime? shippeddatetime_SISShipping { get; set; }

    [Column("priority_SISShipping")]
    [StringLength(10)]
    public string? priority_SISShipping { get; set; }

    [Column("linestatus_SISShipping")]
    [StringLength(50)]
    public string? linestatus_SISShipping { get; set; }

    [Column("shippedqty_SISShipping")]
    public int? shippedqty_SISShipping { get; set; }

    [Column("tagnumber_SISShipping")]
    [StringLength(100)]
    public string? tagnumber_SISShipping { get; set; }

    [Column("shippedunits_SISShipping")]
    [StringLength(10)]
    public string? shippedunits_SISShipping { get; set; }

    [Column("claimno_SISShipping")]
    [StringLength(50)]
    public string? claimno_SISShipping { get; set; }

    [Column("type_SISShipping")]
    [StringLength(10)]
    public string? type_SISShipping { get; set; }

    [Column("shiptositeid_SISShipping")]
    [StringLength(50)]
    public string? shiptositeid_Sisshipping { get; set; }

    [Column("trackurlfmt_SISShipping")]
    [StringLength(255)]
    public string? trackurlfmt_SISShipping { get; set; }

    [Column("countryofmanu_SISShipping")]
    [StringLength(50)]
    public string? countryofmanu_SISShipping { get; set; }

    [Column("itar_SISShipping")]
    [StringLength(50)]
    public string? itar_SISShipping { get; set; }

    [Column("harmonized_SISShipping")]
    [StringLength(50)]
    public string? harmonized_SISShipping { get; set; }

    [Column("usmleccn_SISShipping")]
    [StringLength(50)]
    public string? usmleccn_SISShipping { get; set; }

    [Column("impharmonized_SISShipping")]
    [StringLength(50)]
    public string? impharmonized_SISShipping { get; set; }

    [Column("itarlicense_SISShipping")]
    [StringLength(50)]
    public string? itarlicense_SISShipping { get; set; }

    [Column("sealnum_SISShipping")]
    [StringLength(50)]
    public string? sealnum_SISShipping { get; set; }

    [Column("containernum_SISShipping")]
    [StringLength(50)]
    public string? containernum_SISShipping { get; set; }

    [Column("applicationcode_SISShipping")]
    [StringLength(50)]
    public string? applicationcode_SISShipping { get; set; }

    [Column("bookingno_SISShipping")]
    [StringLength(50)]
    public string? bookingno_SISShipping { get; set; }

    [Column("tmstatus_SISShipping")]
    [StringLength(50)]
    public string? tmstatus_SISShipping { get; set; }

    [Column("backorderid_SISShipping")]
    [StringLength(50)]
    public string? backorderid_SISShipping { get; set; }

    [Column("loadnumber_SISShipping")]
    [StringLength(50)]
    public string? loadnumber_SISShipping { get; set; }

    [Column("tracingno_SISShipping")]
    [StringLength(50)]
    public string? tracingno_SISShipping { get; set; }

    [Column("partmodel_SISShipping")]
    [StringLength(50)]
    public string? partmodel_SISShipping { get; set; }

    [Column("localstockno_SISShipping")]
    [StringLength(50)]
    public string? localstockno_SISShipping { get; set; }

    [Column("shippingprogress_SISShipping")]
    [StringLength(50)]
    public string? shippingprogress_SISShipping { get; set; }
}