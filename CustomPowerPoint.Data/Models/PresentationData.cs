namespace CustomPowerPoint.Data.Models
{
    public class PresentationData : BaseData
    {
        public string Title { get; set; }
        public string CreatorId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<SlideData> Slides { get; set; } = new List<SlideData>();
        public List<UserData> Users { get; set; } = new List<UserData>();
    }
}
