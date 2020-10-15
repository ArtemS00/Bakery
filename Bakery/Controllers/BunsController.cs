using Bakery.Entities;
using Bakery.Models;
using Bakery.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bakery.Controllers
{
    [Route("api/[controller]")]
    public class BunsController : Controller
    {
        private IRepository<Bun> _repository;
        private IBunFactory _factory;

        public BunsController(IRepository<Bun> repository, IBunFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        [HttpGet]
        public IEnumerable<GetBunModel> Get()
        {
            return _repository.Get()
                .Select(b => new GetBunModel(b));
        }

        [HttpGet("{id}")]
        public GetBunModel Get(int id)
        {
            return new GetBunModel(_repository.Get(id));
        }

        [HttpPost]
        public void Post([FromBody]PostBunModel model)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("Model is invalid");

            var bun = _factory.Create(model.Name, model.FullPrice, model.BakedTime, model.ControlTime, model.Lifetime);
            if (bun != null)
                _repository.Add(bun);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]PostBunModel model)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("Model is invalid");

            var bun = _factory.Create(model.Name, model.FullPrice, model.BakedTime, model.ControlTime, model.Lifetime);
            if (bun != null)
                _repository.Update(id, bun);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("Model is invalid");

            _repository.Delete(id);
        }
    }
}
