using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Authentication;
using Clinic.DataAccess;
using Clinic.Exceptions;
using Clinic.Models;
using Clinic.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Clinic.Controllers
{
  public class AppointmentController : ControllerBase
  {

    [ApiController]
    [Route("api/slots")]
    public class AppointmentsController : ControllerBase
    {
      private readonly ClinicDbContext context;
      public AppointmentsController(ClinicDbContext context)
      {
        this.context = context;
      }

      //Book an appointment (Patient only)
      [Authorize(Roles = UserRoles.Patient)]
      [HttpPost]
      public async Task<Appointment> BookSlot([FromBody] SlotRequest newSlot)
      {

        Guid idg = Guid.NewGuid();
        var records = (newSlot).MapProperties<Appointment>();
        records.Id = idg.ToString();
        //  records.Status = "Pending";
        context.Appointment.Add(records);
        await context.SaveChangesAsync();
        return records;
      }


      //Cancel appoinment
      [HttpPatch("cancel/{id}")]
      public async Task CancelSlot(string id)
      {
        try

        {

          Appointment slot = context.Appointment.Where(d => d.Id.Equals(id)).Single();
          if (slot == null)
            throw new Exception("no slot was found");

          slot.Status = "Cancelled";
          context.Appointment.Update(slot);
          context.SaveChanges();

          var response = new SuccessResponseContent<Appointment>
          {
            ResultData = slot
          };


          Response.StatusCode = 200;
          Response.ContentType = "application/json";
          await Response.Body.WriteAsync(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response)));
        }
        catch (Exception e)
        {

          var failedResponse = new FailedResponseContent
          {
            StatusMessage = ResponseContentStatusMessages.ExceptionEncounter,
            Error = e
          };

          Response.StatusCode = 400;
          Response.ContentType = "application/json";
          await Response.Body.WriteAsync(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(failedResponse)));
        }
      }


      //View appointment details
      [HttpGet("{id}")]
      public IEnumerable<Appointment> ViewDetails(string id)
      {
        return context.Appointment.Where(d => d.Id.Equals(id));
      }


      //View patient appointment history
      [HttpGet("patient/{id}")]
      public PatientInfo ViewHistory(string id)
      {
        // get all the patient appointments
        List<Appointment> patientSlots = context.Appointment.Where(d => d.PatientID.Equals(id)).ToList();
        PatientInfo response = new PatientInfo();
        response.Id = id;
        response.History = patientSlots;

        return response;

      }
    }
  }
}
