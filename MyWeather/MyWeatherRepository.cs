using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using MyWeather.Data;

namespace MyWeather
{
    public class MyWeatherRepository
    {
        string _dbPath;

        public string StatusMessage { get; set; }

        private SQLiteAsyncConnection conn;

        private async Task Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteAsyncConnection(_dbPath);

            await conn.CreateTableAsync<CityTbl>();
        }

        public MyWeatherRepository(string dbPath)
        {
            _dbPath = dbPath;                        
        }

        public async Task AddNewCity(string name, double lon, double lat)
        {            
            int result = 0;
            try
            {
                await Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                result = await conn.InsertAsync(new CityTbl {
                    Name = name, 
                    Lon = lon,
                    Lat = lat
                });

                StatusMessage = string.Format("{0} record(s) added (Name: {1}, Lon = {2}, Lat = {3})", result, name, lon, lat);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }

        public async Task<List<CityTbl>> GetAllCity()
        {
            try
            {
                await Init();

                return await conn.Table<CityTbl>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<CityTbl>();
        }

        public async Task<int> UpdateCity(CityTbl city)
        {
            int result = 0; 
            
            try
            {
                await Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(city.Name))
                    throw new Exception("Valid name required");

                city.UpdateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

                result = await conn.UpdateAsync(city);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to update data. {0}", ex.Message);
            }

            return result;
        }

        public async Task<int> DeleteCity(int cityId)
        {
            int result = 0;

            try
            {
                await Init();

                result = await conn.DeleteAsync<CityTbl>(cityId);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete data. {0}", ex.Message);
            }

            return result;
        }

        public async Task<CityTbl> GetCityByName(string name)
        {
            try
            {
                await Init();

                var city = from c in conn.Table<CityTbl>()
                           where c.Name == name
                           select c;

                return await city.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to get city {0} by name data. {1}", name, ex.Message);
            }

            return new CityTbl();
        }
    }
}
