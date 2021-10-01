using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PD.DataCore.Interfaces;
using PD.DataCore.Models;
using System;
using System.Threading.Tasks;

namespace PD.MVCCore.Controllers;
public class PhoneDictionaryController : Controller
{
    private readonly IPhoneDictionary _dictionary;

    public PhoneDictionaryController(IPhoneDictionary dictionary)
    {
        _dictionary = dictionary;
    }

    [HttpGet]
    public async Task<ActionResult> Index()
    {
        return View(await _dictionary.GetRecords());
    }

    [HttpGet]
    public ActionResult Add()
    {
        return View();
    }

    [HttpGet]
    public async Task<ActionResult> Edit(Guid id)
    {
        return View(await _dictionary.GetRecordById(id));
    }

    [HttpGet]
    public async Task<ActionResult> Delete(Guid id)
    {
        return View(await _dictionary.GetRecordById(id));
    }

    [HttpPost]
    public async Task<ActionResult> Add([Bind("Surname", "PhoneNum")] PhoneDictionaryModel model)
    {
        if (ModelState.IsValid)
        {
            await _dictionary.AddRecord(model);
            return RedirectToAction("Index");
        }
        return View(model);
    }

    [HttpPost]
    public async Task<ActionResult> Edit([Bind("ID", "Surname", "PhoneNum")] PhoneDictionaryModel model)
    {
        if (ModelState.IsValid)
        {
            await _dictionary.UpdateRecord(model);
            return RedirectToAction("Index");
        }
        return View(model);
    }

    [HttpPost]
    public async Task<ActionResult> DeleteSave(Guid id)
    {
        await _dictionary.DeleteRecord(id);
        return RedirectToAction("Index");
    }
}
