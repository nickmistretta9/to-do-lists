using Microsoft.Extensions.Configuration;

namespace ToDos.Repositories
{
    public class BaseRepository
    {
        private static string _connection;
        private readonly IConfiguration _config;

        public BaseRepository(IConfiguration config)
        {
            _config = config;
        }

        public string DBConnection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = _config.GetConnectionString("Default");
                }

                return _connection;
            }
        }
    }
}
