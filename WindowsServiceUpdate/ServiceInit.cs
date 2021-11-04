using System;
using System.Timers;
using System.ServiceProcess;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace WindowsServiceUpdate
{
    public partial class ServiceInit : ServiceBase
    {
        #region Variables
        private System.Timers.Timer _timer;
        public class Marcas
        {
            public int Id { set; get; }
            public DateTime Marca { set; get; }
            public DateTime? MarcaUpdated { set; get; }
            public string Guid { set; get; }
        }
        #endregion
        #region MetodosServicio
        public ServiceInit()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            IniciarServicio(null, null);
        }

        protected override void OnStop()
        {
            DetenerServicio(null, null);
        }
        #endregion
        #region MetodosPrivados
        private void IniciarServicio(object sender, EventArgs e)
        {
            try
            {
                _timer = new System.Timers.Timer(5000);
                _timer.Elapsed += new ElapsedEventHandler(EventoTemporizador);
                _timer.Enabled = true;
                _timer.Start();
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
                string conString = @"Data Source=.;Initial Catalog=WindowsServiceApp;Integrated Security=True";
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
                string conString = @"Data Source=.;Initial Catalog=WindowsServiceApp;Integrated Security=True";
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

        private void DetenerServicio(object sender, EventArgs e)
        {
            _timer.Enabled = false;
            _timer.Stop();
        }
        #endregion
    }
}
