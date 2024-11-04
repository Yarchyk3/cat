using System;

namespace cat
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Cat
    {
        public string Name { get; }
        public Gender Gender { get; }

        private double _energy;

        public static readonly double MaxEnergy = 20;
        public static readonly double MinEnergy = 0;
        public static readonly double SleepEnergyGain = 10;
        public static readonly double JumpEnergyDrain = 0.5;

        public double Energy
        {
            get { return _energy; }
            set
            {
                if (value < MinEnergy)
                    throw new Exception("Not enough energy to jump");
                else if (value > MaxEnergy)
                    _energy = MaxEnergy;
                else
                    _energy = value;
            }
        }

        public Cat(string name, Gender gender)
        {
            Name = name;
            Gender = gender;
            Energy = MaxEnergy;
        }

        public void Jump()
        {
            Energy -= JumpEnergyDrain;
        }

        public void Sleep()
        {
            Energy += SleepEnergyGain;
        }
    }

    class Program
    {
        static void Main()
        {
            Cat cat = new Cat("Вуса", Gender.Male);

            Console.WriteLine($"Iм'я кота: {cat.Name}");
            Console.WriteLine($"Стать кота: {cat.Gender}");
            Console.WriteLine($"Початкова енергiя: {cat.Energy}");

            cat.Jump();
            Console.WriteLine($"Енергiя пiсля прижка: {cat.Energy}");

            cat.Sleep();
            Console.WriteLine($"Енергiя пiсля сну: {cat.Energy}");
        }
    }
}