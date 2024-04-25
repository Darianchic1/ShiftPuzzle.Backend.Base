public interface IUserManager
{
    void RegisterUser(User user); 
    User GetUser(string userName);
    List<User> GetUsers(); 
    bool VerifyUser(User user);
}