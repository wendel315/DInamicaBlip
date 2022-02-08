using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetshopAPI
{
    public class AgendamentoViewModel
    {
        public Guid Id { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public string Periodo { get; set; }
        public string Status { get; set; }
    }
}
