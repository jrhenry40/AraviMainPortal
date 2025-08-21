using AraviPortal.Shared.Entities;
using CsvHelper.Configuration;
using System.Globalization;

namespace AraviPortal.Backend.Helpers;

public class SISWSupplierMap : ClassMap<SISWSupplier>
{
    public SISWSupplierMap()
    {
        Map(m => m.orgid_SISWSupplier).Name("ORGID");
        Map(m => m.siteid_SISWSupplier).Name("SITEID");
        Map(m => m.source_SISWSupplier).Name("SOURCE");
        Map(m => m.requestedby_SISWSupplier).Name("REQUESTED BY");
        Map(m => m.priority_SISWSupplier).Name("PRIORITY");
        Map(m => m.projectid_SISWSupplier).Name("PROJECT ID");
        Map(m => m.cpacct_SISWSupplier).Name("CP ACCT");
        Map(m => m.requesttype_SISWSupplier).Name("REQUEST TYPE");
        Map(m => m.potype_SISWSupplier).Name("POTYPE");
        Map(m => m.markfor_SISWSupplier).Name("MARKFOR");
        Map(m => m.aog_SISWSupplier).Name("AOG");
        Map(m => m.rod_SISWSupplier).Name("ROD ");
        Map(m => m.ponumber_SISWSupplier).Name("PONUMBER");
        Map(m => m.polinenumber_SISWSupplier).Name("PO LINE NUMBER");
        Map(m => m.vendorid_SISWSupplier).Name("VENDORID");
        Map(m => m.vendorname_SISWSupplier).Name("VENDORNAME");
        Map(m => m.niin_SISWSupplier).Name("NIIN");
        Map(m => m.dodn_SISWSupplier).Name("DODN");
        Map(m => m.partnumber_SISWSupplier).Name("PART NUMBER");
        Map(m => m.serialnumber_SISWSupplier).Name("SERIALNUMBER");
        Map(m => m.description_SISWSupplier).Name("DESCRIPTION");
        Map(m => m.category_SISWSupplier).Name("CATEGORY");
        Map(m => m.rvsc_SISWSupplier).Name("R VS C");
        Map(m => m.bostatus_SISWSupplier).Name("BO STATUS");
        Map(m => m.pricetype_SISWSupplier).Name("PRICETYPE");
        Map(m => m.polinestatus_SISWSupplier).Name("PO LINE STATUS");
        Map(m => m.orddate_SISWSupplier).Name("ORDDATE");
        Map(m => m.ordqty_SISWSupplier).Name("ORDQTY");
        Map(m => m.dueqty_SISWSupplier).Name("DUEQTY");
        Map(m => m.pouom_SISWSupplier).Name("PO UOM");
        Map(m => m.niinuom_SISWSupplier).Name("NIIN UOM");
        Map(m => m.rdd_SISWSupplier).Name("RDD");
        Map(m => m.edd_SISWSupplier).Name("EDD");
        Map(m => m.dayslate_SISWSupplier).Name("DAYS_LATE");
        Map(m => m.estimatedunitprice_SISWSupplier).Name("ESTIMATED UNIT PRICE").TypeConverterOption.CultureInfo(CultureInfo.GetCultureInfo("en-US")).TypeConverterOption.NumberStyles(NumberStyles.Currency);
        Map(m => m.percent_SISWSupplier).Name("PERCENT").TypeConverterOption.CultureInfo(CultureInfo.GetCultureInfo("en-US")).TypeConverterOption.NumberStyles(NumberStyles.Any);
        Map(m => m.estimatedtotalpricedue_SISWSupplier).Name("ESTIMATED TOTAL PRICE DUE").TypeConverterOption.CultureInfo(CultureInfo.GetCultureInfo("en-US")).TypeConverterOption.NumberStyles(NumberStyles.Currency);
        Map(m => m.supplierawb_SISWSupplier).Name("SUPPLIER AWB ");
        Map(m => m.suppliershippeddate_SISWSupplier).Name("SUPPLIER SHIPPED DATE");
        Map(m => m.siteawb_SISWSupplier).Name("SITE AWB");
        Map(m => m.siteshippeddate_SISWSupplier).Name("SITE SHIPPED DATE");
        Map(m => m.shippingno_SISWSupplier).Name("SHIPPING NO");
        Map(m => m.jcn_SISWSupplier).Name("JCN");
        Map(m => m.maintcontrolno_SISWSupplier).Name("MAINT CONTROL NO");
        Map(m => m.buyer_SISWSupplier).Name("BUYER");
        Map(m => m.notes_SISWSupplier).Name("NOTES");
        Map(m => m.backlog_SISWSupplier).Name("BACKLOG");
        Map(m => m.ttdays_SISWSupplier).Name("TT_DAYS");
        Map(m => m.tthours_SISWSupplier).Name("TT_HOURS");
        Map(m => m.expeditornotes_SISWSupplier).Name("EXPEDITOR NOTES");
    }
}