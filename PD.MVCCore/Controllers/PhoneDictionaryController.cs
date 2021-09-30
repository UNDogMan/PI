using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PD.MVCCore.Controllers;
public class PhoneDictionaryController : Controller
{
    // GET: PhoneDictionaryController
    public ActionResult Index()
    {
        return View();
    }

    // GET: PhoneDictionaryController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: PhoneDictionaryController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: PhoneDictionaryController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: PhoneDictionaryController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: PhoneDictionaryController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: PhoneDictionaryController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: PhoneDictionaryController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
