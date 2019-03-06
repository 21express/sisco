using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models.MasterData
{
    public class UserRoleModel : IBaseModel
    {
        public int Id { get; set; }

        public Boolean Rowstatus { get; set; }

        public DateTime Rowversion { get; set; }

        public string Role { get; set; }

        public string Description { get; set; }

        public DateTime Createddate { get; set; }

        public string Createdby { get; set; }

        public string Modifiedby { get; set; }

        public DateTime? Modifieddate { get; set; }

        public EnumStateChange StateChange { get; set; }
    }
}
