using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("u_test")]
[assembly: InternalsVisibleTo("WinFormsApp1")]

namespace ConsoleApp1
{
    class Backpack
    {
        static void Main()
        {
            Console.WriteLine("Enter the number of items: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the seed: ");
            int seed = int.Parse(Console.ReadLine());

            Problem problem = new Problem(n, seed);

           
            List<Przedmiot> przedmioty = problem.GenerateItems(n);


            Console.WriteLine("Enter the capacity: ");
            int capacity = int.Parse(Console.ReadLine());

            Result result = problem.Solve(przedmioty, capacity); 
            Console.WriteLine("Solution:");
            Console.WriteLine(result);
        }
    }
    class Problem
    {
        public static int N { get; set; }
        public static int Seed { get; set; }
        public static Random random;

        public Problem(int n, int seed)
        {
            N = n;
            Seed = seed;
            random = new Random(seed);
        }

        public Result Solve(List<Przedmiot> przedmioty, int capacity)
        {
            przedmioty = przedmioty.OrderByDescending(x => (double)x.Wartosc / x.Waga).ToList();

            List<int> selectedItems = new List<int>();
            int totalValue = 0;
            int totalWeight = 0;

            foreach (Przedmiot przedmiot in przedmioty)
            {
                if (totalWeight + przedmiot.Waga <= capacity)
                {
                    selectedItems.Add(przedmiot.Id);
                    totalValue += przedmiot.Wartosc;
                    totalWeight += przedmiot.Waga;
                }
            }

            return new Result(selectedItems, totalValue, totalWeight);
        }

        public  List<Przedmiot> GenerateItems(int n)
        {
            List<Przedmiot> przedmioty = new List<Przedmiot>();
            for (int i = 1; i <= n; i++)
            {
                int value = random.Next(1, 11);
                int weight = random.Next(1, 11);
                przedmioty.Add(new Przedmiot(i, value, weight));
                Console.WriteLine(przedmioty[i - 1].ToString());
            }
            return przedmioty;
        }

    }

    class Przedmiot
    {
        public int Id { get; set; }
        public int Wartosc { get; set; }
        public int Waga { get; set; }

        public Przedmiot(int id, int wartosc, int waga)
        {
            Id = id;
            Wartosc = wartosc;
            Waga = waga;
        }

        public override string ToString()
        {
            return  $"Id: {Id} Value: {Wartosc}, Weight: {Waga}\n";
            //return $"{Id}, {Wartosc}, {Waga}";
        }
    }

    class Result
    {
        public List<int> SelectedItems { get; set; }
        public int TotalValue { get; set; }
        public int TotalWeight { get; set; }

        public Result(List<int> selectedItems, int totalValue, int totalWeight)
        {
            SelectedItems = selectedItems;
            TotalValue = totalValue;
            TotalWeight = totalWeight;
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", SelectedItems)}],\n Val: {TotalValue},\n Weig: {TotalWeight}";
        }
    }
}
