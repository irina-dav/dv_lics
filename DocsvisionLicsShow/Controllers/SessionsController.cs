using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DocsvisionLicsShow.Models;
using DocsvisionLicsShow.Data;
using Microsoft.Extensions.Options;

namespace DocsvisionLicsShow.Controllers
{
    public class SessionsController : Controller
    {
        private readonly IDvRepository repo;
        private readonly DvSettings dvSettings;

        public SessionsController(IDvRepository repo, IOptions<DvSettings> dvSettings)
        {
            this.repo = repo;
            this.dvSettings = dvSettings.Value;
        }

        public ViewResult List()
        {
            SessionsListViewModel vm = new SessionsListViewModel()
            {
                LicsMax = dvSettings.LicsMax,
                LicsCount = repo.LicCount
            };
            foreach (var sess in repo.SessionsWithoutExcluded)
            {
                var sessVM = new SessionViewModel(sess)
                {
                    UserName = repo.GetEmployeeDisplayString(sess.User.AccountName)
                };
                vm.Sessions.Add(sessVM);
            }
            ViewBag.Title = "Список сессий";
            return View(vm);
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
