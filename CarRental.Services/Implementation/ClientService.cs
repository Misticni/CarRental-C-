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

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<IEnumerable<ClientDTO>> GetAllAsync()
    {
        var clients = await _clientRepository.GetAllAsync();
        return clients.Select(c => new ClientDTO
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
            DOB = c.DOB,
            Address = c.Address,
            Nationality = c.Nationality,
            RentalStartDate = c.RentalStartDate,
            RentalEndDate = c.RentalEndDate,
            CarId = c.CarId
        }).ToList();
    }

    public async Task<ClientDTO> GetByIdAsync(int id)
    {
        var client = await _clientRepository.GetByIdAsync(id);
        if (client == null) return null;

        return new ClientDTO
        {
            Id = client.Id,
            FirstName = client.FirstName,
            LastName = client.LastName,
            DOB = client.DOB,
            Address = client.Address,
            Nationality = client.Nationality,
            RentalStartDate = client.RentalStartDate,
            RentalEndDate = client.RentalEndDate,
            CarId = client.CarId
        };
    }

    public async Task<ClientDTO> CreateAsync(ClientDTO clientDto)
    {
        var client = new Client
        {
            FirstName = clientDto.FirstName,
            LastName = clientDto.LastName,
            DOB = clientDto.DOB,
            Address = clientDto.Address,
            Nationality = clientDto.Nationality,
            RentalStartDate = clientDto.RentalStartDate,
            RentalEndDate = clientDto.RentalEndDate,
            CarId = clientDto.CarId
        };

        var createdClient = await _clientRepository.AddAsync(client);
        clientDto.Id = createdClient.Id;
        return clientDto;
    }

    public async Task<ClientDTO> UpdateAsync(int id, ClientDTO clientDto)
    {
        var client = await _clientRepository.GetByIdAsync(id);
        if (client == null) return null;

        client.FirstName = clientDto.FirstName;
        client.LastName = clientDto.LastName;
        client.DOB = clientDto.DOB;
        client.Address = clientDto.Address;
        client.Nationality = clientDto.Nationality;
        client.RentalStartDate = clientDto.RentalStartDate;
        client.RentalEndDate = clientDto.RentalEndDate;
        client.CarId = clientDto.CarId;

        await _clientRepository.UpdateAsync(client);
        return clientDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _clientRepository.DeleteAsync(id);
    }
}
