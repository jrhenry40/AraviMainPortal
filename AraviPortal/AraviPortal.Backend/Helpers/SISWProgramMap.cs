using AraviPortal.Shared.Entities;
using CsvHelper.Configuration;
using System.Globalization;

namespace AraviPortal.Backend.Helpers;

public class SISWProgramMap : ClassMap<SISWProgram>
{
    public SISWProgramMap()
    {
        Map(m => m.orgid_SISWProgram).Name("ORGID");
        Map(m => m.siteid_SISWProgram).Name("SITEID");
        Map(m => m.source_SISWProgram).Name("SOURCE");
        Map(m => m.partnumber_SISWProgram).Name("PART NUMBER");
        Map(m => m.description_SISWProgram).Name("DESCRIPTION");
        Map(m => m.requestedby_SISWProgram).Name("REQUESTED BY");
        Map(m => m.category_SISWProgram).Name("CATEGORY");
        Map(m => m.ponumber_SISWProgram).Name("PO NUMBER");
        Map(m => m.dodn_SISWProgram).Name("DODN");
        Map(m => m.jcn_SISWProgram).Name("JCN");
        Map(m => m.maintcontrolno_SISWProgram).Name("MAINT CONTROL NO");
        Map(m => m.ordQty_SISWProgram).Name("ORDQTY");
        Map(m => m.estunitprice_SISWProgram).Name("EST UNIT PRICE").TypeConverterOption.CultureInfo(CultureInfo.GetCultureInfo("en-US")).TypeConverterOption.NumberStyles(NumberStyles.Currency);
        Map(m => m.percent_SISWProgram).Name("PERCENT").TypeConverterOption.CultureInfo(CultureInfo.GetCultureInfo("en-US")).TypeConverterOption.NumberStyles(NumberStyles.Any);
        Map(m => m.lineprice_SISWProgram).Name("LINE PRICE").TypeConverterOption.CultureInfo(CultureInfo.GetCultureInfo("en-US")).TypeConverterOption.NumberStyles(NumberStyles.Currency);
        Map(m => m.aog_SISWProgram).Name("AOG");
        Map(m => m.priority_SISWProgram).Name("PRIORITY");
        Map(m => m.markfor_SISWProgram).Name("MARKFOR");
        Map(m => m.shippingno_SISWProgram).Name("SHIPPING NO");
        Map(m => m.projectid_SISWProgram).Name("PROJECT ID");
        Map(m => m.cpacct_SISWProgram).Name("CP ACCT");
        Map(m => m.bostatus_SISWProgram).Name("BO STATUS");
        Map(m => m.daysaging_SISWProgram).Name("DAYS AGING");
        Map(m => m.rejecteddate_SISWProgram).Name("REJECTED DATE");
        Map(m => m.rejectnotes_SISWProgram).Name("REJECT NOTES");
    }
}