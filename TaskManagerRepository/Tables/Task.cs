using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagerRepository.Tables
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public bool AllDay { get; set; }
        public bool Important { get; set; }
    }
}
