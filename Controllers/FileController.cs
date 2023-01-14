using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcText.Models;

namespace MvcText.Controllers;
public class FileController : Controller
{
    public IActionResult Index()
    {
        string[] fileName = Directory.GetFiles("TextFiles").Select(Path.GetFileName).ToArray();
        return View(fileName);
    }
    public IActionResult Content(string id)
    {
        string[] textContent = System.IO.File.ReadAllLines(Directory.GetCurrentDirectory() + "/TextFiles/" + id);
        return View(textContent);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}