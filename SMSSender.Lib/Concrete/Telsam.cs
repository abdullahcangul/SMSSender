
using SMSSender.Lib.Constants;
using SMSSender.Lib.Core;

namespace SMSSender.Lib;

public class Telsam:SmsSender
{
    public override string SendSMS(string tel, string mesaj)
    {
        tel=LoadPhoneNumber(tel);
        string returnValue = string.Empty;
        string IstekAdresi = "http://websms.telsam.com.tr/xmlapi/sendsms";
        tel = TelsamTelFix(tel);
        string requestXml = @"<?xml version=""1.0""?>
                                <SMS>
                                  <authentication>
                                    <username>" + Ayarlar.Kullanici + @"</username>
                                    <password>" + Ayarlar.Sifre + @"</password>
                                  </authentication>
                                  <message>
                                    <originator>" + Ayarlar.Orginator + @"</originator>
                                    <text>" + mesaj + @"</text>
                                    <unicode></unicode>
                                    <international></international>
                                    <canceltext></canceltext>
                                  </message>
                                  <receivers>
                                    <receiver>" + tel + @"</receiver>
                                  </receivers>
                                </SMS>";
        returnValue = Statik.CreateWebRequest(IstekAdresi, requestXml, "POST", "application/x-www-form-urlencoded", new List<KeyValuePair<string, string>>());
        return returnValue;
    }
    
    private static string TelsamTelFix(string telefon)
    {
      if (telefon.Length == 12)
      {
        telefon = telefon.Substring(2, 10);
      }
      else if (telefon.Length == 11)
      {
        telefon = telefon.Substring(1, 10);
      }
      return telefon;
    }
}