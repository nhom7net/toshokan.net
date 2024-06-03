namespace toshokan.Data;

public class DbInitializer
{
    public static void Initialize(toshokanContext context)
    {
        // data exist
        if (context.Book.Any()) return;
        
    }
}