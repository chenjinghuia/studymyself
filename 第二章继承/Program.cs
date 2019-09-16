using System;

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
            }
            protected string Name;
            public void PrintName()
            {
                Console.WriteLine("pet's name is:" + Name);
            }
            abstract public void Speak();//抽象基类,abstract定义抽象speak方法
    }
    //1.sealed是定义为密闭类，就是无法在其子类中在进行重写：比如狗类中的叫声基本都是wow，所以当我们派生类定义了一个拉布拉多的狗，则不可以再重写狗叫声的方法。
    /*2.override进行抽象speak方法的重写
     （override可以与virtual虚方法配合用，但是virtual定义的虚方法一般没有多大意义，还是用abstract抽象定义比较好）*/
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
        static class PetGuide//定义一个静态类
        {
            static public void HowToFeedDog(this Dog dog)//静态类里面定义静态方法，this后面的第一个参数是要扩展类的类名，比如扩展狗狗吃东西的方法。
            {
                Console.WriteLine("A vedio about how to feed dog!");
            }
        }
        class Cat:Pet,ICatchMice, IClimbTree//注意pet是派生类的名字必须放在第一位，后面接口的位置可以随便乱放（ICatchMice,IClimbTree）
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
    class Program
    {
        static void Main(string[] args)
        {
            Pet[] pets = new Pet[] {new Dog("Jack"),new Cat("Tom"),new Dog("Mick") };
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
