using System;
using System.Collections.Generic;

namespace BreadFactoryIS.DataBase;

public partial class User
{
    public long Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public long IdRole { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Middlename { get; set; }

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<Manufacturer> Manufacturers { get; } = new List<Manufacturer>();
}
