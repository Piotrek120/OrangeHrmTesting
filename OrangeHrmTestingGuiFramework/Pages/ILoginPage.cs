namespace OrangeHrmTestingGuiFramework.Pages
{
    public interface ILoginPage
    {
        /*void SetUserName(string userName);
        void SetPassword(string password);
        void Confirm();*/
        bool Login(string adminName, string password);
        bool Login();
    }
}