using SMSSender.Lib.Constants;
using SMSSender.Lib.Core;

namespace SMSSender.Lib;

public class SmartMessage:SmsSender
{
    public override string SendSMS(string tel, string mesaj)
    {
        tel=LoadPhoneNumber(tel);
        string returnValue = string.Empty;
        string IstekAdresi = "http://api2.smartmessage-engage.com/GET/SMS";
        List<string> Params = new List<string>();
        Params.Add("UserName=" + Ayarlar.Kullanici);
        Params.Add("Password=" + Ayarlar.Sifre);
        Params.Add("JobId=" + Ayarlar.Orginator.Split('|')[1]);
        Params.Add("Message=" + mesaj);
        Params.Add("MobilePhone=" + tel);
        Params.Add("CustomerNo=" + Ayarlar.Orginator.Split('|')[0]);
        Params.Add("PlannedSendingDate=" + DateTime.Now.AddMinutes(1));
        string postData = String.Join("&", Params.ToArray());
        returnValue = Statik.CreateWebRequest(IstekAdresi, postData, "GET", "", new List<KeyValuePair<string, string>>());
        return returnValue;
    }
}