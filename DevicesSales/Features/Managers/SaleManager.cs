using AutoMapper;
using DevicesSales.Features.DtoModels;
using DevicesSales.Features.Interfaces;
using DevicesSalesLogic.Interfaces;
using DevicesSalesLogic.Repositories;
using DevicesSalesStorage;
using DevicesSalesStorage.Models;

namespace DevicesSales.Features.Managers
{
    public class SaleManager : ISaleManager
    {
        private readonly IMapper _mapper;
        private readonly ISaleRepository _saleRepository;
        private readonly DataContext _dataContext;

        public SaleManager(IMapper mapper, ISaleRepository saleRepository, DataContext dataContext)
        {
            _mapper = mapper;
            _saleRepository = saleRepository;
            _dataContext = dataContext;
        }

        public void Create(SaleDto saleDto, Guid clientId)
        {
            if (!_dataContext.Clients.Any(x => x.ClientId == clientId))
                throw new Exception($"Пользователь с Id {clientId} не найден!");
            var sale = new Sale()
            {
                SaleId = Guid.NewGuid(),
                ClientId = clientId,
                ProductName = saleDto.ProductName,
                Price = (uint)saleDto.Price,
            };
            _saleRepository.Create(_dataContext, sale);
            _dataContext.SaveChanges();
        }

        public void Delete(Guid isnNode)
        {
            _saleRepository.Delete(_dataContext, isnNode);
            _dataContext.SaveChanges(); 
        }
    }
}
