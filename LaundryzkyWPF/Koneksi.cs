using MySql.Data.MySqlClient;

namespace LaundryzkyWPF
{
    public static class Koneksi
    {
        public static string ConnectionString => "server=localhost;user=root;password=;database=laundryzky;";

        public static MySqlConnection GetConn()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
