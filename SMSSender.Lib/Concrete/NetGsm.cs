using SMSSender.Lib.Constants;
using SMSSender.Lib.Core;

namespace SMSSender.Lib;

public class NetGsm:SmsSender
{
    public override string SendSMS(string tel, string mesaj)
    {
        tel=LoadPhoneNumber(tel);
        string returnValue = string.Empty;
        string IstekAdresi = "https://api.netgsm.com.tr/xmlbulkhttppost.asp";
        string requestXml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                            <mainbody>
                                <header>
                                    <company dil=""TR"" bayikodu=""11111"">Ticimax</company>
                                    <usercode>" + Ayarlar.Kullanici + @"</usercode>
                                    <password>" + Ayarlar.Sifre + @"</password>
                                    <startdate></startdate>
                                    <stopdate></stopdate>
                                    <type>1:n</type>
                                    <msgheader>" + Ayarlar.Orginator + @"</msgheader>
                                </header>
                                <body>
                                    <msg><![CDATA[" + mesaj + @"]]></msg>
                                    <no>" + tel + @"</no>
                                </body>
                            </mainbody>";
        returnValue = Statik.CreateWebRequest(IstekAdresi, requestXml, "POST", "application/x-www-form-urlencoded", new List<KeyValuePair<string, string>>());
        return returnValue;
    }
}