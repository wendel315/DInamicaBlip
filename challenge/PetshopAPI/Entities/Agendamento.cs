using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetshopAPI.Entities
{
    public class Agendamento
    {
        public Guid Id { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public Periodo Periodo { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        Vago,
        Ocupado
    }

    public enum Periodo
    {
        Matutino,
        Vespertino,
        Noturno
    }
}
