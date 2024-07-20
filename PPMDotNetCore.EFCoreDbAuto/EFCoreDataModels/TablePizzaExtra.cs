using System;
using System.Collections.Generic;

namespace PPMDotNetCore.EFCoreDbAuto.EFCoreDataModels;

public partial class TablePizzaExtra
{
    public int PizzaExtraId { get; set; }

    public string PizzaExtraName { get; set; } = null!;

    public decimal Price { get; set; }
}
