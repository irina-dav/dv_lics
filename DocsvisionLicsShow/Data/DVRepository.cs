using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocsvisionLicsShow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DocsvisionLicsShow.Data
{
    public class DVRepository : IDvRepository
    {
        private readonly DvDbContext context;
        private readonly DvSettings dvSettings;

        public DVRepository(DvDbContext ctx, IOptions<DvSettings> dvSettings)
        {
            context = ctx;
            this.dvSettings = dvSettings.Value;
        }

        public IQueryable<DvSession> Sessions => context.Sessions.Include(s => s.User);

        public IQueryable<DvSession> SessionsWithoutExcluded => Sessions.Where(s => !dvSettings.ExcludeAccounts.Any(a => a == s.User.AccountName.ToUpper()));

        private IQueryable<DvEmployee> Employees => context.Employees;

        public int LicCount => context.Sessions.Where(s => !s.Offline).Select(s => s.ComputerAddress + s.UserID.ToString()).Distinct().Count();

        public string GetEmployeeDisplayString(string accountName)
        {
            string displayStr = "";
            var employee = Employees.FirstOrDefaultAsync(em => em.AccountName.ToUpper() == accountName.ToUpper());
            if (employee .Result== null)
                displayStr = accountName;
            else
                displayStr = $"{employee.Result.LastName ?? ""} {employee.Result.FirstName ?? ""} {employee.Result.MiddleName ?? ""}";
            return displayStr;
        }
    }
}
