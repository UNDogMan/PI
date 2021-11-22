using PD.DataCore.Interfaces;
using PD.DataCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;

namespace PD.ASMX
{
    /// <summary>
    /// Сводное описание для WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class PDService : System.Web.Services.WebService
    {

        private readonly IPhoneDictionary _dictionary;

        public PDService()
        {
            if (AppSettings.UseDB)
            {
                _dictionary = new DataEF.Repository.EFPhoneDictionaryRepository("defaul");
            }
            else
            {
                _dictionary = new DataJson.Repository.JsonPhoneRepository();
            }
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Привет всем!";
        }

        [WebMethod]
        public List<PhoneDictionaryModel> GetAll()
        {
            return _dictionary.GetRecords().Result.ToList();
        }

        [WebMethod]
        public PhoneDictionaryModel Get(Guid id)
        {
            return _dictionary.GetRecordById(id).Result;
        }

        [WebMethod]
        public void Post(PhoneDictionaryModel value)
        {
            _dictionary.AddRecord(value).Wait();
        }

        [WebMethod]
        public void Put(PhoneDictionaryModel value)
        {
            _dictionary.UpdateRecord(value).Wait();
        }

        [WebMethod]
        public void Delete(Guid id)
        {
            _dictionary.DeleteRecord(id).Wait();
        }
    }
}
