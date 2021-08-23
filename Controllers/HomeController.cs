using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        private IStoreRepository repository;

        public int pageSize = 4;

        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index(int productPage = 1)
        {
            return View(new ProductsListViewModel { 
            Products = repository.Products
            .OrderBy( p => p.ProductID)
            .Skip((productPage = 1) * pageSize)
            .Take(pageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = pageSize,
                TotalItems = repository.Products.Count()
            }
            });
        }

    }
}
