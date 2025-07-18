﻿using Bigon.İnfrastructure.Entities;
using Bigon.İnfrastructure.Extensions;
using Bigon.İnfrastructure.Repositories;
using Bigon.İnfrastructure.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;

namespace Bigon.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISubscriberRepository subscriberRepository;
        private readonly IEmailService emailService;

        public HomeController(ISubscriberRepository subscriberRepository,IEmailService emailService)
        {
            this.subscriberRepository = subscriberRepository;
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
        public async Task <IActionResult> Subscribe(string email)
        {
            if (!email.IsEmail())
            {
                return Json(new
                {
                    error = true,
                    message=$"'{email}'email telebelerini odemir!"
                });
            }

            //var subscriber =await db.Subscribers.FirstOrDefaultAsync(m => m.Email.Equals(email));
            var subscriber = subscriberRepository.Get(m => m.Email.Equals(email));

            if (subscriber!=null && subscriber.Approved)
            {
                return Json(new
                {
                    error = true,
                    message = $"'{email}'bu e-poct adresine artiq abunelik tetbiq edilib!"
                });
            }
            else if (subscriber != null && !subscriber.Approved)
            {
                return Json(new
                {
                    error = false,
                    message = $"'{email}'bu e-poct adresini tesdiqlemesiniz!"
                });
            }
            subscriber = new Subscriber();
            subscriber.Email = email;
            subscriber.CreatedAt = DateTime.Now;

            subscriberRepository.Add(subscriber);
            subscriberRepository.Save();

            //await db.Subscribers.AddAsync(subscriber);
            //await db.SaveChangesAsync();

            string token = $"#demo-{subscriber.Email}-{subscriber.CreatedAt:yyyy-MM-dd HH:mm:ss.fff}-bigon";

            token = HttpUtility.UrlEncode(token);

            string url = $"{Request.Scheme}://{Request.Host}/subscribe-approve?token={token}";


            string message = $"Abuneliyinizi tesdiq etmek ucun <a href=\"{url}\">linklə</a> davam edin!";

            await emailService.SendMailAsync(subscriber.Email, "Bigon Service",message);

            return Json(new
                {
                    error = false,
                    message = $"Abuneliyinizi tesdiq etmek ucun '{email}'bu e-poct adresine daxil olub size gonderilen linke kecid edin!"
            });
        }
        [Route("/subscribe-approve")]
        public async Task< IActionResult> SubscribeApprove(string token)
        {
            string pattern = @"#demo-(?<email>[^-]*)-(?<date>\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}.\d{3})-bigon";
            Match match=Regex.Match(token, pattern);
            if (!match.Success)
            {
                return Content("token zedelidir!");
            }
            string email = match.Groups["email"].Value;
            string dateStr = match.Groups["date"].Value;

            if (!DateTime.TryParseExact(dateStr, "yyyy-MM-dd HH:mm:ss.fff", null, DateTimeStyles.None, out DateTime date))
            {
                return Content("token zedelidir");
            }
            //var subscriber=await db.Subscribers.FirstOrDefaultAsync(m => m.Email.Equals(email) && m.CreatedAt==date);
            var subscriber= subscriberRepository.Get(m => m.Email.Equals(email) && m.CreatedAt==date);
            if (subscriber==null)
            {
                return Content("token zedelidir");
            }
            if (!subscriber.Approved)
            {
                subscriber.Approved = true;
                subscriber.ApprovedAt = DateTime.Now;
            }
            //await db.SaveChangesAsync();
            subscriberRepository.Save();

            return Content($"Success: Email:{email}\n" +
                $"Date:{date}");
        }
    }
}
