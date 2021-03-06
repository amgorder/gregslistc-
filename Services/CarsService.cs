using gregslist.Repositories;
using System.Collections.Generic;
using gregslist.Models;
using System;

namespace gregslist.Services
{
    public class CarsService
    {
        private readonly CarsRepository _repo;

        public CarsService(CarsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Car> Get()
        {
            return _repo.Get();
        }

        internal Car Create(Car newCar)
        {
            return _repo.Create(newCar);
        }

        internal Car Get(int id)
        {
            Car car = _repo.Get(id);
            if (car == null)
            {
                throw new Exception("invalid id");
            }
            return car;
        }
        internal Car Edit(Car editCar)
        {
            Car original = Get(editCar.Id);

            original.Make = editCar.Make != null ? editCar.Make : original.Make;
            original.Model = editCar.Model != null ? editCar.Model : original.Model;
            original.Year = editCar.Year != null ? editCar.Year : original.Year;
            original.Price = editCar.Price != null ? editCar.Price : original.Price;
            original.Color = editCar.Color != null ? editCar.Color : original.Color;
            original.Url = editCar.Url != null ? editCar.Url : original.Url;

            return _repo.Edit(original);
        }
        internal Car Delete(int id)
        {
            Car original = Get(id);
            _repo.Delete(id);
            return original;
        }
    }
}