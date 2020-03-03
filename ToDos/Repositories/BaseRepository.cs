using Microsoft.Extensions.Configuration;

namespace ToDos.Repositories
{
    public class BaseRepository
    {
        private static string _connection;

        public string DBConnection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = "Data Source=:memory";
                }

                return _connection;
            }
        }
    }
}
