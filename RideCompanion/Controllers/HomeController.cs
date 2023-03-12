/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using System.Data;
using System.Diagnostics;
using AutoMapper;
using Driver.Domain.Dto;
using FastReport.Utils;
using FastReport.Web;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RideCompanion.Controllers.Base;
using RideCompanion.Models;

namespace RideCompanion.Controllers;

/// <summary>
/// Home controller
/// </summary>
[Authorize]
public class HomeController : BaseController
{
    private static readonly string ReportsFolder = FindReportsFolder();
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public HomeController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Index
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View();
    }
    
    /// <summary>
    /// Home
    /// </summary>
    /// <param name="reportIndex"></param>
    /// <returns></returns>
    [HttpGet("{reportIndex:int?}")]
    public IActionResult Index(int? reportIndex)
    {
        return View();
    }
    
    public DriverCompanionChartDto DriverCompanionChart()
    {
        
        
        var data = new DriverCompanionChartDto
        {
            DriverSeries = new int[]
            {
            },
            CompanionSeries = new int[]
            {
            },
            Dates = new DateOnly[]
            {
            }
        };
        
        return new DriverCompanionChartDto();
    }

    /// <summary>
    /// Privacy
    /// </summary>
    /// <returns></returns>
    public IActionResult Privacy(int? reportIndex)
    {
        var reportList = new HomeModel()
        {
            WebReport = new WebReport(),
            ReportsList = new[]
            {
                "test"
            }
        };

        var reportToLoad = reportList.ReportsList[0];
        if (reportIndex >= 0 && reportIndex < reportList.ReportsList.Length)
            reportToLoad = reportList.ReportsList[reportIndex.Value];

        reportList.WebReport.Report.Load(Path.Combine(ReportsFolder, $"{reportToLoad}.frx"));

        var dataSet = new DataSet();
        dataSet.ReadXml(Path.Combine(ReportsFolder,"nwind.xml"));
        reportList.WebReport.Report.RegisterData(dataSet, "NorthWind");
            
        return View(reportList);
    }

    /// <summary>
    /// Error
    /// </summary>
    /// <returns></returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    /// <summary>
    /// Find Reports Folder
    /// </summary>
    /// <returns></returns>
    private static string FindReportsFolder()
    {
        var fastReportsFolder = "";
        var thisFolder = Config.ApplicationFolder;

        for (var i = 0; i < 6; i++)
        {
            var dir = Path.Combine(thisFolder, "Reports");
            if (Directory.Exists(dir))
            {
                var reportDir = Path.GetFullPath(dir);
                if (System.IO.File.Exists(Path.Combine(reportDir, "reports.xml")))
                {
                    fastReportsFolder = reportDir;
                    break;
                }
            }
            thisFolder = Path.Combine(thisFolder, @"..");
        }
        return fastReportsFolder;
    }
}