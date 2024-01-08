using System;
using System.Collections.Generic;
namespace ConsoleApp
{
    class CurList
    {
        public string NameFrom { get; private set; }
        public double AmountFrom { get; private set; }
        public string NameIn { get; private set; }
        public double AmountIn { get; private set; }
        public CurList(string nameFrom, double amountFrom, string nameIn, double amountIn)
        {
            NameFrom = nameFrom;
            AmountFrom = amountFrom;
            NameIn = nameIn;
            AmountIn = amountIn;
        }
        public override string ToString()
        {
            return String.Format($"{NameFrom} {AmountFrom:0.00} = {NameIn} {AmountIn:0.00}");
        }
    }
    abstract class Currency
    {
        public string Name { get; private set; }
        public double ToDollar { get; private set; }
        public Currency(string name, double toDollar)
        {
            Name = name;
            ToDollar = toDollar;
        }
        public double Converter(Currency cr, double amount, int n)
        {
            switch (n)
            {
                case 0: return amount * cr.ToDollar * 99.68;
                case 1: return amount * cr.ToDollar * 16.3;
                case 2: return amount * cr.ToDollar * 17.16;
                case 3: return amount * cr.ToDollar * 33.96;
                default:
                    Console.WriteLine("Недопустимое значение");
                    return 0;
            }
        }
    }
    class Ruble : Currency
    {
        public Ruble() : base("Рубли", 0.010) { }
    }
    class RublePMR : Currency
    {
        public RublePMR() : base("Рубли ПМР", 0.06) { }
    }
    class Lei : Currency
    {
        public Lei() : base("Леи", 0.055) { }
    }
    class Hryvnia : Currency
    {
        public Hryvnia() : base("Гривны", 0.027) { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> CurName = new() { "Рубли", "Рубли ПМР", "Леи", "Гривны" };
            Stack<CurList> list = new();
            bool flag = true;
            int n, c1, c2;
            double res = 0, amount;
            while (flag)
            {
                Console.WriteLine("(0 - Рубли, 1 - Рубли ПМР, 2 - Леи, 3 - Гривны)");
                Console.Write("Введите валюту из которой конвертируем: ");
                c1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите валюту в которую конвертируем: ");
                c2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите сумму: ");
                amount = Convert.ToInt32(Console.ReadLine());
                if (c1 == c2)
                {
                    list.Push(new CurList(CurName[c1], amount, CurName[c2], amount));
                }
                else
                {
                    switch (c1)
                    {
                        case 0:
                            Ruble r = new();
                            res = r.Converter(r, amount, c2);
                            break;
                        case 1:
                            RublePMR rPMR = new();
                            res = rPMR.Converter(rPMR, amount, c2);
                            break;
                        case 2:
                            Lei l = new();
                            res = l.Converter(l, amount, c2);
                            break;
                        case 3:
                            Hryvnia h = new();
                            res = h.Converter(h, amount, c2);
                            break;
                        default:
                            Console.WriteLine("Недопустимое значение");
                            break;
                    }
                    list.Push(new CurList(CurName[c1], amount, CurName[c2], res));
                }
                Console.Write("\nПродолжить конвертацию? (да - 0, нет - 1): ");
                n = Convert.ToInt32(Console.ReadLine());
                if (n == 1)
                {
                    flag = false;
                }
                else if (n != 0)
                {
                    Console.WriteLine("Недопустимое значение");
                    flag = false;
                }
            }
            Console.WriteLine();
            int j = 1;
            foreach (var i in list)
            {
                if (j <= 3)
                {
                    Console.WriteLine($"{i} ");
                }
                j++;
            }
        }
    }
}