
using SMSSender.Lib.Exceptions;

namespace SMSSender.Lib;

public abstract class SmsSender
{
    public abstract string SendSMS(string tel, string mesaj);

    protected string LoadPhoneNumber(string phoneNumber)
    {
        PhoneNumberValid(phoneNumber);
        return PreprocessPhoneNumber(phoneNumber);
    }
    private void PhoneNumberValid(string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber)) throw new EmptyOrNullException("PhoneNumber");
    }
    private string PreprocessPhoneNumber(string phoneNumber)
    {
        phoneNumber = phoneNumber.Replace("+", string.Empty).Replace(" ", string.Empty);
        if (phoneNumber.Length == 10)
        {
            phoneNumber = "90" + phoneNumber;
        }
        else if (phoneNumber.Length == 11)
        {
            phoneNumber = "9" + phoneNumber;
        }

        return phoneNumber;
    }
}