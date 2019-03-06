using Devenlab.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.Models
{
    public class BookingPodModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime DateProcess { get; set; }
        public string Code { get; set; }
        public int? SprintId { get; set; }
        public int BranchId { get; set; }
        public int BookingCount { get; set; }
        public string BookingStart { get; set; }
        public string BookingEnd { get; set; }
        public int HistoryTtlBooking { get; set; }
        public int HistoryTtlPod { get; set; }
        public bool Print { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public Devenlab.Common.EnumStateChange StateChange { get; set; }
    }
}
