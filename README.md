# Description of API

## TaskController
### GetAll()
#### Метод, возвращающий все данные из таблицы TaskTracker.
```cs
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        return Ok(_taskManager.GetAllTasks());
    }
```
### Get(int id)
#### Метод, возвращающий из таблицы TaskTracker только информацию по ключу ID.
```cs
    [HttpGet("get/{id}")]

    public TrackerTask Get(int id)
    {
        return _taskManager.GetTaskById(id);
    }
```
### Delete(int id)
#### Метод, удаляющий из таблицы TaskTracker информацию по ключу ID.
```cs
    [HttpDelete("delete/{id}")]
    public void Delete(int id)
    {  
        _taskManager.DeleteTask(id); 
    }
```
### Create([FromBody] TrackerTask task)
#### Метод, который добавляет новую запись в таблицу TrackerTasks.
```cs
    [HttpPost("add")]
    public void Create([FromBody] TrackerTask task)
    {
        _taskManager.AddTask(task);
    }
```

### AddRandom()
#### Метод, добавляющий новую запись в таблицу TrackerTasks со случайным ID.

```cs
    [HttpGet("addrandom/{id}")]
    public void User(int id)
    {
         for(int x = 0 ; x < id;x++ )
         {
            int lastTaskID = 0 ;
            try
            {
                var tasks = _taskManager.GetAllTasks(); 
                lastTaskID = (int)tasks.Max(t => t.ID);   
            } 
            catch
            {
                lastTaskID = 0; 
            }

            var newTask = new TrackerTask();
            var randomName = "Task #" + (lastTaskID + x).ToString();
            newTask.ID = lastTaskID + x;       
            newTask.Name = randomName;  
            newTask.Description = "This is a random task";   
            newTask.DueDate = new DateTime();
            newTask.AssignedUser = new User {Name = "random", Email = "random@random.com", Password = "random", ID = 1};
            _taskManager.AddTask(newTask); 
         }
    }
```
---
## AccountController

### Create([FromBody] User account)
#### Метод, который создает новую запись пользователя в таблицу Users.
```cs
    [HttpPost("register")]
    public IActionResult Create([FromBody] User account)
    {
        var user = new IdentityUser { UserName = account.Name, Email = account.Email};
        var result = _userManager.CreateAsync(user, account.Password).Result;
        if (result.Succeeded)
        {
            _signInManager.SignInAsync(user, false).Wait();
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }
```

### Login([FromBody] User account)
#### Метод, который при правильном логине и пароле разрешает пользователю вход в систему.
```cs
    [HttpPost("login")]
    public IActionResult Login([FromBody] User account)
    {
        var result = _signInManager.PasswordSignInAsync(account.Name, account.Password,false, false).Result;
        if (result.Succeeded)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }
```

### Logout()
#### Метод, который отвечает за выход пользователя из аккаунта.
```cs
    [HttpGet("logout")]
    public IActionResult Logout()
    {
        _signInManager.SignOutAsync().Wait();
        return Ok();
    }
```

### GetAccounts()
#### Метод, который возвращает список всех зарегистрированных аккаунтов.

```cs
    [HttpGet("account")]
    public List<User> GetAccounts()
    {
        return _userManager.Users.Select(u => new User { Name = u.UserName, Email = u.Email }).ToList();
    }
```
