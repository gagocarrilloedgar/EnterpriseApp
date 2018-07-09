using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Model
{
    public class Task
    { 
        
        [Key]
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int WorkId { get; set; }

        public enum Type
        {
            ToDo,
            InPogress,
            Done,
        }

        public Task()
        {
            Name = "Default Name";
            Description = "Default Description";

        }
    }
}
