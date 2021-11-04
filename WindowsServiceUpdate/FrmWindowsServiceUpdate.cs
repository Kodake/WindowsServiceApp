using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsServiceUpdate
{
    public partial class FrmWindowsServiceUpdate : Form
    {

        #region Variables
        private Timer _timer;
        public class Marcas
        {
            public int Id { set; get; }
            public DateTime Marca { set; get; }
            public DateTime? MarcaUpdated { set; get; }
            public string Guid { set; get; }
        }
        #endregion
        #region MetodosServicio
        public FrmWindowsServiceUpdate()
        {
            InitializeComponent();
        }
        #endregion
        #region MetodosPrivados
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                _timer = new Timer();
                _timer.Interval = int.Parse(ConfigurationManager.AppSettings["IntervaloEjecucion"]);
                _timer.Enabled = true;
                this._timer.Tick += new EventHandler(EventoTemporizador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EventoTemporizador(object sender, EventArgs e)
        {
            try
            {
                List<Marcas> marcas = new List<Marcas>();
                string conString = ConfigurationManager.ConnectionStrings["Conn"].ToString();
                SqlConnection conn = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand("SP_MARCAS_GET", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Marcas marca = new Marcas();
                    marca.Id = Convert.ToInt32(dr["Id"]);
                    marca.Marca = Convert.ToDateTime(dr["Marca"]);
                    marca.MarcaUpdated = (dr["MarcaUpdated"] == DBNull.Value) ? (DateTime?)null : ((DateTime)dr["MarcaUpdated"]);
                    marca.Guid = (dr["Guid"] == DBNull.Value) ? null : ((string)dr["Guid"]);
                    marcas.Add(marca);
                }
                conn.Close();
                UpdateMarcas(marcas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateMarcas(List<Marcas> marcas)
        {
            try
            {
                string conString = ConfigurationManager.ConnectionStrings["Conn"].ToString();
                SqlConnection conn = new SqlConnection(conString);

                foreach (var item in marcas)
                {
                    if (item.MarcaUpdated == null && item.Guid == null)
                    {
                        SqlCommand cmd = new SqlCommand("SP_MARCAS_UPDATE", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        conn.Open();
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Guid", Guid.NewGuid().ToString());
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            _timer.Enabled = false;
            _timer.Stop();
        }
        #endregion
    }
}
