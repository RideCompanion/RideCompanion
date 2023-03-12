namespace Driver.Domain.Dto;

public class DriverCompanionChartDto
{
    public int[] DriverSeries { get; set; }
    public int[] CompanionSeries { get; set; }
    public DateOnly[] Dates { get; set; }
}