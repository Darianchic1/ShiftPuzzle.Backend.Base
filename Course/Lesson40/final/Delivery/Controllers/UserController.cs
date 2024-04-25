using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;   

public class AccountController : ControllerBase
{
    private readonly IAccountManager _accountManager;

    public AccountController(IAccountManager accountManager)
    {
        _accountManager = accountManager;
    }

    [HttpPost("api/account/verify")]
    public void VerifyAccount([FromBody] User account)
    {
        _accountManager.VerifyAccount(account);
    }

    [HttpPost("/api/account/register")]
    public void RegisterAccount([FromBody] User account)
    {
        _accountManager.RegisterAccount(account);
    }

    [HttpGet("/api/account/get/{name}")] 
    public User GetAccount(string name)
    {
        return _accountManager.GetAccount(name);
    }

    [HttpGet("/api/account/getall")]
    public List<User> GetAccounts()
    {
        return _accountManager.GetAccounts();
    }
}