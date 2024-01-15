using Recap.Domain.Entities;

namespace Recap.API.DTO
{
    public class CalendarEventDTO
    {
        public CalendarEventDTO(CalendarEvent ev)
        {
            Id = ev.Id;
            Title = ev.Title;
            Start = ev.Start;
            End = ev.End;
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
}
