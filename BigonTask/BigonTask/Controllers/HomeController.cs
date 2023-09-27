using BigonTask.AppCode.Extensions;
using BigonTask.AppCode.Services;
using BigonTask.Models.Entities;
using BigonTask.Models.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace BigonTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext db;
        private readonly IEmailService emailService;
   

        public HomeController(DataContext db, IEmailService emailService)
        {
         
            this.db = db;
            this.emailService = emailService;
       
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Subscribe(string email)
        {
            if (!email.IsEmail())
            {
                return Json(new
                {
                    error = true,
                    message = $"'{email}' email telebleri odemir"
                });
            }
            var subscribe = db.Subscribers.FirstOrDefault(m=>m.Email.Equals(email));
            if (subscribe!=null&&subscribe.Approved)
            {
                return Json(new
                {
                    error = true,
                    message = $"'{email}' ile abunesiniz"
                });
            }
            else if(subscribe != null && !subscribe.Approved)
            {
                return Json(new
                {
                    error = false,
                    message = $"'{email}'tesdiqlenmeyib.Zehmet olmasa tesdiqleyin"
                });
            }
            subscribe = new Subscriber();
            subscribe.Email = email;
            subscribe.CreatedAt = DateTime.Now;
            subscribe.CreatedBy = 1;

            await  db.Subscribers.AddAsync(subscribe);
           await   db.SaveChangesAsync();
            string requestlink = "https://localhost:7123";
            await emailService.SendMailAsync(subscribe.Email, "Subscribe Bigon Ecommerce", $"Xeberlere abuneliyi tamamlamaq ucun <a href=\"{requestlink}\">Link</a> le devam edin");
   
               return Json(new
                {
                    error = false,
                    email = email
                });
          
        }
    }
}
