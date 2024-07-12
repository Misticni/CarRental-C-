using CarRental.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Services.Abstraction;

public interface ICarService
{
    Task<IEnumerable<CarDTO>> GetAllAsync();
    Task<CarDTO> GetByIdAsync(int id);
    Task<CarDTO> CreateAsync(CarDTO carDto);
    Task<CarDTO> UpdateAsync(int id, CarDTO carDto);
    Task<bool> DeleteAsync(int id);
}
