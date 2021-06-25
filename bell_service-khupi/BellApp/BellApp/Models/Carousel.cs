
using Xamarin.Forms;

namespace BellApp.Models
{
    public class Carousel
    {
        public string bell_riskName { get; set; }
        public string bell_installationName { get; set; }
        public string Bell_ServiceName { get; set; }
        public string bell_MCAName { get; set; }
        public string bell_partsName { get; set; }
        public string bell_firName { get; set; }

        public string bell_risk { get; set; }
        public string bell_installation { get; set; }
        public string Bell_Service { get; set; }
        public string bell_MCA { get; set; }
        public string bell_parts { get; set; }
        public string bell_fir { get; set; }

        public Command InstallCommand { get; set; }
        public Command RiskAssessmentCommand { get; set; }



        public bool IsFavorite { get; set; }
        public double Width { get; set; }
    }
}
