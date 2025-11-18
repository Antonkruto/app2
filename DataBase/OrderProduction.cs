using System;
using System.Collections.Generic;

namespace BreadFactoryIS.DataBase;

public partial class OrderProduction
{
    public long Id { get; set; }

    public long ProductionQuantity { get; set; }

    public long IdProduction { get; set; }

    public long IdOrder { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Production IdProductionNavigation { get; set; } = null!;
}
