using System;
using SISCO.Repositories;
using NLog;

namespace SISCO.App
{
    public class DataManager
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        public bool TestConnection(string server, string port, string database, string username, string password)
        {
            try
            {
                // ReSharper disable once InconsistentNaming
                var Repository = new TestRepository();
                string rs = string.Format("metadata=res://*/Context.DataModel.csdl|res://*/Context.DataModel.ssdl|res://*/Context.DataModel.msl;provider=MySql.Data.MySqlClient;provider connection string=';Data Source={0};Port={1};User ID={2};Password={3};persistsecurityinfo=True;Database={4};Allow User Variables=True;AllowZeroDateTime=true;ConvertZeroDateTime=true';", server, port, username, password, database);
                Repository.ConnectionString = rs;

                return Repository.TestConnection(rs);
            }
            catch (Exception ex)
            {
                //throw ex;
                //log.Info(ex);
                # if DEBUG
                System.Windows.Forms.MessageBox.Show(ex.Message + " " + ex.InnerException + " " + ex.StackTrace);
                # endif
                return false;
            }
        }

        public int PrefixCodeGenerator (string tableName, int branchId, int tgl, int bulan, int tahun, ref string prefix)
        {
            return new PrefixCodeRepository().GenerateCode(tableName, branchId, tgl, bulan, tahun, ref prefix);
        }

        public int GenerateBookingPod(int bookingCount, int branchId, int tgl, int bulan, int tahun, ref string prefix)
        {
            return new PrefixCodeRepository().BookingGenerator(bookingCount, branchId, tgl, bulan, tahun, ref prefix);
        }
    }
}