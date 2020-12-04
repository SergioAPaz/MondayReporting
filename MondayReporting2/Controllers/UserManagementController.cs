using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MondayReporting2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MondayReporting2.Models.MyModels;

namespace MondayReporting2.Controllers
{

    //This controller works with an API service 
    public class UserManagementController : Controller
    {

        public async Task<IActionResult> Index()
        {
            List<MyRoles> reservationList = new List<MyRoles>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/CtRoles"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<MyRoles>>(apiResponse);
                }
            }
            return View("UserManagement",reservationList);
        }





    }
}