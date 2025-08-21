using AraviPortal.Shared.Entities;
using CsvHelper.Configuration;
using static AraviPortal.Backend.Helpers.NullableDecimalConverter;

namespace AraviPortal.Backend.Helpers
{
    public sealed class SISUcsAmmsMap : ClassMap<SISUcsAmms>
    {
        public SISUcsAmmsMap()
        {
            Map(m => m.requisition_SISUcsAmms).Index(0);
            Map(m => m.type_SISUcsAmms).Index(1);
            Map(m => m.priority_SISUcsAmms).Index(2);
            Map(m => m.partnumber_SISUcsAmms).Index(3);
            Map(m => m.description_SISUcsAmms).Index(4);
            Map(m => m.alternatepn_SISUcsAmms).Index(5);
            Map(m => m.sn_SISUcsAmms).Index(6);
            Map(m => m.requestedby_SISUcsAmms).Index(7);
            Map(m => m.requireddate_SISUcsAmms).Index(8).TypeConverter<NullableDateTimeConverter>();
            Map(m => m.purchaseunit_SISUcsAmms).Index(9);
            Map(m => m.pureqqty_SISUcsAmms).Index(10);
            Map(m => m.logremarks_SISUcsAmms).Index(11);
            Map(m => m.requisitiondate_SISUcsAmms).Index(12).TypeConverter<NullableDateTimeConverter>();
            Map(m => m.repremarks_SISUcsAmms).Index(13);
            Map(m => m.appremarks_SISUcsAmms).Index(14);
            Map(m => m.site_SISUcsAmms).Index(15);
            Map(m => m.partinvcost_SISUcsAmms).Index(16).TypeConverter<NullableDecimalConverter>();
            Map(m => m.extendcost_SISUcsAmms).Index(17).TypeConverter<NullableDecimalConverter>();
            Map(m => m.orderstatus_SISUcsAmms).Index(18);
            Map(m => m.purchasecondition_SISUcsAmms).Index(19);
            Map(m => m.enduse_SISUcsAmms).Index(20);
            Map(m => m.name_SISUcsAmms).Index(21);
            Map(m => m.vendorname_SISUcsAmms).Index(22);
            Map(m => m.vendorcode_SISUcsAmms).Index(23);
            Map(m => m.company_SISUcsAmms).Index(24);
            Map(m => m.createdinmro_SISUcsAmms).Index(25).TypeConverter<NullableDateTimeConverter>();
            Map(m => m.datesentapp_SISUcsAmms).Index(26).TypeConverter<NullableDateTimeConverter>();
            Map(m => m.datercvdapp_SISUcsAmms).Index(27).TypeConverter<NullableDateTimeConverter>();
            Map(m => m.ponumber_SISUcsAmms).Index(28);
            Map(m => m.podate_SISUcsAmms).Index(29).TypeConverter<NullableDateTimeConverter>();
            Map(m => m.edd_SISUcsAmms).Index(30).TypeConverter<NullableDateTimeConverter>();
            Map(m => m.awb_SISUcsAmms).Index(31);
            Map(m => m.dateexptovendor_SISUcsAmms).Index(32).TypeConverter<NullableDateTimeConverter>();
            Map(m => m.receiveddateff_SISUcsAmms).Index(33).TypeConverter<NullableDateTimeConverter>();
            Map(m => m.estdatedeparturet4_SISUcsAmms).Index(34).TypeConverter<NullableDateTimeConverter>();
            Map(m => m.buyer_SISUcsAmms).Index(35);
            Map(m => m.lasteditedby_SISUcsAmms).Index(36);
            Map(m => m.budgete_SISUcsAmms).Index(37);
            Map(m => m.earecinffinbound_SISUcsAmms).Index(38);
        }
    }
}