using CustomPowerPoint.Enums;

namespace CustomPowerPoint.Data.Models
{
    public class SlideData : BaseData
    {
        public int Order { get; set; }

        public List<SlideElementData> Elements { get; set; } = new();
    }
}
