using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HelloWorldWebApplication.Models;

namespace HelloWorldWebApplication.Controllers;

public class HomeController : Controller
{
    private readonly HelloWorldWebApplicationDbContext _context;

    public HomeController(HelloWorldWebApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Expenses()
    {
        var allExpenses = _context.Expenses.ToList();

        var totalExpenses = allExpenses.Sum(x => x.Value);

        ViewBag.Expenses = totalExpenses;

        return View(allExpenses);
    }

    public IActionResult CreateEditExpense(int? id)
    {
        if(id != null)
        {
            var expense = _context.Expenses.SingleOrDefault(x => x.Id == id);
        
            return View(expense);
        }

        return View();
    }

    public IActionResult DeleteExpense(int id)
    {
        var expense = _context.Expenses.SingleOrDefault(x => x.Id == id);

        _context.Expenses.Remove(expense);

        _context.SaveChanges();

        return RedirectToAction("Expenses");
    }

    public IActionResult CreateEditExpenseForm(Expense model)
    {
        if(model.Id == 0)
        {
            _context.Expenses.Add(model); 
        } else
        {
            _context.Expenses.Update(model);
        }
        
        _context.SaveChanges();

        return RedirectToAction("Expenses");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
