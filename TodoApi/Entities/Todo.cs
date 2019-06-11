using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Entities
{
    [Table("Todos")]
    public class Todo
    {
        [Key]
        public int ID { get; set; }
        public string Task { get; set; }
        public bool Status { get; set; }
    }
}
