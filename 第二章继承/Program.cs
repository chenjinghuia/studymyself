using System;
using System.Collections.Generic;

namespace 第二章继承
{
    
        interface ICatchMice//定义一个抓老鼠的接口
        {
            void CatchMice();
        }
        interface IClimbTree//定义一个爬树的接口
        {
            void ClimbTree();
        }
        abstract public class Pet//abstract定义抽象pet基类
        {
            public Pet(string petname)
            {
                Name = petname;
                _age = 0;
            }
            protected string Name;
            protected int _age;
            public void PrintName()
            {
                Console.WriteLine("pet's name is:" + Name);
            }
        public void ShowAge()
        {
            Console.WriteLine(Name + "'s age =" + _age);
        }
        public static Pet operator ++(Pet pet)
        {
            pet._age++;
            return pet;
        }
            abstract public void Speak();//抽象基类,abstract定义抽象speak方法
        }
    //1.sealed是定义为密闭类，就是无法在其子类中在进行重写：比如狗类中的叫声基本都是wow，所以当我们派生类定义了一个拉布拉多的狗，则不可以再重写狗叫声的方法。
    /*2.override进行抽象speak方法的重写
     （override可以与virtual虚方法配合用，但是virtual定义的虚方法一般没有多大意义，还是用abstract抽象定义比较好）*/
    public class Dog : Pet
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
            public static implicit operator Cat(Dog dog)
            {
                return new Cat(dog.Name);
            }
        public void IsHappy<T>(T Target)where T:Pet//5-2泛型方法
        {
            Console.WriteLine("Happy:");
            Target.PrintName();
        }
       
    } 
        public abstract class DogCmd
        {
            public abstract string GetCmd();
        }
        public class SitDogCmd:DogCmd
        {
            public override string GetCmd()
            {
                return "狗狗坐下了";
            }
        }
    public class SpeakDogCmd : DogCmd
    {
        public override string GetCmd()
        {
            return "狗狗wow叫";
        }
    }
    public interface IDogLearn<C> where C:DogCmd
        {
            void Act(C cmd);
        }
        public class Labrador : Dog,IDogLearn<SitDogCmd>,IDogLearn<SpeakDogCmd>
        {
            public Labrador(string name) : base(name) { }
            public void Act(SitDogCmd cmd)
            {
                Console.WriteLine(cmd.GetCmd());
            }
        public void Act(SpeakDogCmd cmd)
        {
            Console.WriteLine(cmd.GetCmd());
        }
        }
    
        static class PetGuide//定义一个静态类
        {
            static public void HowToFeedDog(this Dog dog)//静态类里面定义静态方法，this后面的第一个参数是要扩展类的类名，比如扩展狗狗吃东西的方法。
            {
                Console.WriteLine("A vedio about how to feed dog!");
            }
        }
        public class Cat:Pet,ICatchMice, IClimbTree//注意pet是派生类的名字必须放在第一位，后面接口的位置可以随便乱放（ICatchMice,IClimbTree）
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
            public static explicit operator Dog(Cat cat)
            {
            return new Dog(cat.Name);
            }
        }
    public class Cage<T>//定义一个泛型类
    {
        T[] kucun;
        readonly int Size;
        int num;
        public Cage(int n)//构造cage存量函数
        {
            Size = n;
            num = 0;
            kucun = new T[Size];
        }
        public void PutIn(T Pet)
        {
            if(num<Size)
            {
                kucun[num++] = Pet;
            }
            else
            {
                Console.WriteLine("Cage is full!");
            }
        }
        public  T TakeOut()
        {
            if (num > 0)
            {
                return kucun[--num];
            }
            else
            {
                Console.WriteLine("Cage is empty!");
                return default(T);
            }
        }
    }
    public class person
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            /*Pet[] pets = new Pet[] {new Dog("Jack"),new Cat("Tom"),new Dog("Mick") };
            for (int i=0;i<pets.Length;i++)
            {
                pets[i].PrintName();
                pets[i].Speak();
            }
            Cat c = new Cat("小猫猫");
            ICatchMice catchm=(ICatchMice)c;//把c强制转化为接口ICatchMice的类型
            c.CatchMice();//通过对象调用
            catchm.CatchMice();//通过接口调用

            Dog.Counts();
            Dog dog = new Dog("DJ");
            dog.HowToFeedDog();
            {
                int i = 3;
                object oi = i;
                Console.WriteLine(oi.ToString());
                int j = (int)oi;
                Console.WriteLine(j);
            }
            Dog dog2 = new Dog("gougou");
            dog2.Speak();

            Cat cat = dog2;//隐式转换，转成猫猫的叫声
            cat.Speak();

            Dog dog3=(Dog)cat;//显示转换，转成狗狗的叫声
            dog3.Speak();

            for(int j=0;j<pets.Length;j++)
            {
                pets[j]++;
                pets[j].ShowAge();
            }
            */

            /*Dog dog = new Dog();
            Cat cat = new Cat();
            dog.Name = "jack";
            cat.Name = "Tom";
            dog.PrintName();
            cat.PrintName();
            dog.Speak();
            cat.Speak();*/

            /*var dogcage = new Cage<Dog>(1);//5-1泛型类
            dogcage.PutIn(new Dog("A"));
            dogcage.PutIn(new Dog("B"));

            var dog = dogcage.TakeOut();
            dog.PrintName();*/

            /*var dog = new Dog("A");//5-2泛型方法
            dog.IsHappy<person>(new person());
            dog.IsHappy<int>(3);*/

            var dog = new Dog("A");//5-3约束
            dog.IsHappy<Cat>(new Cat("Tom"));

            Console.WriteLine();
            Jiekou();


        }
        static void Jiekou()
        {
            Labrador labrador = new Labrador("A");
            labrador.Act(new SitDogCmd());
            labrador.Act(new SpeakDogCmd());

            Console.WriteLine();
            List<Dog> list = new List<Dog>();
            list.Add(new Dog("A"));
            list.Add(new Dog("B"));
            list.Add(new Dog("C"));
            list.RemoveAt(1);
            for(int i=0;i<list.Count;++i)
            {
                list[i].PrintName();
            }

            Console.WriteLine();
            Dictionary<string, Dog> dic = new Dictionary<string, Dog>();
            dic.Add("A", new Dog("A"));
            dic.Add("B", new Dog("A"));
            dic.Add("C", new Dog("A"));
            dic["A"].PrintName();


        }
    }
}
