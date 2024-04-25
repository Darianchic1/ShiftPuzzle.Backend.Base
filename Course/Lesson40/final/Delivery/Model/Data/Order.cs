
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Order
{ 
    public long ID { get; set; }
    public string? Origin { get; set; }
    public string? Destination { get; set; }
    public DateTime? Date { get; set; }
    public int Reward { get; set; }       
}