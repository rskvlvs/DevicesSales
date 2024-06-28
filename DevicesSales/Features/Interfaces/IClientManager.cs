using DevicesSales.Features.DtoModels;
using DevicesSalesStorage.Models;

namespace DevicesSales.Features.Interfaces
{
    public interface IClientManager
    {
        Guid Create(ClientDto clientDto);

        Task<Client> GetUserByMail(string mail);

        Task<Client> GetUserById(Guid clientId);
    }
}
