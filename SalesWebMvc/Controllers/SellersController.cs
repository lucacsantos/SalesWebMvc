using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerServivice;

        public SellersController(SellerService sellerService)
        {
            _sellerServivice = sellerService;
        }
        public IActionResult Index()
        {
            var list = _sellerServivice.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerServivice.Insert(seller);

            return RedirectToAction(nameof(Index));
        }
    }
}
