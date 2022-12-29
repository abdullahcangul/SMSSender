namespace SMSSender.Lib;

public class RelatedDigital:SmsSender
{
    public override string SendSMS(string tel, string message)
    {
        tel=LoadPhoneNumber(tel);
        //var apiAyar = UIAyarlar.SiteAyarlari.DijitalPazarlama.RelatedDigital.ApiAyar;
        //var client = new RelatedDigital.RelatedDigitalClient(apiAyar.KullaniciAdi, apiAyar.Sifre);
        //var smsRequest = new RelatedDigital.PostSMSRequest();
        /*smsRequest.Originator = "";
        smsRequest.NumberMessagePair = new List<RelatedDigital.NumberMessagePair>
        {
            new RelatedDigital.NumberMessagePair{ Key = tel, Value = mesaj},
        };
        smsRequest.BeginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        smsRequest.EndTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");

        var response = client.SmsGonder(smsRequest);
        return response.DetailedMessage;*/
        return "";
    }
}