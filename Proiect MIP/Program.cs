namespace Proiect_MIP
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Login login = new Login(Tip.Doctor);
            login.ShowDialog();
            Application.Run();
        }
    }
}