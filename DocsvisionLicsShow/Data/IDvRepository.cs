using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocsvisionLicsShow.Models;

namespace DocsvisionLicsShow.Data
{
    public interface IDvRepository
    {
        IQueryable<DvSession> Sessions { get; }

        IQueryable<DvSession> SessionsWithoutExcluded { get; }

        string GetEmployeeDisplayString(string accountName);
       
        int LicCount { get; }
    }
}
