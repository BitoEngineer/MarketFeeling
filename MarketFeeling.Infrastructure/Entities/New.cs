using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFeeling.Infrastructure.Entities
{
    public class New
    {
        [Key]
        public int Id { get; set; }
        public string Source { get; set; }
        public string Uri { get; set; }
        public double Score  { get; set; }
    }
}
