namespace first.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }
        public Characters? Characters { get; set; }
        public int CharactersId { get; set; }
    }
}
