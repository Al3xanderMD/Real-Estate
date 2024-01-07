namespace RealEstate.App.Tools
{
    public class MyTools
    {
        public static int ver = 0;

        public MyTools()
        {
            ver = styleVer();
        }

        Func<int> styleVer = () =>
        {
            Random random = new Random();
            return random.Next(1000000, 10000000); // Generates a random number between 1000000 and 9999999 inclusive
        };
    }
}
