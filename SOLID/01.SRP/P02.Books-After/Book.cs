namespace _01.SRP.P02.Books_After
{
    public class Book
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string TurnPage(int page)
        {
            return "Current page";
        }
    }
}
