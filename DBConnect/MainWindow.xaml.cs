using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DBConnect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            //connect tp database and get all patients
            string connString = "Data Source=Server; Initial Catalog=VARIAN;Integrated Security=False;User Id=testuser;Password=pass1234";
            SqlConnection sqlCon = new SqlConnection(connString);
            string sqlString = "SELECT PatientId FROM dbo.Patient";
            Patients = new List<string>();
            sqlCon.Open();
            using (SqlCommand sqlCmd = new SqlCommand(sqlString, sqlCon))
            {
                using (SqlDataReader sqlRd = sqlCmd.ExecuteReader())
                {
                    while (sqlRd.Read())
                    {
                        Patients.Add(sqlRd["PatientId"].ToString());
                    }
                }
            }
        }

        public List<string> Patients { get; private set; }
    }
}
