
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class User
{ 
    public long ID { get; set; }
    [StringLength(255, MinimumLength = 3)]
    public string? Name { get; set; }  
    public string? Password { get; set; }   
}