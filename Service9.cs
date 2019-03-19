using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsService9
{
	public partial class Service9 : ServiceBase
	{
		Timer timer = new Timer();
		public Service9()
		{
			InitializeComponent();
		}

		public void ReadData()
		{
			SqlConnection con = new SqlConnection("Data Source=HARSHIT\\SQL_INSTANCE;Database=sampleDB;User Id=sa;Password=1344");
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select EmpName, Salary from EmpDetails", con);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			con.Open();
			
			foreach(DataRow dataRow in dataTable.Rows)
			{
				SqlCommand cmd1 = new SqlCommand("insert into EmpDetails1 values('" + dataRow[0].ToString() + "','" + dataRow[1].ToString() + "')", con);
				cmd1.ExecuteNonQuery();
			}
			con.Close();
			dataTable.Dispose();
			sqlDataAdapter.Dispose();
			
		}

		protected override void OnStart(string[] args)
		{
			WriteToFile("Service is started at " + DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss"));
			timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
			string timer1 = System.Configuration.ConfigurationManager.AppSettings["reconnect9"];
			timer.Interval = int.Parse(timer1);
			ReadData();
			timer.Enabled = true;
		}

		protected override void OnStop()
		{
			WriteToFile("Service is stopped at " + DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss"));
		}

		private void OnElapsedTime(object source, ElapsedEventArgs args)
		{
			ReadData();
			WriteToFile("Service is recall at " + DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss"));
		}
		
		public void WriteToFile(string message)
		{
			if(!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Logs"))
			{
				Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Logs");
			}
			string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace("/", "_") + ".txt";
			if(!File.Exists(filepath))
			{
				using (StreamWriter sw = File.CreateText(filepath))
					sw.WriteLine(message);
			}
			else
			{
				using (StreamWriter sw = File.AppendText(filepath))
					sw.WriteLine(message);
			}
		}
	}
}
















//Read SQl Data
//Format SQL data as required by API
//Send data in the format by calling API in POST method
//Get response back.
//Retry if call failed


/*	private void ReadData()
		{
			try
			{
				using (SqlConnection connection = new SqlConnection("Data Source=192.168.0.113;Database=etimetracklite1;User Id=sa;Password=Admin@123"))
				{
					using (SqlCommand command = new SqlCommand())
					{
						command.Connection = connection;
						command.CommandText = "select * from AttendanceLogs";
						connection.Open();
						command.ExecuteNonQuery();
						connection.Close();
					}
				}
			}
			catch (Exception ex)
			{
			}
		} 
		public void ReadData()
		{
			using (var connection = new SqlConnection("Data Source=192.168.1.21,1437;Database=etimetracklite1;User Id=sa;Password=Admin@123"))
			{
				using (var command = new SqlCommand())
				{
					SqlDataReader reader;

					command.Connection = connection;
					// Next command is your query. 
					command.CommandText = "SELECT * FROM AttendanceLogs";
					command.CommandType = CommandType.Text;

					connection.Open();

					reader = command.ExecuteReader();
					WriteToFile(command.CommandText);
					// Data is accessible through the DataReader object here.                 
				}
			}
		}*/


/*	while (reader.Read())
			{
				Console.Write(reader["EmpID"].ToString() + ", ");
				Console.Write(reader["EmpName"].ToString() + ", ");
				Console.Write(reader["Salary"].ToString() + ", ");
				Console.WriteLine(reader["City"].ToString() + ", ");
			}

	SqlCommand cmd = new SqlCommand("SELECT * FROM AttendanceLogs", con);
			*/
