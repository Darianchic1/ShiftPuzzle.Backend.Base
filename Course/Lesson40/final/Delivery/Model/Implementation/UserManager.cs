
using System.Security.Cryptography.X509Certificates;

public class UserManager : IUserManager
{
    private readonly UserContext _context;
    public  static User CurrentUser;  

    public static void Logger(User user,string action)
    { 
        string logMessage = $"{user.Name},{user.Password},{action}\n"; 
        File.AppendAllText("ActionsLog.csv", logMessage);
    }  

    public UserManager(UserContext context)
    {
        _context = context;
    }

    public void RegisterUser(User user)
    {
        Console.WriteLine("[User manager] registering user: " + user.Name);

        if(_context.Users.Any(u => u.Name == user.Name))
        {
            Console.WriteLine("User with name " + user.Name + " already exists."); 
            return;
        } 

        if (user.Name.Length > 3
            && user.Name.Length < 255)
        {
            Console.WriteLine($"Имя пользователя {user.Name} действительно.");
        }
        user.ID = _context.Users.Count() + 1;    
        _context.Users.Add(user); 
        _context.SaveChanges();
    }

    public User GetUsers(string userName) 
    {
       return _context.Users.FirstOrDefault(u => u.Name == userName);
    }

    public List<User> GetUsers()
    {
        return _context.Users.ToList(); 
    }

    public bool VerifyUser(User user)
    {
        if(_context.Users.Any(u => u.Name == user.Name && u.Password == user.Password))
        {
            CurrentUser = user;
            Console.WriteLine("User verified."); 
            return true;    
        }
        else 
        {
            Console.WriteLine("User not verified."); 
            return false; 
        }    
    }
}   