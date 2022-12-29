using SMSSender.Lib;
using SMSSender.Lib.enums;
using SMSSender.Lib.Exceptions;


try
{
    var creator = new Creator();

    var smsSenderFactory = creator.SmsSenderFactory(SmsProviderType.Telsam);

    smsSenderFactory.SendSMS("","");
} 
catch (EmptyOrNullException e)
{
    Console.WriteLine(e);
}
catch (Exception e)
{
    Console.WriteLine(e);
}
