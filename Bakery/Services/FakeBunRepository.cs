using Bakery.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bakery.Services
{
    public class FakeBunRepository : IRepository<Bun>
    {
        private static List<Bun> _buns;
        private static int _lastId;

        static FakeBunRepository()
        {
            _buns = new List<Bun>();
            _buns.Add(new Bun("Малиновый пирог", 95, DateTime.Now - TimeSpan.FromMinutes(59.5), DateTime.Now.AddDays(1), TimeSpan.FromDays(2)) { Id = ++_lastId });
            _buns.Add(new Bun("Черничный пирог", 90, DateTime.Now - TimeSpan.FromMinutes(56.3), DateTime.Now.AddDays(1), TimeSpan.FromDays(2)) { Id = ++_lastId });
            _buns.Add(new Bun("Багет", 30, DateTime.Now - TimeSpan.FromMinutes(59.1), DateTime.Now.AddDays(1), TimeSpan.FromDays(2)) { Id = ++_lastId });
            _buns.Add(new Bun("Батон", 20, DateTime.Now - TimeSpan.FromMinutes(57.2), DateTime.Now.AddDays(1), TimeSpan.FromDays(2)) { Id = ++_lastId });
            _buns.Add(new Bun("Сметанник", 90, DateTime.Now - TimeSpan.FromMinutes(58.5), DateTime.Now.AddHours(0.5), TimeSpan.FromHours(1)) { Id = ++_lastId });
            _buns.Add(new Pretzel(60, DateTime.Now, DateTime.Now.AddDays(1), TimeSpan.FromDays(2)) { Id = ++_lastId });
            _buns.Add(new SourCreamPie(80, DateTime.Now, DateTime.Now.AddDays(1), TimeSpan.FromDays(2)) { Id = ++_lastId });
            _buns.Add(new Bun("Пирожок с яблоками", 25, DateTime.Now - TimeSpan.FromMinutes(55), DateTime.Now.AddDays(1), TimeSpan.FromDays(2)) { Id = ++_lastId });
            _buns.Add(new Bun("Пирожок с капустой", 20, DateTime.Now - TimeSpan.FromMinutes(55.5), DateTime.Now.AddDays(1), TimeSpan.FromDays(2)) { Id = ++_lastId });
            _buns.Add(new Bun("Ватрушка", 30, DateTime.Now - TimeSpan.FromMinutes(54.3), DateTime.Now.AddDays(1), TimeSpan.FromDays(2)) { Id = ++_lastId });
            _buns.Add(new Bun("Пончик", 40, DateTime.Now - TimeSpan.FromMinutes(53.7), DateTime.Now.AddDays(1), TimeSpan.FromDays(2)) { Id = ++_lastId });
            _buns.Add(new Bun("Шаурма", 99.90, DateTime.Now - TimeSpan.FromMinutes(53), DateTime.Now.AddDays(1), TimeSpan.FromDays(2)) { Id = ++_lastId });
        }

        public void Add(Bun bun)
        {
            bun.Id = ++_lastId;
            _buns.Add(bun);
        }

        public void Delete(int id)
        {
            if (_buns.Any(b => b.Id == id))
                _buns.RemoveAll(b => b.Id == id);
        }

        IEnumerable<Bun> IRepository<Bun>.Get()
        {
            return _buns;
        }

        public Bun Get(int id)
        {
            return _buns.FirstOrDefault(b => b.Id == id);
        }

        public void Update(int id, Bun entity)
        {
            var bunIndex = _buns.FindIndex(b => b.Id == id);
            if (bunIndex < 0)
                return;
            entity.Id = id;
            _buns[bunIndex] = entity;
        }
    }
}
