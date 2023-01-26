using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using Web_api_tour.Data;
using Web_api_tour.Filter;
using Web_api_tour.SQL;

namespace Web_api_tour.Controllers
{
    [Produces("application/json")]

    [ResponseHeader("admin")]
    public class API : Controller
    {
        public async Task<IActionResult> allOrders()
        {
            if (Request.Headers.Authorization != "true")
            {
                Response.Body = Auth.GenerateStreamFromString("Forbidden");

                return StatusCode(403);
            }

            if (StaticSQL.SQL != null)
            {
                var contracts = await StaticSQL.SQL.allOrders();

                return Json(contracts);
            }
                
            else
                return Content("error");
        }
        public IActionResult avalaibleTable()
        {
            return Json(Users.AvalaibleTables);
        }
        public async Task<IActionResult> allclients()
        {
            var sss = await SQL.StaticSQL.SQL.allclients("");
            return Json(sss);
        }



        [HttpPost]
        public async Task<IActionResult> addNewClient()
        {
            StreamReader reader = new StreamReader(Request.Body);
            var text = reader.ReadToEndAsync();

            string str = text.Result;

            var client = JsonSerializer.Deserialize<Client>(str);

            await SQL.StaticSQL.SQL.addNewRecord(client);

            return Json(Users.AvalaibleTables);
        }

        [HttpPost]
        public async Task<IActionResult> addNewOrder()
        {
            StreamReader reader = new StreamReader(Request.Body);
            var text = reader.ReadToEndAsync();

            string str = text.Result;

            var order = JsonSerializer.Deserialize<ContractOrder>(str);

            await SQL.StaticSQL.SQL.addNewRecord(order);

            return Json("");
        }

        public async Task<IActionResult> allTours()
        {
            Response.Headers.AccessControlAllowOrigin = "*";

            if (StaticSQL.SQL != null)
            {
                return Json(await StaticSQL.SQL.allTours());
            }
            else
                return Content("error");
        }

        [HttpPost]
        public IActionResult login()
        {
            // Проверка
            StreamReader reader = new StreamReader(Request.Body);
            var text = reader.ReadToEndAsync();

            string str = text.Result;

            return Content("error");
        }

        [HttpGet]
        public IActionResult login(string username, string password)
        {
            if (Users.isExistingUser(username, password))
            {
                string kookie = Users.RandomString(16);

                Users.Cokies.Add(kookie, username);

                Response.Headers.SetCookie = $"key={kookie}";

                return Content("\"type\": \"Succes\"");
            }

            Response.Headers.ContentType = "application/json";
            return Content("\"type\": \"error\"");
        }

        public IActionResult logout()
        {
            Response.Headers.ContentType = "application/json";



            if (Users.Cokies.ContainsKey(Request.Headers.Cookie))
            {
                Users.Cokies.Remove(Request.Headers.Cookie);
            }

            Response.Headers.SetCookie = "key=delete";
            return Content("succes");
        }
    }
}
