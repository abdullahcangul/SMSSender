using NotImplementedException = System.NotImplementedException;

namespace SMSSender.Lib.Core;

public static class Statik
{
    public static string ReplaceTRChar(string message)
    {
        //Todo:Daha sonra ekle
        throw new NotImplementedException();
    }

    public static string CreateWebRequest(string ıstekAdresi, string requestXml, string post, string applicationXWwwFormUrlencoded, List<KeyValuePair<string, string>> keyValuePairs)
    {
        throw new NotImplementedException();
    }

    public static string CreateWebRequest(string istekAdresi, string newCredentialSmsTojsonserialize, string post, string applicationXWwwFormUrlencoded)
    {
        throw new NotImplementedException();
    }
}