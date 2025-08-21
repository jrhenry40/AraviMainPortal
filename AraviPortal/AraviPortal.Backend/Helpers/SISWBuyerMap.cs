using AraviPortal.Shared.Entities;
using CsvHelper.Configuration;
using System.Globalization;

namespace AraviPortal.Backend.Helpers;

public class SISWBuyerMap : ClassMap<SISWBuyer>
{
    public SISWBuyerMap()
    {
        Map(m => m.orgid_SISWBuyer).Name("ORGID");
        Map(m => m.siteid_SISWBuyer).Name("SITEID");
        Map(m => m.source_SISWBuyer).Name("SOURCE");
        Map(m => m.buyer_SISWBuyer).Name("BUYER");
        Map(m => m.daysapproved_SISWBuyer).Name("DAYS APPROVED");
        Map(m => m.requestedby_SISWBuyer).Name("REQUESTED BY");
        Map(m => m.priority_SISWBuyer).Name("PRIORITY");
        Map(m => m.projectid_SISWBuyer).Name("PROJECT ID");
        Map(m => m.cpacct_SISWBuyer).Name("CP ACCT");
        Map(m => m.requesttype_SISWBuyer).Name("REQUEST TYPE");
        Map(m => m.potype_SISWBuyer).Name("POTYPE");
        Map(m => m.markfor_SISWBuyer).Name("MARKFOR");
        Map(m => m.aog_SISWBuyer).Name("AOG");
        Map(m => m.ponumber_SISWBuyer).Name("PONUMBER");
        Map(m => m.polinenumber_SISWBuyer).Name("PO LINE NUMBER");
        Map(m => m.vendorid_SISWBuyer).Name("VENDORID");
        Map(m => m.vendorname_SISWBuyer).Name("VENDORNAME");
        Map(m => m.niin_SISWBuyer).Name("NIIN");
        Map(m => m.dodn_SISWBuyer).Name("DODN");
        Map(m => m.partnumber_SISWBuyer).Name("PART NUMBER");
        Map(m => m.serialnumber_SISWBuyer).Name("SERIALNUMBER");
        Map(m => m.description_SISWBuyer).Name("DESCRIPTION");
        Map(m => m.category_SISWBuyer).Name("CATEGORY");
        Map(m => m.rvsc_SISWBuyer).Name("R VS C");
        Map(m => m.bostatus_SISWBuyer).Name("BO STATUS");
        Map(m => m.quoteduedateutc_SISWBuyer).Name("QUOTEDUEDATEUTC");
        Map(m => m.pricetype_SISWBuyer).Name("PRICETYPE");
        Map(m => m.approveddate_SISWBuyer).Name("APPROVED DATE");
        Map(m => m.polinestatus_SISWBuyer).Name("PO LINE STATUS");
        Map(m => m.orddate_SISWBuyer).Name("ORDDATE");
        Map(m => m.ordqty_SISWBuyer).Name("ORDQTY");
        Map(m => m.dueqty_SISWBuyer).Name("DUEQTY");
        Map(m => m.pouom_SISWBuyer).Name("PO UOM");
        Map(m => m.niinuom_SISWBuyer).Name("NIIN UOM");
        Map(m => m.rdd_SISWBuyer).Name("RDD");
        Map(m => m.edd_SISWBuyer).Name("EDD");
        Map(m => m.estimatedunitprice_SISWBuyer).Name("ESTIMATED UNIT PRICE").TypeConverterOption.CultureInfo(CultureInfo.GetCultureInfo("en-US")).TypeConverterOption.NumberStyles(NumberStyles.Currency);
        Map(m => m.percent_SISWBuyer).Name("PERCENT").TypeConverterOption.CultureInfo(CultureInfo.GetCultureInfo("en-US")).TypeConverterOption.NumberStyles(NumberStyles.Any);
        Map(m => m.estimatedtotalpricedue_SISWBuyer).Name("ESTIMATED TOTAL PRICE DUE").TypeConverterOption.CultureInfo(CultureInfo.GetCultureInfo("en-US")).TypeConverterOption.NumberStyles(NumberStyles.Currency);
        Map(m => m.siteawb_SISWBuyer).Name("SITE AWB");
        Map(m => m.siteshippeddate_SISWBuyer).Name("SITE SHIPPED DATE");
        Map(m => m.shippingno_SISWBuyer).Name("SHIPPING NO");
        Map(m => m.jcn_SISWBuyer).Name("JCN");
        Map(m => m.maintcontrolno_SISWBuyer).Name("MAINT CONTROL NO");
        Map(m => m.reqgroupno_SISWBuyer).Name("REQ GOUP NO");
        Map(m => m.notes_SISWBuyer).Name("NOTES");
        Map(m => m.obligated_SISWBuyer).Name("OBLIGATED");
    }
}