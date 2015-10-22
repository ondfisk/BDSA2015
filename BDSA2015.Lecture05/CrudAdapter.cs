using BDSA2015.Lecture05.DAL;

namespace BDSA2015.Lecture05
{
    public class CrudAdapter
    {
        private readonly CRUD _crud; 

        public CrudAdapter()
        {
            _crud = new CRUD();
        }

        public CrudAdapter(string file)
        {
            _crud = new CRUD(file);
        }

        public virtual int Create(Character character)
        {
            return _crud.Create(character);
        }

        public Character[] Read()
        {
            return _crud.Read();
        }

        public Character Read(int characterId)
        {
            return _crud.Read(characterId);
        }

        public virtual void Update(Character character)
        {
            _crud.Update(character);
        }

        public virtual void Delete(int characterId)
        {
            _crud.Delete(characterId);
        }
    }
}
