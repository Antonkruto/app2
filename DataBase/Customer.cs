using System;
using System.Collections.Generic;

namespace BreadFactoryIS.DataBase;

public partial class Customer
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public long IdUser { get; set; }

    public string Inn { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
