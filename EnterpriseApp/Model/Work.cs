using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Model
{
    public class Work
    {

        [Key]
        public int WorkId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        public int UserId { get; set; }
        public List<Task> Tasks { get; set; }

        public Work()
        {
            Name = "Default Name";
            Content = "Default Content";
            Tasks = new List<Task>()
            {
                new Task(),
            };
        }

    }
}
