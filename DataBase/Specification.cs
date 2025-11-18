using System;
using System.Collections.Generic;

namespace BreadFactoryIS.DataBase;

public partial class Specification
{
    public long Id { get; set; }

    public long IdProduction { get; set; }

    public long IdMaterial { get; set; }

    public int MaterialQuanitity { get; set; }

    public virtual Material IdMaterialNavigation { get; set; } = null!;

    public virtual Production IdProductionNavigation { get; set; } = null!;
}
