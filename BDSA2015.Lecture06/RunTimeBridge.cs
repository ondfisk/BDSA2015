using BDSA2015.Lecture05;
using BDSA2015.Lecture05.Entities;
using Microsoft.Practices.Unity;
using System;

namespace BDSA2015.Lecture06
{
    public class RunTimeBridge
    {
        private static UnityContainer _container;

        public static void Execute(string bridge = null)
        {
            Console.WriteLine("Run-time bridge");

            Bootstrap();

            using (var repository = _container.Resolve<ICharacterRepository>(bridge))
            {
                foreach (var character in repository.Get())
                {
                    Console.WriteLine(character);
                }
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Compile time choice between EntityRepository and CsvRepository
        /// </summary>
        private static void Bootstrap()
        {
            _container = new UnityContainer();
            _container.RegisterType<ICharacterContext, CharacterContext>();
            _container.RegisterType<ICharacterRepository, EntityRepository>();
            _container.RegisterType<ICharacterRepository, CsvRepository>("csv", new InjectionConstructor(new CrudAdapter(), new Mapper()));
        }
    }
}
