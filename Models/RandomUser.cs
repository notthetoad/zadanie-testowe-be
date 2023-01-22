namespace TestApi.Models;

public class RandomUser
{
    public List<Result> results { get; set; }

    public class Result
    {
        public Name name { get; set; }
        public string email { get; set; }
    }

    public class Name
    {
        public string first { get; set; }
        public string last { get; set; }
    }
}
