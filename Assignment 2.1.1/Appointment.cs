using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment_2._1._1
{
    internal class Appointment
    {
        private DateTime appointmentDateTime;
        private static int counter = 0; // Static counter to ensure unique IDs

        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int AppointmentDuration { get; set; }
        public DateTime AppointmentDateTime
        {
            get { return appointmentDateTime; }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("Appointment date and time cannot be in the past.");
                }
                appointmentDateTime = value;
            }

        }
        public Appointment() // Default constructor
        {
            AppointmentId = 10000 + counter;
            PatientId = 50000 + counter;
            AppointmentDuration = 60;
            AppointmentDateTime = DateTime.Now.AddHours(24); // Default to one hour from now

        }

        public Appointment(int id, int patientId, int duration, DateTime dateTime)
        {
            AppointmentId = id;
            PatientId = patientId;
            AppointmentDuration = duration;
            AppointmentDateTime = dateTime;
        }

        List<Appointment> appointments = new List<Appointment>();

        public Appointment CreateCustomAppointment(int id, int patientId, int duration, DateTime dateTime)
        {
            Appointment newAppointment = new Appointment(id, patientId, duration, dateTime);
            appointments.Add(newAppointment);
            return newAppointment;
        }
        public void CreateAppointment()
        {
            Appointment newAppointment = new Appointment();
            appointments.Add(newAppointment);
        }
        public void UpdateAppointment(int id, DateTime dateTime)
        {
           for (int i = 0; i < appointments.Count; i++)
            {
                if (appointments[i].AppointmentId == id)
                {   
                    appointments[i].AppointmentDateTime = dateTime;
                    Console.WriteLine("Appointment updated successfully.");
                    Console.WriteLine($"Appointment ID: {appointments[i].AppointmentId}");
                    Console.WriteLine($"New Appointment Date and Time: {appointments[i].AppointmentDateTime}"); 
                }
            }
            Console.WriteLine("Appointment not found.");
        }

        public void deleteAppointment(int id)
        {
            for (int i = 0; i < appointments.Count; i++)
            {
                if (appointments[i].AppointmentId == id)
                {
                    appointments.RemoveAt(i);
                    Console.WriteLine("Appointment deleted successfully.");
                    return;
                }
            }
        }




    }
}
