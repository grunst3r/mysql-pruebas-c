
using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public class Mysql
    {
        private static Mysql instancia;

        private MySqlConnection conexion;
        private MySqlCommand comando;
  
        private const string conectando = "Server=localhost;Port=3306;Database=nicsmedia;Uid=nicsmedia_contro;password=clave;";
        private Mysql() {
    
            this.conexion = new MySqlConnection(conectando);
            this.comando = conexion.CreateCommand();
            if (!this.verificarConexion())  MessageBox.Show("Conexión: No se ha podido establecer conexión con Mysql");
        }

        public static Mysql query
        {
            get
            {
                if (instancia == null)
                    instancia = new Mysql();
                return instancia;
            }
        }

        public bool verificarConexion()
        {
            bool retorna = false;
            try
            {
                this.conexion.Open();
                retorna = true;
                this.conexion.Close();
            }
            catch
            {
                retorna = false;
            }
            return retorna;
        }

          public bool leer(MySqlDataReader datos){
                return (datos != null && datos.Read());
          }

        public MySqlDataReader select(string query)
        {
            this.comando.CommandText = query;
            MySqlDataReader reader = null;
            try{
                if (this.conexion != null) this.conexion.Close();
                this.conexion.Open();
                reader = this.comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                MessageBox.Show("Select: " + ex.Message);
            }
            return reader;
        }

        public int proceso(string query)
        {
            this.comando.CommandText = query;
            try
            {
                if (this.conexion != null) this.conexion.Close();
                this.conexion.Open();
                return this.comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                MessageBox.Show("proceso: " + ex.Message);
            }
            return 0;
        }


        public long insert(string query) { return this.proceso(query) > 0 ? this.comando.LastInsertedId : 0;}
        public bool update(string query) { return this.proceso(query) > 0; }
        public bool delete(string query) { return this.proceso(query) > 0; }

        public int count(string query) {
            try
            {
                query = query.ToLower();
                this.comando.CommandText = Regex.Replace(query, @"select(.*)from", "select count(*) from");
                this.conexion.Open();
                return Convert.ToInt32(this.comando.ExecuteScalar());
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                MessageBox.Show("proceso: " + ex.Message);
            }
            return 0;
        }

}