// TODO: Rewrite with supported IoC container

//using BDSA2015.Lecture05;
//using BDSA2015.Lecture05.Entities;
//using Microsoft.Practices.Unity;
//using System;

//namespace BDSA2015.Lecture06
//{
//    public class FactoryMethod
//    {
//        private static UnityContainer _container;

//        public static void Execute()
//        {
//            Console.WriteLine("Factory method");

//            using (var repository = CreateCharacterRepository())
//            {
//                foreach (var character in repository.Get())
//                {
//                    Console.WriteLine(character);
//                }
//            }
//        }

//        public static ICharacterRepository CreateCharacterRepository()
//        {
//            Bootstrap();

//            return _container.Resolve<ICharacterRepository>();
//        }

//        private static void Bootstrap()
//        {
//            _container = new UnityContainer();

//            _container.RegisterType<ICharacterContext, CharacterContext>();
//            _container.RegisterType<ICharacterRepository, EntityRepository>();
//            //_container.RegisterType<ICharacterRepository, CsvRepository>(new InjectionConstructor(new CrudAdapter(), new Mapper()));
//        }
//    }
//}
