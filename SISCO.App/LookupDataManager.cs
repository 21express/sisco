using SISCO.Models;
using SISCO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.App
{
    public class LookupDataManager
    {
        public LookupModel Get(string category)
        {
            return new LookupRepository().Get(category);
        }
    }
}