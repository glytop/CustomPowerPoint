using CustomPowerPoint.Data.Models;

namespace CustomPowerPoint.Models
{
    public class PresentationModeViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<SlideData> Slides { get; set; } = new List<SlideData>();
    }
}
