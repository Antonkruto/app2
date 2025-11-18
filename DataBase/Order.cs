using System;
using System.Collections.Generic;

namespace BreadFactoryIS.DataBase;

public partial class Order
{
    public long Id { get; set; }

    public decimal OrderSum { get; set; }

    public long IdCustomer { get; set; }

    public long IdStatus { get; set; }

    public DateOnly OrderDate { get; set; }

    public virtual Customer IdCustomerNavigation { get; set; } = null!;

    public virtual OrderStatus IdStatusNavigation { get; set; } = null!;

    public virtual ICollection<OrderProduction> OrderProductions { get; } = new List<OrderProduction>();
}
