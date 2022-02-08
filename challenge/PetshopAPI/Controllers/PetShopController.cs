using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using PetshopAPI.Entities;

namespace PetshopAPI.Controllers
{
    public class PetShopController : ControllerBase
    {
        private static Dictionary<Guid, Agendamento> schedules = new Dictionary<Guid, Agendamento>()
        {
            { Guid.Parse("0044797f-40e7-4bb3-b10b-35804e177f6e"), new Agendamento{  Id = Guid.Parse("0044797f-40e7-4bb3-b10b-35804e177f6e"), Day = 08, Month = 02, Periodo = Periodo.Vespertino, Status = Status.Vago } },
            { Guid.Parse("3799f670-c990-4a92-b194-61bb8c8f0bb4"), new Agendamento{  Id = Guid.Parse("3799f670-c990-4a92-b194-61bb8c8f0bb4"), Day = 10, Month = 02, Periodo = Periodo.Matutino, Status = Status.Vago } },
            { Guid.Parse("8796523c-b5f8-499c-9ec2-2b98e2c25586"), new Agendamento{  Id = Guid.Parse("8796523c-b5f8-499c-9ec2-2b98e2c25586"), Day = 10, Month = 02, Periodo = Periodo.Vespertino, Status = Status.Vago } },
            { Guid.Parse("11f4f09e-02c9-4beb-95f5-113d2ec9ea40"), new Agendamento{  Id = Guid.Parse("11f4f09e-02c9-4beb-95f5-113d2ec9ea40"), Day = 10, Month = 02, Periodo = Periodo.Noturno, Status = Status.Vago } },
            { Guid.Parse("a4f08f6c-1313-414f-8b4e-2b40c9042e4c"), new Agendamento{  Id = Guid.Parse("a4f08f6c-1313-414f-8b4e-2b40c9042e4c"), Day = 11, Month = 02, Periodo = Periodo.Matutino, Status = Status.Ocupado } },
            { Guid.Parse("18462f4e-c8d0-4de5-bbc8-32cc99a714c3"), new Agendamento{  Id = Guid.Parse("18462f4e-c8d0-4de5-bbc8-32cc99a714c3"), Day = 11, Month = 02, Periodo = Periodo.Vespertino, Status = Status.Vago } },
            { Guid.Parse("d91a6267-6116-47da-aec6-e587ce912650"), new Agendamento{  Id = Guid.Parse("d91a6267-6116-47da-aec6-e587ce912650"), Day = 11, Month = 02, Periodo = Periodo.Noturno, Status = Status.Vago } }
        };

        [HttpGet("getSchedules")]
        public ActionResult<string> getFreeSchedules()
        {
            var _schedules = schedules.Values;
            var _return = new List<AgendamentoViewModel>();
            var _returnString = "";
            var count = 1;

            foreach (Agendamento schedule in _schedules)
            {
                if (schedule.Status == 0 && count <= 3)
                {
                    var _schedule = new AgendamentoViewModel
                    {
                        Id = schedule.Id,
                        Day = schedule.Day,
                        Month = schedule.Month,
                        Periodo = schedule.Periodo.ToString(),
                        Status = schedule.Status.ToString()
                    };

                    _return.Add(_schedule);

                    _returnString += count + " - " + schedule.Day + "/" + schedule.Month + ", " + _schedule.Periodo + ".\n";
                    count++;
                }
            }


            //1 - { { dia, periodo} }
            //2 - { { dia, periodo1, periodo2} }
            //3 - { { dia, periodo} }



            return Ok(_returnString);
        }


        [HttpPut("scheduleAnimal")]
        public ActionResult scheduleAnimal(Guid id, int status = 1)
        {
            if (!schedules.ContainsKey(id))
                return NotFound("Agendamento não encontrado.");

            var _status = 1;

            schedules[id].Status = (Status)status;
            return Ok("Status alterado com sucesso!");
        }
    }
}
