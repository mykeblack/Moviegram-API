using Moviegram.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moviegram.Domain
{
    public class Showtime: IShowtime<Showtime>
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Channel { get; set; }
    }
}
