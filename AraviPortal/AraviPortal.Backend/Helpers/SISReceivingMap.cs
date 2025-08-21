using AraviPortal.Shared.Entities;
using CsvHelper.Configuration;

namespace AraviPortal.Backend.Helpers;

public class SISReceivingMap : ClassMap<SISReceiving>
{
    public SISReceivingMap()
    {
        Map(m => m.vendorid_SISReceiving).Name("VENDORID");
        Map(m => m.receiptno_SISReceiving).Name("RECEIPTNO");
        Map(m => m.receipttype_SISReceiving).Name("RECEIPTTYPE");
        Map(m => m.mfgrpn_SISReceiving).Name("MFGRPN");
        Map(m => m.nsn_SISReceiving).Name("NSN");
        Map(m => m.description_SISReceiving).Name("DESCRIPTION");
        Map(m => m.unitofissue_SISReceiving).Name("UNITOFISSUE");
        Map(m => m.documentnumber_SISReceiving).Name("DOCUMENTNUMBER");
        Map(m => m.issuedocno_SISReceiving).Name("ISSUEDOCNO");
        Map(m => m.jobcontrolno_SISReceiving).Name("JOBCONTROLNO");
        Map(m => m.markfor_SISReceiving).Name("MARKFOR");
        Map(m => m.serialnumber_SISReceiving).Name("SERIALNUMBER");
        Map(m => m.receiptqty_SISReceiving).Name("RECEIPTQTY");
        Map(m => m.invoiceno_SISReceiving).Name("INVOICENO");
        Map(m => m.reclinedate_SISReceiving).Name("RECLINEDATE");
        Map(m => m.processdate_SISReceiving).Name("PROCESSDATE");
        Map(m => m.cancelled_SISReceiving).Name("CANCELLED");
        Map(m => m.id_SISReceiving).Name("ID");
        Map(m => m.fkrepairlines_SISReceiving).Name("FK_REPAIRLINES");
        Map(m => m.fkdolines_SISReceiving).Name("FK_DOLINES");
        Map(m => m.notes_SISReceiving).Name("NOTES");
        Map(m => m.warehouselocation_SISReceiving).Name("WAREHOUSERECEIPT");
        Map(m => m.fkpolines_SISReceiving).Name("FK_POLINES");
        Map(m => m.awbtrackno_SISReceiving).Name("AWBTRACKNO");
        Map(m => m.assetid_SISReceiving).Name("ASSETID");
        Map(m => m.tagnumber_SISReceiving).Name("TAGNUMBER");
        Map(m => m.siteid_SISReceiving).Name("SiteID");
        Map(m => m.ponumber_SISReceiving).Name("PONUMBER");
        Map(m => m.polinekey_SISReceiving).Name("POLINEKEY");
        Map(m => m.applicationcode_SISReceiving).Name("APPLICATIONCODE");
        Map(m => m.receiptunits_SISReceiving).Name("RECEIPTUNITS");
        Map(m => m.shippedvia_SISReceiving).Name("SHIPPEDVIA");
        Map(m => m.partmodel_SISReceiving).Name("PARTMODEL");
        Map(m => m.location_SISReceiving).Name("LOCATION");
        Map(m => m.localstockno_SISReceiving).Name("LOCALSTOCKNO");
        Map(m => m.vendorname_SISReceiving).Name("VENDORNAME");
    }
}