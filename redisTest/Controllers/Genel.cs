using System;
using cacheServis;
using cacheServis.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace redisTest.Controllers
{
    public class Genel : Controller
    {
        private ICacheService _cacheService;

        public Genel(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [Route("cacheGetir")]
        public IActionResult Index()
        {

            var a = _cacheService.CacheGetir<CacheSettings>(_cacheService.GetDb(1), "TESTSINIF");
            return View();
        }
    }
}