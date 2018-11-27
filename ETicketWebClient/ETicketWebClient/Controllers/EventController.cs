﻿using ETicketWebClient.ETicketService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ETicketWebClient.Controllers
{
    public class EventController : Controller
    {
        ETicketService.EventServiceClient eventClient = new ETicketService.EventServiceClient();
   
        // GET: Event
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var events = eventClient.GetAllEvents();
            return View(events);
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            var myEvent = eventClient.GetEvent(id);
            return View(myEvent);
        }

        // GET: Event/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(FormCollection collection, Event myEvent)
        {
            try
            {
                // TODO: Add insert logic here
                eventClient.CreateEvent(myEvent);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            var myEvent = eventClient.GetEvent(id);

            return View(myEvent);
        }

        // POST: Event/Edit/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id, FormCollection collection, Event myEvent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    eventClient.UpdateEvent(myEvent);
                    return RedirectToAction("Index");

                }
                return View(myEvent);
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            
            var myEvent = eventClient.GetEvent(id);
            return View(myEvent);
        }

        // POST: Event/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    eventClient.DeleteEvent(id);

                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}
