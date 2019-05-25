namespace TextbookExchange
{
    public interface IApp
    {
        bool Equals(object obj);
        int GetHashCode();
        string ToString();
    }
}