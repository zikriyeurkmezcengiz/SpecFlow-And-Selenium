namespace VCManager.Core.Web.Udemy
{
    public class Credentials
    {
        public string EMail { get; }
        public string Password { get; }

        public Credentials(string eMail, string password)
        {
            EMail = eMail;
            Password = password;
        }
    }
}