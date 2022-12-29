using SMSSender.Lib.Constants;
using SMSSender.Lib.Core;

namespace SMSSender.Lib;

public class TFonTelekom:SmsSender
{
    public override string SendSMS(string tel, string mesaj)
    {
        tel=LoadPhoneNumber(tel);
        string istekAdresi = "http://api2.ekomesaj.com/json/syncreply/SendInstantSms";

        var Credential = new { 
            Username = Ayarlar.Kullanici , 
            Password=Ayarlar.Sifre, 
            ResellerID = 1111 };
        var Sms = new { 
            SmsCoding = "String",
            SenderName = Ayarlar.Orginator, 
            Route=0, 
            ValidityPeriod=0, 
            DataCoding="Default",
            ToMsisdns = new {
                Msisdn=tel,
                Name="",
                Surname="",
                CustomField1="",
            },
            ToGroups = new List<int>(),
            IsCreateFromTeplate=false,
            SmsTitle= Ayarlar.Orginator,
            SmsContent=mesaj,
            RequestGuid="",
            CanSendSmsToDuplicateMsisdn=false,
            SmsSendingType="ByNumber"
        };
        return Statik.CreateWebRequest(istekAdresi, "new { Credential, Sms }.ToJsonSerialize()", "POST", "application/json");
    }
}