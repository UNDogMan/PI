using Microsoft.AspNetCore.Mvc;
using PD.DataCore.Interfaces;
using PD.DataCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PD.WebApiCore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PhoneDictionaryController : ControllerBase
{
    private readonly IPhoneDictionary _dictionary;

    public PhoneDictionaryController(IPhoneDictionary dictionary)
    {
        _dictionary = dictionary;
    }

    // GET: api/<PhoneDictionaryController>
    [HttpGet]
    public async Task<IEnumerable<PhoneDictionaryModel>> GetAsync()
    {
        return await _dictionary.GetRecords();
    }

    // GET api/<PhoneDictionaryController>/5
    [HttpGet("{id}")]
    public async Task<PhoneDictionaryModel> Get(Guid id)
    {
        return await _dictionary.GetRecordById(id);
    }

    // POST api/<PhoneDictionaryController>
    [HttpPost]
    public async Task PostAsync([FromBody]PhoneDictionaryModel model)
    {
        await _dictionary.AddRecord(model);
    }

    // PUT api/<PhoneDictionaryController>
    [HttpPut]
    public async Task PutAsync([FromBody] PhoneDictionaryModel model)
    {
        await _dictionary.UpdateRecord(model);
    }

    // DELETE api/<PhoneDictionaryController>/5
    [HttpDelete("{id}")]
    public async Task Delete(Guid id)
    {
        await _dictionary.DeleteRecord(id);
    }
}
