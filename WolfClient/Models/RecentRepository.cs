using System;
using System.Collections.Generic;
using System.Text;

namespace WolfClient.Models
{
    public class RecentRepository
    {
        public string? Path { get; set; }
        public string? Name { get; set; }
        public DateTime LastOpenedUtc { get; set; }
    }
}
