using CarRental.Domain;

namespace Car_Rental.Abstraction
{
    public interface IClientRepository
    {
            Task<IEnumerable<Client>> GetAllAsync();
            Task<Client> GetByIdAsync(int id);
            Task<Client> AddAsync(Client client);
            Task<Client> UpdateAsync(Client client);
            Task<bool> DeleteAsync(int id);
    }
}
