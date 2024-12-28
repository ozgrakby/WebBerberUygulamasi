using System.ComponentModel.DataAnnotations;

namespace WebBerberUygulamasi.Models
{
    public class AppointmentList
    {
        public AppointmentList(int AppointmentID, string ServiceName, string BarberName, string BarberSurname, DateTime AppointmentTime, bool AppointmentConfirmed) {
            this.AppointmentID = AppointmentID;
            this.ServiceName = ServiceName;
            this.BarberName = BarberName;
            this.BarberSurname = BarberSurname;
            this.AppointmentTime = AppointmentTime;
            this.AppointmentConfirmed = AppointmentConfirmed;
        }
        public int AppointmentID { get; set; }
        public string ServiceName { get; set; }
        public string BarberName { get; set; }
        public string BarberSurname { get; set; }
        public DateTime AppointmentTime { get; set; }
        public bool AppointmentConfirmed { get; set; }
    }
}
