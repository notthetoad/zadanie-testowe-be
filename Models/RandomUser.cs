namespace TestApi.Models;

// TODO change to properties and add json notation
public class RandomUserSet
{
    public List<User> results { get; set; }

    public class User
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
