namespace CustomerSite.ContranstEndpoints
{
    public class Endpoints
    {
        public const string Product = "/Products";
        public static string ProductById(int id) => $"{Product}/{id}";

        public const string Category = "/Categories";

        public const string Ratings = "/Ratings";
        public static string GetRatings(int id) => $"{Ratings}/{id}";
    }
}
