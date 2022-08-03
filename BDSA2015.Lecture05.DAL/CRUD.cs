using System;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace BDSA2015.Lecture05.DAL
{
    public class CRUD 
    {
        private readonly string _file;

        public CRUD()
        {
            _file = "data/Characters.csv";
        }

        public CRUD(string file)
        {
            _file = file;
        }

        public int Create(Character character)
        {
            var characters = Read();

            using (var stream = new StreamWriter(_file))
            using (var writer = new CsvWriter(stream, CultureInfo.CurrentCulture))
            {
                var id = 0;
                writer.WriteHeader<Character>();
                foreach (var c in characters)
                {
                    id = Math.Max(id, c.ID);
                    writer.WriteRecord(c);
                }
                character.ID = ++id;
                writer.WriteRecord(character);

                return id;
            }
        }

        public Character Read(int characterID)
        {
            var characters = Read();

            foreach (var character in characters)
            {
                if (character.ID == characterID)
                {
                    return character;
                }
            }

            return null;
        }

        public Character[] Read()
        {
            using (var stream = new StreamReader(_file))
            using (var reader = new CsvReader(stream, CultureInfo.CurrentCulture))
            {
                return reader.GetRecords<Character>().OrderBy(c => c.ID).ToArray();
            }
        }

        public void Update(Character character)
        {
            var characters = Read();

            using (var stream = new StreamWriter(_file))
            using (var writer = new CsvWriter(stream, CultureInfo.CurrentCulture))
            {
                writer.WriteHeader<Character>();
                foreach (var c in characters)
                {
                    if (c.ID == character.ID)
                    {
                        writer.WriteRecord(character);
                    }
                    else
                    {
                        writer.WriteRecord(c);
                    }
                }
            }
        }

        public void Delete(int characterID)
        {
            var characters = Read();

            using (var stream = new StreamWriter(_file))
            using (var writer = new CsvWriter(stream, CultureInfo.CurrentCulture))
            {
                writer.WriteHeader<Character>();
                foreach (var c in characters)
                {
                    if (c.ID != characterID)
                    {
                        writer.WriteRecord(c);
                    }
                }
            }
        }
    }
}
