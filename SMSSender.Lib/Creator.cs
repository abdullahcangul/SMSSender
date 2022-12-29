using SMSSender.Lib.enums;

namespace SMSSender.Lib;

 public class Creator
{
    public SmsSender SmsSenderFactory(SmsProviderType smsProviderType)
    {
        SmsSender smsSender=null;
            
        switch (smsProviderType)
        {
            case SmsProviderType.GuvenTelekom:
                smsSender = new GuvenTelekom();
                break;
            case SmsProviderType.TFonTelekom:
                smsSender = new TFonTelekom();
                break;
            case SmsProviderType.NetGsm:
                smsSender = new NetGsm();
                break;
            case SmsProviderType.SmartMessage:
                smsSender = new SmartMessage();
                break;
            case SmsProviderType.RelatedDigital:
                smsSender = new RelatedDigital();
                break;
            case SmsProviderType.Telsam:
                smsSender = new Telsam();
                break;
            case SmsProviderType.Verimor:
                smsSender = new Verimor();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(smsProviderType), smsProviderType, null);
        }

        return smsSender;
    }
}