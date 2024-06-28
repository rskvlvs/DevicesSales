using AutoMapper;
using DevicesSales.Features.DtoModels;
using DevicesSales.Features.Interfaces;
using DevicesSalesLogic.Interfaces;
using DevicesSalesStorage;
using DevicesSalesStorage.Models;

namespace DevicesSales.Features.Managers
{
    public class ClientManager : IClientManager 
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        private readonly DataContext _dataContext;

        public ClientManager(IMapper mapper,  IClientRepository clientRepository, DataContext dataContext)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
            _dataContext = dataContext;
        }

        public Guid Create(ClientDto clientDto)
        {
            var client = new Client()
            {
                ClientId = Guid.NewGuid(),
                Name = clientDto.Name,
                Surname = clientDto.Surname,
                Email = clientDto.Email
            };
            _clientRepository.Create(_dataContext, client);
            _dataContext.SaveChanges();
            return client.ClientId;
        }
        public async Task<Client> GetUserByMail(string mail)
        {
            var client = await _clientRepository.GetByMail(_dataContext, mail);
            return client;
        }

        public async Task<Client> GetUserById(Guid clientId)
        {
            var client = await _clientRepository.GetById(_dataContext, clientId);
            return client;
        }

    }
}
