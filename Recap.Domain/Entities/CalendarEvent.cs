﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap.Domain.Entities
{
    public class CalendarEvent
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
}
