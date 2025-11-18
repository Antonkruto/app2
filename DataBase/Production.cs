using System;
using System.Collections.Generic;

namespace BreadFactoryIS.DataBase;

public partial class Production
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int Quantity { get; set; }

    public string Unit { get; set; } = null!;

    public long IdManufacturer { get; set; }

    public decimal UnitPrice { get; set; }

    public string Code { get; set; } = null!;

    public virtual Manufacturer IdManufacturerNavigation { get; set; } = null!;

    public virtual ICollection<OrderProduction> OrderProductions { get; } = new List<OrderProduction>();

    public virtual ICollection<Specification> Specifications { get; } = new List<Specification>();
}
