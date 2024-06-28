using DevicesSales.Features.DtoModels;

namespace DevicesSales.Features.Interfaces
{
    public interface ISaleManager
    {
        void Create(SaleDto saleDto, Guid clientId);

        void Delete(Guid isnNode);
    }
}
