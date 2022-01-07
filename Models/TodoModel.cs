using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class TodoModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "SemNome";
        public bool Done { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}