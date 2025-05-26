using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersService.Models;

public class Order
{
    public int OrderId { get; set; }
    public int ClientId { get; set; }
    public string PickupLocation { get; set; } = string.Empty;
    public string DropoffLocation { get; set; } = string.Empty;
    public DateTime ScheduledTime { get; set; }
    public string Status { get; set; } = "created";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
