using System;
using System.Configuration;
using System.ServiceProcess;
using System.Data.SqlClient;
using System.Timers;

namespace WindowsService
{
    public partial class ServiceInit : ServiceBase
    {
        #region Variables
        private System.Timers.Timer _timer;
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
                string conString = @"Data Source=.;Initial Catalog=WindowsServiceApp;Integrated Security=True";
                SqlConnection conn = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand("SP_MARCAS_INSERT", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.BeginExecuteNonQuery();
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
