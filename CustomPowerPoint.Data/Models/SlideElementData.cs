using CustomPowerPoint.Enums;

namespace CustomPowerPoint.Data.Models
{
    public class SlideElementData : BaseData
    {
        public string Content { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
    }
}
