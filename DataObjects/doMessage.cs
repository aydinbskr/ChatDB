using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class doMessage
    {
        public int? Id { get; set; }
        public string Body { get; set; }
        public int? To { get; set; }
        public string ToName { get; set; }
        public int From { get; set; }
        public string FromName { get; set; }
        public bool IsToRead { get; set; }
        public bool IsToDeleted { get; set; }
        public bool IsFromDeleted { get; set; }
        public DateTime Date { get; set; }
    }
}
