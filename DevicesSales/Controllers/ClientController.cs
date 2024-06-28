using DevicesSales.Features.DtoModels;
using DevicesSales.Features.Interfaces;
using DevicesSalesStorage.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevicesSales.Controllers
{
    [Route(route)]
    public class ClientController : Controller 
    {

        private readonly IClientManager _clientManager;
        private readonly ISaleManager _saleManager;
        public const string route = "Client";

        private static Guid clientId;

        public ClientController(IClientManager clientManager, ISaleManager saleManager)
        {
            _clientManager = clientManager;
            _saleManager = saleManager;
        }

        [HttpGet(nameof(RegView), Name = nameof(RegView))]
        public async Task<ActionResult> RegView()
        {
            return View(new ClientDto());
        }

        [HttpGet(nameof(LogView), Name = nameof(LogView))]
        public async Task<ActionResult> LogView()
        {
            return View(new LoginDto());
        }

        [HttpGet(nameof(Menu), Name = nameof(Menu))]
        public async Task<ActionResult> Menu()
        {
            return View();
        }

        [HttpGet(nameof(SaleView), Name = nameof(SaleView))]
        public async Task<ActionResult> SaleView()
        {
            return View(new SaleDto());
        }

        [HttpGet(nameof(CartView), Name = nameof(CartView))]
        public async Task<ActionResult> CartView()
        {
            var client = await _clientManager.GetUserById(clientId); 
            return View(client.Sales);
        }

        [HttpPost(nameof(CreateSaleView), Name = nameof(CreateSaleView))]
        public async Task<ActionResult> CreateSaleView(SaleDto saleDto)
        {
            if (!ModelState.IsValid)
                return View(nameof(SaleView), saleDto);
            try
            {
                switch (saleDto.ProductName)
                {
                    case "Наушники": { saleDto.Price = 50; break; }
                    case "Мышка": { saleDto.Price = 30; break; }
                    case "Коврик": { saleDto.Price = 20; break; }
                    case "Клавиатура": { saleDto.Price = 70; break; }
                }
                _saleManager.Create(saleDto, clientId);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(nameof(SaleView), saleDto);
            }
            return View(nameof(Menu));
        }

        //Вход в акк
        [HttpPost(nameof(LoginClientView), Name = nameof(LoginClientView))]
        public async Task<ActionResult> LoginClientView(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return View(nameof(LogView), loginDto);
            try
            {
                var client = await _clientManager.GetUserByMail(loginDto.Email);
                if (client == null) throw new Exception("Работник не найден");
                clientId = client.ClientId;
                return View(nameof(Menu));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(nameof(LogView), loginDto);
            }
        }

        //Логин воркера
        [HttpPost(nameof(CreateClientView), Name = nameof(CreateClientView))]
        public async Task<ActionResult> CreateClientView(ClientDto clientDto)
        {
            if (!ModelState.IsValid)
                return View(nameof(RegView), clientDto);
            var temp = await _clientManager.GetUserByMail(clientDto.Email);
            if (temp != null)
            {
                ModelState.AddModelError("Email", "Работник с таким email уже существует");
                return View(nameof(RegView), clientDto);
            }
            try
            {
                clientId = _clientManager.Create(clientDto);
                return View(nameof(Menu));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(nameof(RegView), clientDto);
            }
        }

        [HttpPost(nameof(DeleteOrder), Name = nameof(DeleteOrder))]
        public async Task<ActionResult> DeleteOrder(Guid saleId)
        {
            var client = await _clientManager.GetUserById(clientId);
            try
            {
                _saleManager.Delete(saleId);
                return View(nameof(CartView), client.Sales);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(nameof(CartView), client.Sales);
            }
        }

    }
}
