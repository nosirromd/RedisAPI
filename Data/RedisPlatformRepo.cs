using System;
using System.Collections.Generic;
using System.Text.Json;
using RedisAPI.Models;
using StackExchange.Redis;

namespace RedisAPI.Data
{
    public class RedisPlatformRepo : IPlatformRepo
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisPlatformRepo(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public void CreatePlatform(Platform plat)
        {
            if(plat == null)
            {
                throw new ArgumentOutOfRangeException(nameof(plat));
            }
            
            var db = _redis.GetDatabase();

            var serialPlat = JsonSerializer.Serialize(plat);

            db.StringSet(plat.Id, serialPlat);
            
        }

        public Platform GetPlatformById(string id) 
        {
            var db = _redis.GetDatabase();

            var serialPlat = db.StringGet(id);

            if (!string.IsNullOrEmpty(serialPlat))
            {
                return JsonSerializer.Deserialize<Platform>(serialPlat);
            }

            return null;
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return null;
        }



    }
    
}