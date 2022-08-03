// TODO: Rewrite with supported IoC container

//using BDSA2015.Lecture05;
//using BDSA2015.Lecture05.Entities;
//using Microsoft.Practices.Unity;
//using System;

//namespace BDSA2015.Lecture06
//{
//    public class CompileTimeBridge
//    {
//        private static UnityContainer _container;

//        public static void Execute()
//        {
//            Console.WriteLine("Compile-time bridge");

//            Bootstrap();

//            using (var repository = _container.Resolve<ICharacterRepository>())
//            {
//                foreach (var character in repository.Get())
//                {
//                    Console.WriteLine(character);
//                }
//            }
//            Console.ReadKey();
//        }

//        /// <summary>
//        /// Compile time choice between EntityRepository and CsvRepository
//        /// </summary>
//        private static void Bootstrap()
//        {
//            _container = new UnityContainer();
//#if !DEBUG
//            _container.RegisterType<ICharacterContext, CharacterContext>();
//            _container.RegisterType<ICharacterRepository, EntityRepository>();
//#else
//            _container.RegisterType<ICharacterRepository, CsvRepository>(new InjectionConstructor(new CrudAdapter(), new Mapper()));
//#endif
//        }
//    }
//}
