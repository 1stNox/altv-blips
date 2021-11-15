
namespace AltV.BlipSystem.Server.Structure
{
    public class Blip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int Color { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
        public float Scale { get; set; }
        public bool ShortRange { get; set; }

        public Blip() { }
    }
}
