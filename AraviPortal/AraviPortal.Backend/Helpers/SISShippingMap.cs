using AraviPortal.Shared.Entities;
using CsvHelper.Configuration;

namespace AraviPortal.Backend.Helpers;

public class SISShippingMap : ClassMap<SISShipping>
{
    public SISShippingMap()
    {
        Map(m => m.headerid_SISShipping).Name("HeaderID");
        Map(m => m.lineid_SISShipping).Name("LineID");
        Map(m => m.siteid_SISShipping).Name("SITEID");
        Map(m => m.documentnumber_SISShipping).Name("DOCUMENTNUMBER");
        Map(m => m.issuedocno_SISShipping).Name("ISSUEDOCNO");
        Map(m => m.jobcontrolno_SISShipping).Name("JOBCONTROLNO");
        Map(m => m.fkassetlcf_SISShipping).Name("FK_ASSETLCF");
        Map(m => m.fkpartslcf_SISShipping).Name("FK_PARTSLCF");
        Map(m => m.serialnumber_SISShipping).Name("SERIALNUMBER");
        Map(m => m.warehousereceipt_SISShipping).Name("WAREHOUSERECEIPT");
        Map(m => m.ownerid_SISShipping).Name("OWNERID");
        Map(m => m.mfgrpn_SISShipping).Name("MFGRPN");
        Map(m => m.nsn_SISShipping).Name("NSN");
        Map(m => m.description_SISShipping).Name("DESCRIPTION");
        Map(m => m.mfgrcode_SISShipping).Name("MFGRCODE");
        Map(m => m.unitofissue_SISShipping).Name("UNITOFISSUE");
        Map(m => m.awbtrackingno_SISShipping).Name("AWBTRACKINGNO");
        Map(m => m.mawb_SISShipping).Name("MAWB");
        Map(m => m.donumber_SISShipping).Name("DONUMBER");
        Map(m => m.shippeddatetime_SISShipping).Name("SHIPPEDDATETIME");
        Map(m => m.priority_SISShipping).Name("PRIORITY");
        Map(m => m.linestatus_SISShipping).Name("LINESTATUS");
        Map(m => m.shippedqty_SISShipping).Name("SHIPPEDQTY");
        Map(m => m.tagnumber_SISShipping).Name("TAGNUMBER");
        Map(m => m.shippedunits_SISShipping).Name("SHIPPEDUNITS");
        Map(m => m.claimno_SISShipping).Name("CLAIMNO");
        Map(m => m.type_SISShipping).Name("TYPE");
        Map(m => m.shiptositeid_Sisshipping).Name("SHIPTOSITEID");
        Map(m => m.trackurlfmt_SISShipping).Name("TRACKURLFMT");
        Map(m => m.countryofmanu_SISShipping).Name("COUNTRYOFMANU");
        Map(m => m.itar_SISShipping).Name("ITAR");
        Map(m => m.harmonized_SISShipping).Name("HARMONIZED");
        Map(m => m.usmleccn_SISShipping).Name("USMLECCN");
        Map(m => m.impharmonized_SISShipping).Name("IMPHARMONIZED");
        Map(m => m.itarlicense_SISShipping).Name("ITARLicense");
        Map(m => m.sealnum_SISShipping).Name("SEALNUM");
        Map(m => m.containernum_SISShipping).Name("CONTAINERNUM");
        Map(m => m.applicationcode_SISShipping).Name("APPLICATIONCODE");
        Map(m => m.bookingno_SISShipping).Name("BOOKINGNO");
        Map(m => m.tmstatus_SISShipping).Name("TMSTATUS");
        Map(m => m.backorderid_SISShipping).Name("BackOrderID");
        Map(m => m.loadnumber_SISShipping).Name("LoadNumber");
        Map(m => m.tracingno_SISShipping).Name("TRACINGNO");
        Map(m => m.partmodel_SISShipping).Name("PARTMODEL");
        Map(m => m.localstockno_SISShipping).Name("LocalStockNo");
        Map(m => m.shippingprogress_SISShipping).Name("SHIPPINGPROGRESS");
    }
}