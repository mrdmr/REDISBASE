using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using cacheServis;
using cacheServis.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using redisTest.Models;
using StackExchange.Redis;

namespace redisTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICacheService _cacheService;
        private readonly CacheSettings _cacheSettings;

        public HomeController(ILogger<HomeController> logger, ICacheService cacheService, IOptions<CacheSettings> cacheSettings)
        {
            _logger = logger;
            _cacheService = cacheService;
            _cacheSettings = cacheSettings.Value;
        }
        
        public IActionResult Index()
        {
            CacheSettings cS = new CacheSettings()
            {
                Host = "TEST",
                Port = "80"
            };
            _cacheService.CacheEkle(_cacheService.GetDb((int) CacheSettings.DatabaseName.Iq),"AAA",cS);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}