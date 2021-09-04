using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PD.DataCore.Models;
using PD.DataCore.Interfaces;
using System.Threading.Tasks;

namespace PDApplication.Controllers
{
    public class DictController : Controller
    {
        private readonly IPhoneDictionary _dictionary;

        public DictController(IPhoneDictionary dictionary)
        {
            _dictionary = dictionary;
        }

        protected override void HandleUnknownAction(string actionName)
        {
            ViewData["actionName"] = actionName;
            View("NotFound").ExecuteResult(this.ControllerContext);
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
        public async Task<ActionResult> AddSave([Bind(Include = "Surname,PhoneNum")] PhoneDictionaryModel model)
        {
            if (ModelState.IsValid)
            {
                await _dictionary.AddRecord(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> EditSave([Bind(Include = "ID,Surname,PhoneNum")] PhoneDictionaryModel model)
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
}