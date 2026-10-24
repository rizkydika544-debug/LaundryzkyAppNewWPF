using MySql.Data.MySqlClient;

class Koneksi
{
    public static MySqlConnection GetConn()
    {
        return new MySqlConnection("server=localhost;user=root;password=;database=laundryzky;");
    }
}