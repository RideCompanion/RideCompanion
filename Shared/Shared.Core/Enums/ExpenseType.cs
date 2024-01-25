using System.ComponentModel;

namespace Shared.Core.Enums;

public enum ExpenseType
{
    [Description("Per day")]
    PerDay = 1,
    
    [Description("Per week")]
    PerWeek = 2,
    
    [Description("Per month")]
    PerMonth = 3,
    
    [Description("Per year")]
    PerYear = 4
}