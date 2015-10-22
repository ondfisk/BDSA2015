using System;
using BDSA2015.Lecture05.Entities;
using Ninject;

namespace BDSA2015.Lecture05.App
{
    /// <summary>
    /// Example of using Ninject as an IoC container
    /// </summary>
    class Program
    {
        private static StandardKernel _kernel;

        static void Main(string[] args)
        {
            Bootstrap();
            
            using (var repository = _kernel.Get<ICharacterRepository>())
            {
                foreach (var character in repository.Get())
                {
                    Console.WriteLine(character);
                }
            }
        }

        private static void Bootstrap()
        {
            _kernel = new StandardKernel();

            //_kernel.Bind<ICharacterContext>().To<CharacterContext>();
            //_kernel.Bind<ICharacterRepository>().To<EntityRepository>();
            _kernel.Bind<ICharacterRepository>().To<CsvRepository>();
        }
    }
}
