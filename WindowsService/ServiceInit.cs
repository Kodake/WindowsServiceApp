using System;
using System.Threading;
using System.Configuration;
using System.ServiceProcess;
using System.Data.SqlClient;

namespace WindowsService
{
    public partial class ServiceInit : ServiceBase
    {
        #region Variables
        private System.Windows.Forms.Timer _timer;
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
                _timer = new System.Windows.Forms.Timer();
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
                string conString = ConfigurationManager.ConnectionStrings["Conn"].ToString();
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
