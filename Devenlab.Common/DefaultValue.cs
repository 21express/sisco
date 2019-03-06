using System;

namespace Devenlab.Common
{
    public static class DefaultValue
    {
        public static Guid EMPTY_GUID = new Guid("00000000-0000-0000-0000-000000000000");
        public const int DEFAULT_RECORD_RETRIEVE_AUTOCOMPLETE = 20;
        public const string DEFAULT_NEW_LINE_WEB = "<br/>";
        public const string DEFAULT_NEW_LINE_CONSOLE = "\n";
        public const string SESSION_USER = "THIS_USER_SESSION";
        public const string SQL_DATE_FORMAT = "yyyy-MM-dd hh:mm:ss";
        public const string DOT = ".";
        public const string LOGICAL_SQL = " AND ";
        public const string DEFAULT_DATE_STRING = "01/01/1900 00:00:00";
        public const string DEFAULT_FORMAT_DATETIME = "dd-MM-yyyy HH:mm:ss";
        public const string DEFAULT_FORMAT_DATE = "dd-MM-yyyy";
        public const string DEFAULT_SEPARATOR = "\t";
        public const string DEFAULT_EMPTY = "DEFAULT";
        public const string FILE_UPLOAD_PATH = @"~\Upload\";
        public const string DEFAULT_FILE_INVOICE_EXT = ".lis";
        public const string MESSAGE_SQL_CONSTRAIN_REFERENCE = "Tidak dapat melakukan Penghapusan Data Karena Masih Menjadi Referensi Data Lain";

        // ReSharper disable InconsistentNaming

        /// <summary>
        /// Value is "RowStatus"
        /// </summary>
        public const string COLUMN_ROW_STATUS = "rowstatus";

        /// <summary>
        /// Value is -1
        /// </summary>
        public const int ERROR_VALUE = -1;

        /// <summary>
        /// new DateTime(2000, 1, 1)
        /// </summary>
        public static DateTime DefaultDate
        {
            get
            {
                return new DateTime(2000, 1, 1);
            }
        }

        /// <summary>
        /// VALUE = 0
        /// </summary>
        public const byte ROW_STATUS_ACTIVE = 0;
        /// <summary>
        /// Value = 1
        /// </summary>
        public const byte ROW_STATUS_NOT_ACTIVE = 1;
        /// <summary>
        /// VALUE = 2
        /// </summary>
        public const byte ROW_STATUS_SYSTEM_ONLY = 2;
        /// <summary>
        /// VALUE = 3
        /// </summary>
        public const byte ROW_STATUS_SYSTEM_PROCESS = 3;
        /// <summary>
        /// VALUE = 99
        /// </summary>
        public const byte ROW_STATUS_UNKNOW = 99;

        public static string RowStatusDescription(short value)
        {
            switch (value)
            {
                case 1:
                    return "Not Active";
                case 0:
                    return "Active";
                case 2:
                    return "System Only";
                case 3:
                    return "System Process";
                default:
                    return "Unknown";
            }
        }

        public static byte RowStatusId(string value)
        {
            switch (value)
            {
                case "Not Active":
                    return 1;
                case "Active":
                    return 0;
                case "System Only":
                    return 2;
                case "System Process":
                    return 3;
                default:
                    return 99;
            }
        }

        public const string DEFAULT_STATUS_REGISTER = "REGISTER";
        public const string DEFAULT_STATUS_INPUT = "INPUT";
        public const string DEFAULT_STATUS_PROSES = "PROSES";
        public const string DEFAULT_STATUS_VALID = "VALID";
        public const string DEFAULT_STATUS_INVALID = "INVALID";
        public const string DEFAULT_STATUS_AKTIF = "AKTIF";
        public const string DEFAULT_STATUS_TIDAK_AKTIF = "TIDAK AKTIF";

        public const int DEFAULT_SEVERITY_FATAL = 0;
        public const int DEFAULT_SEVERITY_ERROR = 1;
        public const int DEFAULT_SEVERITY_WARN = 2;
        public const int DEFAULT_SEVERITY_INFO = 3;

        public const string DEFAULT_SYSTEM_CODE_MOBILE = "M";
        public const string DEFAULT_SYSTEM_CODE_WEB = "W";
        public const string DEFAULT_SYSTEM_CODE_SERVICES = "S";
    }
}
