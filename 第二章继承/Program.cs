using System;

namespace 第二章继承
{
    class Program
    {
        interface ICatchMice
        {
            void CatchMice();
        }
        interface IClimbTree
        {
            void ClimbTree();
        }
        abstract public class Pet
        {
            public Pet(string petname)
            {
                Name = petname;
            }
            protected string Name;
            public void PrintName()
            {
                Console.WriteLine("pet's name is:" + Name);
            }
            abstract public void Speak();
        }
        class Dog : Pet
        {
            static int num;
            static Dog()
            {
                num = 0;
            }
           public Dog(string gouname):base(gouname)
            {
                num++;
            }
            static public void Counts()
            {
                Console.WriteLine("dog number = " + num);
            }
            new public void PrintName()
            {
                Console.WriteLine("狗狗的名字叫:" + Name);
            }
            public override void Speak()
            {
                Console.WriteLine(Name + " is speaking:" + "wow");
            }

        }
        class Cat:Pet,ICatchMice,IClimbTree
        {
            public void CatchMice()
            {
                Console.WriteLine("猫猫抓到老鼠了！");
            }
            public void ClimbTree()
            {
                Console.WriteLine("猫猫爬上树了！");
            }
            public Cat(string maoname):base(maoname)
            {
            }
            new public void PrintName()
            {
                Console.WriteLine("猫猫的名字叫:" + Name);
            }
            public override void Speak()
            {
                Console.WriteLine(Name+" is speaking:" + "miao");
            }
        }
        static void Main(string[] args)
        {
            Pet[] pets = new Pet[] {new Dog("Jack"),new Cat("Tom"),new Dog("Mick") };
            for (int i=0;i<pets.Length;i++)
            {
                pets[i].PrintName();
                pets[i].Speak();
            }
            Cat c = new Cat("小猫猫");
            ICatchMice catchm=(ICatchMice)c;
            c.CatchMice();
            catchm.CatchMice();

            Dog.Counts();
            /*Dog dog = new Dog();
            Cat cat = new Cat();
            dog.Name = "jack";
            cat.Name = "Tom";
            dog.PrintName();
            cat.PrintName();
            dog.Speak();
            cat.Speak();*/
            
           
        }
    }
}
