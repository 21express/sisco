using System;
using System.Collections;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class ApiLogModel : IBaseModel
    {
        public int? RefId { get; set; }
        public string MethodName { get; set; }
        public string Message { get; set; }
        public string Ip { get; set; }
        public short ApiType { get; set; }
        public DateTime InsertedAt { get; set; }

		public Int32 Id { get; set;}
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
    }
}


