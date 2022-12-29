using SMSSender.Lib.Constants;
using SMSSender.Lib.Core;

namespace SMSSender.Lib;

public class Verimor:SmsSender
{
    public override string SendSMS(string tel, string mesaj)
    {
        tel=LoadPhoneNumber(tel);
        string istekAdresi = "http://sms.verimor.com.tr/v2/send.json";
        var Sms = new
        {
            username = Ayarlar.Kullanici,
            password = Ayarlar.Sifre,
            source_addr = Ayarlar.Orginator,
            valid_for = "24:00",
            datacoding = "1",
            messages = new List<object> 
            { 
                new 
                {
                    msg = mesaj,
                    dest = tel
                }
            }
        };
        return Statik.CreateWebRequest(istekAdresi, "Sms.ToJsonSerialize()", "POST", "application/json");
    }
}