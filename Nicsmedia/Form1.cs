using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace Nicsmedia
{
    public partial class Form1 : Form
    {
        static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        static readonly double MaxUnixSeconds = (DateTime.MaxValue - UnixEpoch).TotalSeconds;
        MySqlDataReader d;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //MySqlDataReader d = Mysql.query.select("SELECT * FROM web_usuarios_ limit 3");
            //while ( Mysql.query.leer(d)   )
            //{
            //    MessageBox.Show("multiple " + d["user_nombre"]);
            //}
            //MessageBox.Show("bool " + Mysql.query.update("update prueba set numero = '6000' where id = '6'  ") );
            //MessageBox.Show("num " + Mysql.query.insert("INSERT INTO prueba (nombre,numero) VALUES ('cholo8888',8888);")  );
            //MessageBox.Show("delete bool " + Mysql.query.delete("DELETE FROM prueba WHERE id = 3"));
            //MessageBox.Show("count " + Mysql.query.count("SELECT * FROM prueba"));

            d = Mysql.query.select("SELECT * FROM web_usuarios");
            while ( Mysql.query.leer(d) )
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = "" + d["user_nombre"];
                item.Value = d["user_id"];
                usuarios.Items.Add(item);
            }
   

        }
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }

        public static DateTime tiempo(double unixTimeStamp)
        {
            return unixTimeStamp > MaxUnixSeconds
               ? UnixEpoch.AddMilliseconds(unixTimeStamp)
               : UnixEpoch.AddSeconds(unixTimeStamp);
        }

        private void usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportes.Items.Clear();
            string idsel = (usuarios.SelectedItem as ComboboxItem).Value.ToString();
            string nombre = (usuarios.SelectedItem as ComboboxItem).Text.ToString();
            datos.Text = idsel + " - " + nombre;
 
            MySqlDataReader s = Mysql.query.select("SELECT * FROM web_reporte_dia WHERE repd_iduser = '" + idsel + "' ORDER BY repd_hingreso DESC");
            while ( Mysql.query.leer(s) )
            {
                double ingreso = double.Parse(s["repd_hingreso"].ToString());
                DateTime d = tiempo(ingreso);
                reportes.Items.Add(s["repd_fecha"] + " --- " + d.Year + "/" + d.Month + "/" + d.Day + " " + d.Hour + ":" + d.Minute + ":" + d.Second);
            }

        }
    }
}
