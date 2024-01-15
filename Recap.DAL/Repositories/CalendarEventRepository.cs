using Microsoft.EntityFrameworkCore;
using Recap.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap.DAL.Repositories
{
    public class CalendarEventRepository(MyContext context)
    {

        public CalendarEvent? GetById(int id)
        {
            return context.Events.Find(id);
        }
        public IEnumerable<CalendarEvent> GetEvents()
        {
            return context.Events.ToList(); ;
        }

        public CalendarEvent AddEvent(CalendarEvent calendarEvent)
        {
            CalendarEvent e = context.Events.Add(calendarEvent).Entity;
            context.SaveChanges();
            return e;
        }

        public void DeleteEvent(CalendarEvent calendarEvent) 
        { 
            context.Events.Remove(calendarEvent);
            context.SaveChanges();
        }

        public void UpdateEvent(CalendarEvent calendarEvent)
        {
            context.Events.Update(calendarEvent);
            context.SaveChanges();
        }

        public bool OverlapEvents(DateTime start, DateTime end, int? id = null)
        {
            return context.Events.Where(e => e.Id != id).Any(ev =>
             (start >= ev.Start && start <= (ev.End ?? ev.Start))
                || (end >= ev.Start && end <= (ev.End ?? ev.Start))
                || (ev.Start >= start && ev.Start <= (end))
                || ((ev.End ?? ev.Start) >= start && (ev.End ?? ev.Start) <= (end))
            );
        }
    }
}
