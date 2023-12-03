using System;
using System.Collections.Generic;

// Базовий клас Живий організм
public class LivingOrganism
{
    public int Energy { get; set; }
    public int Age { get; set; }
    public int Size { get; set; }
}

// Спадкоємні класи: Тварина, Рослина, Мікроорганізм
public class Animal : LivingOrganism, IReproducible, IPredator
{
    // Унікальні характеристики для Тварини
    public string Species { get; set; }

    public void Reproduce()
    {
        // Логіка розмноження для Тварини
        Console.WriteLine("Animal is reproducing.");
    }

    public void Hunt(LivingOrganism prey)
    {
        // Логіка полювання для Тварини
        Console.WriteLine("Animal is hunting.");
    }
}

public class Plant : LivingOrganism, IReproducible
{
    // Унікальні характеристики для Рослини
    public string Type { get; set; }

    public void Reproduce()
    {
        // Логіка розмноження для Рослини
        Console.WriteLine("Plant is reproducing.");
    }
}

public class Microorganism : LivingOrganism, IReproducible, IPredator
{
    // Унікальні характеристики для Мікроорганізму
    public string Strain { get; set; }

    public void Reproduce()
    {
        // Логіка розмноження для Мікроорганізму
        Console.WriteLine("Microorganism is reproducing.");
    }

    public void Hunt(LivingOrganism prey)
    {
        // Логіка полювання для Мікроорганізму
        Console.WriteLine("Microorganism is hunting.");
    }
}

// Інтерфейси
public interface IReproducible
{
    void Reproduce();
}

public interface IPredator
{
    void Hunt(LivingOrganism prey);
}

// Клас, що моделює Екосистему
public class Ecosystem
{
    private List<LivingOrganism> organisms;

    public Ecosystem()
    {
        organisms = new List<LivingOrganism>();
    }

    public void AddOrganism(LivingOrganism organism)
    {
        organisms.Add(organism);
    }

    public void SimulateEcosystem()
    {
        // Логіка взаємодії організмів у екосистемі: харчування, розмноження, конкуренція
        foreach (var organism in organisms)
        {
            if (organism is IPredator)
            {
                // Логіка полювання для хижаків
                ((IPredator)organism).Hunt(SelectPreyFor(organism));
            }

            if (organism is IReproducible)
            {
                // Логіка розмноження
                ((IReproducible)organism).Reproduce();
            }

            // Логіка конкуренції за ресурси та інші взаємодії між організмами
            Console.WriteLine("Interaction between organisms.");
        }
    }

    private LivingOrganism SelectPreyFor(LivingOrganism predator)
    {
        // Логіка вибору жертви для хижака
        Console.WriteLine("Selecting prey for predator.");
        return new LivingOrganism(); // Повертаємо загальний організм для прикладу
    }
}

class Program
{
    static void Main(string[] args)
    {
        Ecosystem ecosystem = new Ecosystem();

        Animal lion = new Animal { Energy = 100, Age = 5, Size = 30, Species = "Lion" };
        Plant oak = new Plant { Energy = 50, Age = 10, Size = 20, Type = "Oak" };
        Microorganism bacteria = new Microorganism { Energy = 10, Age = 1, Size = 1, Strain = "E. coli" };

        ecosystem.AddOrganism(lion);
        ecosystem.AddOrganism(oak);
        ecosystem.AddOrganism(bacteria);

        ecosystem.SimulateEcosystem();
    }
}
