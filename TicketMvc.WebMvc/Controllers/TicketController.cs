using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TicketMvc.Data.Entities;
using TicketMvc.Services;

namespace TicketMvc.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        public IActionResult Index()
        {
            var allTickets = _ticketService.GetAllTickets();
            return View(allTickets);
        }
        public IActionResult Details(int id)
        {
            var ticket = _ticketService.GetTicketById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TicketEntity ticket)
        {
            if (ModelState.IsValid)
            {
                _ticketService.AddTicket(ticket);
                return RedirectToAction("Index");
            }

            return View(ticket);
        }
        public IActionResult Edit(int id)
        {
            var ticket = _ticketService.GetTicketById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TicketEntity ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ticketService.UpdateTicket(ticket);
                }
                catch (ArgumentException)
                {
                    return NotFound();
                }
                return RedirectToAction("Index");
            }

            return View(ticket);
        }
        public IActionResult Delete(int id)
        {
            var ticket = _ticketService.GetTicketById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _ticketService.DeleteTicket(id);
            return RedirectToAction("Index");
        }
    }
}
