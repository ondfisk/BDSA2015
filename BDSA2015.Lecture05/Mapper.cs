using BDSA2015.Lecture05.DAL;

namespace BDSA2015.Lecture05
{
    public class Mapper
    {
        public virtual CharacterDto Map(Character character)
        {
            var dto = new CharacterDto {
                Id = character.ID,
                GivenName = character.FirstName,
                Surname = character.LastName,
                AlterEgo = character.AKA
            };

            return dto;
        }

        public virtual Character Map(CharacterDto character)
        {
            var c = new Character
            {
                ID = character.Id,
                FirstName = character.GivenName,
                LastName = character.Surname,
                AKA = character.AlterEgo
            };

            return c;
        }
    }
}
