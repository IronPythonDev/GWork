using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CloudIpspSDK;
using CloudIpspSDK.Checkout;

namespace GameFreelance.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ILogger<PaymentController> _logger;
        public PaymentController(ILogger<PaymentController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreatePayment()
        {
            Config.MerchantId = 1397120;
            Config.SecretKey = "test";

            var req = new CheckoutRequest {
                order_id = Guid.NewGuid().ToString("N"),
                amount = 100,
                order_desc = "checkout json demo",
                currency = "UAH"
            };
            var resp = new Url().Post(req);
            if (resp.Error == null) {
                string url = resp.checkout_url;
                Console.WriteLine(url);
                return Redirect(url);
            }

            return View("Index");


        }
    }
}