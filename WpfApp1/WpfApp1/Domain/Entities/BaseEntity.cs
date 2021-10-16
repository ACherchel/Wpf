using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Domain.Entities
{
    public class BaseEntity<T> where T : struct
    {
        public T Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
