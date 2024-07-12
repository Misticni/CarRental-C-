using CarRental.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Services.Abstraction;
public interface IClientService
{
    Task<IEnumerable<ClientDTO>> GetAllAsync();
    Task<ClientDTO> GetByIdAsync(int id);
    Task<ClientDTO> CreateAsync(ClientDTO clientDto);
    Task<ClientDTO> UpdateAsync(int id, ClientDTO clientDto);
    Task<bool> DeleteAsync(int id);
}