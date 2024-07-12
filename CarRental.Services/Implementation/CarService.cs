using Car_Rental.Abstraction;
using CarRental.Domain;
using CarRental.Dto;
using CarRental.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Services.Implementation;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<IEnumerable<CarDTO>> GetAllAsync()
    {
        var cars = await _carRepository.GetAllAsync();
        return cars.Select(c => new CarDTO
        {
            Id = c.Id,
            LicensePlate = c.LicensePlate,
            Model = c.Model,
            Manufacturer = c.Manufacturer,
            Year = c.Year
        }).ToList();
    }

    public async Task<CarDTO> GetByIdAsync(int id)
    {
        var car = await _carRepository.GetByIdAsync(id);
        if (car == null) return null;

        return new CarDTO
        {
            Id = car.Id,
            LicensePlate = car.LicensePlate,
            Model = car.Model,
            Manufacturer = car.Manufacturer,
            Year = car.Year
        };
    }

    public async Task<CarDTO> CreateAsync(CarDTO carDto)
    {
        var car = new Car
        {
            LicensePlate = carDto.LicensePlate,
            Model = carDto.Model,
            Manufacturer = carDto.Manufacturer,
            Year = carDto.Year
        };

        var createdCar = await _carRepository.AddAsync(car);
        carDto.Id = createdCar.Id;
        return carDto;
    }

    public async Task<CarDTO> UpdateAsync(int id, CarDTO carDto)
    {
        var car = await _carRepository.GetByIdAsync(id);
        if (car == null) return null;

        car.LicensePlate = carDto.LicensePlate;
        car.Model = carDto.Model;
        car.Manufacturer = carDto.Manufacturer;
        car.Year = carDto.Year;

        await _carRepository.UpdateAsync(car);
        return carDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _carRepository.DeleteAsync(id);
    }
}
