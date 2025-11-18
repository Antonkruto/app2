using System;
using System.Collections.Generic;

namespace BreadFactoryIS.DataBase;

public partial class Material
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public long IdManufacturer { get; set; }

    public string Unit { get; set; } = null!;

    public string Code { get; set; } = null!;

    public virtual Manufacturer IdManufacturerNavigation { get; set; } = null!;

    public virtual ICollection<Specification> Specifications { get; } = new List<Specification>();
}
