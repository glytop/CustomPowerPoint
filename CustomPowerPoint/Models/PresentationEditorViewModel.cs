using CustomPowerPoint.Data.Models;

namespace CustomPowerPoint.Models
{
    public class PresentationEditorViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string CreatorNickname { get; set; }
        public Guid CreatorId { get; set; }
        public List<SlideData> Slides { get; set; } = new List<SlideData>();
        public List<UserData> Users { get; set; } = new List<UserData>();

        public SlideData? ActiveSlide { get; set; }
        public bool IsCreator { get; set; }
    }
}
