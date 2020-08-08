using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace redis.cache.netcore_vs2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        public readonly IDistributedCache _distributedCache;

        public HealthCheckController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        [HttpGet]
        public string GetStatus()
        {
            var key = "healthCheckStatus";
            var lastStatus = _distributedCache.GetString(key);
            var actualStatus = $"{DateTime.UtcNow:0}";

            _distributedCache.SetString(key, actualStatus);

            var healthCheckResult = $"Actual Status: {actualStatus} | Last Status: {lastStatus}";

            return healthCheckResult;
        }
    }
}