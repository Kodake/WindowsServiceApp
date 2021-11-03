using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsService
{
    public partial class FrmWindowsService : Form
    {
        #region Variables
        private Timer _timer;
        #endregion
        #region MetodosServicio
        public FrmWindowsService()
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

        private void btnDetener_Click(object sender, EventArgs e)
        {
            _timer.Enabled = false;
            _timer.Stop();
        }
        #endregion
    }
}
