namespace first.DTOs.Character
{
    public class AddCharacterDto
    {
        public string Name { get; set; } = "Nandhni";
        public int HitPoints { get; set; } = 10;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Venkat;
    }
}
