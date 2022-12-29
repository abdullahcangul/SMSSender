using System.Net;
using System.Text;
using System.Xml;
using SMSSender.Lib.Constants;
using SMSSender.Lib.Core;

namespace SMSSender.Lib;

public class GuvenTelekom:SmsSender
{
    
    public override string SendSMS(string tel,string mesaj)
    {
        tel=LoadPhoneNumber(tel);
        string returnValue = string.Empty;
        string IstekAdresi = "http://api.guventelekom.net:8080/api/smspost/v1";

        HttpWebRequest request = WebRequest.Create(new Uri(IstekAdresi)) as HttpWebRequest;
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.Timeout = 5000;
        byte[] data = UTF8Encoding.UTF8.GetBytes(createXmlGuvenTelekom(tel, mesaj)); request.ContentLength = data.Length;
        using (Stream postStream = request.GetRequestStream())
        {
            postStream.Write(data, 0, data.Length);
        }
        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
        {
            StreamReader reader = new StreamReader(response.GetResponseStream());
            returnValue = reader.ReadToEnd();
        }
        return returnValue;
    }
    
    private static string createXmlGuvenTelekom(string tel, string mesaj)
    {
        
        StringBuilder sb = new StringBuilder();
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Encoding = Encoding.Unicode;
        settings.Indent = true;
        settings.IndentChars = ("	");
        using (XmlWriter writer = XmlWriter.Create(sb, settings))
        {
            writer.WriteStartElement("sms");
            writer.WriteElementString("username", Ayarlar.Kullanici);
            writer.WriteElementString("password", Ayarlar.Sifre);
            writer.WriteElementString("header", Ayarlar.Orginator);
            writer.WriteElementString("validity", "2880");
            writer.WriteStartElement("message");
            writer.WriteStartElement("gsm");
            writer.WriteElementString("no", tel);
            writer.WriteEndElement(); //gsm
            writer.WriteStartElement("msg");
            writer.WriteCData(Statik.ReplaceTRChar(mesaj));
            writer.WriteEndElement(); //msg 
            writer.WriteEndElement(); //message 
            writer.WriteEndElement(); // sms 
            writer.Flush();
        }
        return sb.ToString();
    }
}