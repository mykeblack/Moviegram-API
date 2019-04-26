using System;
using System.Collections.Generic;
using System.Text;

namespace Moviegram.Database
{
    public class Showtime
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Channel { get; set; }
        public int MovieId { get; set; }
    }
}
