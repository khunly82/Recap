using Recap.DAL.Repositories;
using Recap.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap.BLL.Services
{
    public class CalendarEventService(CalendarEventRepository eventRepository)
    {
        public IEnumerable<CalendarEvent> GetEvents()
        {
            return eventRepository.GetEvents();
        }

        public CalendarEvent AddEvent(string title, DateTime start, DateTime? end)
        {
            if(end is not null)
            {
                if(start > end)
                {
                    throw new ArgumentException("La date de début doit etre plus petite que la date de fin");
                }
            }
            // vérifier chevauchement
            if (eventRepository.OverlapEvents(start, end ?? start))
            {
                throw new ArgumentException("Vous ne pouvez pas ajouter 2 evenements qui se chevauchent");
            }

            return eventRepository.AddEvent(new CalendarEvent
            {
                Title = title,
                Start = start,
                End = end
            });
        }

        public void UpdateEvent(int id, string title, DateTime start, DateTime? end)
        {
            if (end is not null)
            {
                if (start > end)
                {
                    throw new ArgumentException("La date de début doit etre plus petite que la date de fin");
                }
            }
            // vérifier chevauchement
            if (eventRepository.OverlapEvents(start, end ?? start, id))
            {
                throw new ArgumentException("Vous ne pouvez pas ajouter 2 evenements qui se chevauchent");
            }

            CalendarEvent? toUpdate = eventRepository.GetById(id);
            if(toUpdate is null)
            {
                throw new KeyNotFoundException();
            }
            toUpdate.Title = title;
            toUpdate.Start = start;
            toUpdate.End = end;
            eventRepository.UpdateEvent(toUpdate);
        }

        public void DeleteEvent(int id)
        {
            CalendarEvent? toDel = eventRepository.GetById(id);
            if (toDel is null)
            {
                throw new KeyNotFoundException();
            }
            eventRepository.DeleteEvent(toDel);
        }
    }
}
