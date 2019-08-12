using AutoMapper;
using System;

namespace LearningAutoMapper
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Source, Destination>();
            });

            var mapper = config.CreateMapper();

            TestCase1(mapper); // dest = mapper.Map<Source, Dest>(source);
                               // в этом случае будет создан новый обьект Dest, все его значения будут инициализированны как default для каждой prop, а после этого будет приписанно source




            TestCase2(mapper); // mapper.Map<Source, Dest>(source, dest); 
                               // используется, когда для нас важно сохранить данные, которые есть в dest, но их нет в source 
                               // пример - MyProperty3 в source отсуствует и если мы не хотим, чтобы она создавалась заново со значением default(MyProperty3) , то используем этот подход 


            //Flow for [dest = mapper.Map<Source, Dest>(source);]

            //Dest d = new Dest();                                                < - - -the main difference !

            //d1.MyProperty1 = source.MyProperty1
            //d1.MyProperty2 = source.MyProperty2


            //Flow for [dest = mapper.Map<Source, Dest>(source, destination);]

            //destination.MyProperty1 = source.MyProperty1
            //destination.MyProperty2 = source.MyProperty2
        }

        private static void TestCase1(IMapper mapper)
        {
            Destination dest = new Destination()
            {
                MyProperty1 = 1,
                MyProperty2 = 2,
                MyProperty3 = "3"
            };

            Source source = new Source()
            {
                MyProperty1 = 100,
                MyProperty2 = 200
            };

            dest = mapper.Map<Source, Destination>(source);

            Console.WriteLine($"TestOne Dest");
            Console.WriteLine($"MyProperty1: [{dest.MyProperty1}]"); // ?
            Console.WriteLine($"MyProperty2: [{dest.MyProperty2}]"); // ?
            Console.WriteLine($"MyProperty3: [{dest.MyProperty3}]"); // ?
            Console.WriteLine();
        }

        private static void TestCase2(IMapper mapper)
        {
            Destination dest = new Destination()
            {
                MyProperty1 = 1,
                MyProperty2 = 2,
                MyProperty3 = "3"
            };

            Source source = new Source()
            {
                MyProperty1 = 1,
                MyProperty2 = 2
            };

            mapper.Map<Source, Destination>(source, dest);

            Console.WriteLine($"TestTwo Dest");
            Console.WriteLine($"MyProperty1: [{dest.MyProperty1}]"); // ?
            Console.WriteLine($"MyProperty2: [{dest.MyProperty2}]"); // ?
            Console.WriteLine($"MyProperty3: [{dest.MyProperty3}]"); // ?
            Console.WriteLine();
        }

        public class Destination
        {
            public int MyProperty1 { get; set; }
            public int MyProperty2 { get; set; }
            public string MyProperty3 { get; set; }
        }

        public class Source
        {
            public int MyProperty1 { get; set; }
            public int MyProperty2 { get; set; }
        }
    }
}
