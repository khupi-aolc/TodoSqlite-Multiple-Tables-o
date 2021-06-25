using System;
using System.Collections.Generic;
using System.Text;

namespace BellApp.Models
{
    public class InstallationCertificate
    {
        public string Id { get; set; }
        public bool IsComplete { get; set; } = false;
        public bool isUploaded { get; set; } = false;
        public string VIN { get; set; }
        public string SerialNumber { get; set; }
        public string MachineModel { get; set; }
        public string FleetNumber { get; set; }
    }
}
