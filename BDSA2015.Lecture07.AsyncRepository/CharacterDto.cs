namespace BDSA2015.Lecture07.AsyncRepository
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string AlterEgo { get; set; }

        public override string ToString()
        {
            return $"{GivenName} {Surname} aka {AlterEgo}";
        }
    }
}