using CsvHelper.Configuration;
using AraviPortal.Shared.Entities;

namespace AraviPortal.Backend.Helpers;

public sealed class SISSummaryAWBMap : ClassMap<SISSummaryAWB>
{
    public SISSummaryAWBMap()
    {
        Map(m => m.item_SISSummaryAWB).Name("ITEM").TypeConverter<IntConverter>();
        Map(m => m.po_SISSummaryAWB).Name("PO");
        Map(m => m.pr_SISSummaryAWB).Name("PR");
        Map(m => m.partnumber_SISSummaryAWB).Name("PART NUMBER");
        Map(m => m.description_SISSummaryAWB).Name("DESCRIPTION");
        Map(m => m.prioridad_SISSummaryAWB).Name("PRIORIDAD");
        Map(m => m.altern_SISSummaryAWB).Name("ALTERN");
        Map(m => m.nsn_SISSummaryAWB).Name("NSN");
        Map(m => m.sn_SISSummaryAWB).Name("S/N");
        Map(m => m.cnd_SISSummaryAWB).Name("CND");
        Map(m => m.qty_SISSummaryAWB).Name("QTY").TypeConverter<IntConverter>();
        Map(m => m.unit_SISSummaryAWB).Name("UNIT");
        Map(m => m.sap_SISSummaryAWB).Name("SAP ");
        Map(m => m.ubic_SISSummaryAWB).Name("UBIC");
        Map(m => m.unitprice_SISSummaryAWB).Name("UNIT PRICE").TypeConverter<DecimalConverter>();
        Map(m => m.unitcop_SISSummaryAWB).Name("UNIT COP").TypeConverter<DecimalConverter>();
        Map(m => m.subtotalusd_SISSummaryAWB).Name("SUB TOTAL USD$").TypeConverter<DecimalConverter>();
        Map(m => m.totalcop_SISSummaryAWB).Name("TOTAL COP$").TypeConverter<DecimalConverter>();
        Map(m => m.remarks_SISSummaryAWB).Name("REMARKS");
        Map(m => m.oh_SISSummaryAWB).Name("OH");
        Map(m => m.requestedby_SISSummaryAWB).Name("REQUESTED BY");
        Map(m => m.awb_SISSummaryAWB).Name("AWB");
        Map(m => m.datereceived_SISSummaryAWB).Name("DATE RECEIVED").TypeConverter<CustomDateTimeConverter>();
    }
}