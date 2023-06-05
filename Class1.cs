﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace deliveries
{
    public class products
    {
        public string Name;
        public int productId;
        public products(string name, int id)
        {
            Name = name;
            productId = id;
        }
    }
    public class provider
    {
        public string name;
        public int providerId;
        public provider(string fio, int id)
        {
            name = fio;
            providerId = id;
        }
    }
    public class supply
    {
        public int productId;
        public int providerId;
        public string data;
        public int quantity;
        public supply(int prId, int povId, string dat, int qua)
        {
            productId = prId;
            providerId = povId;
            data = dat;
            quantity = qua;
        }
    }
    class MainProgram
    {
        public static void Main()
        {
            products prod1 = new products("tomato", 1);
            products prod2 = new products("potato", 2);
            products prod3 = new products("carrot", 3);
            provider prov1 = new provider("Sergey", 1);
            provider prov2 = new provider("Anton", 2);
            provider prov3 = new provider("Stepan", 3);
            supply sup1 = new supply(1, 3, "10.06.2023", 5);
            supply sup2 = new supply(2, 3, "10.06.2023", 3);
            supply sup3 = new supply(1, 2, "10.06.2023", 2);
            supply sup4 = new supply(1, 3, "12.06.2023", 1);
            List<products> Products = new List<products>();
            List<provider> Provider = new List<provider>();
            List<supply> supplies = new List<supply>();
            Products.Add(prod1);
            Products.Add(prod2);
            Products.Add(prod3);
            Provider.Add(prov1);
            Provider.Add(prov2);
            Provider.Add(prov3);
            supplies.Add(sup1);
            supplies.Add(sup2);
            supplies.Add(sup3);
            supplies.Add(sup4);
            Console.WriteLine($"Группировка по датам");
            var dates = supplies.GroupBy(p => p.data);
            foreach (var data in dates)
            {
                Console.WriteLine(data.Key);
                foreach (var tovar in data)
                {
                    Console.WriteLine($"{Products[tovar.productId - 1].Name}-{Provider[tovar.providerId - 1].name}");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Группировка по поставщикам");
            var postavs = supplies.GroupBy(p => p.providerId);
            foreach (var postav in postavs)
            {
                Console.WriteLine(Provider[postav.Key - 1].name);
                foreach (var tovar in postav)
                {
                    Console.WriteLine($"{Products[tovar.productId - 1].Name}-{tovar.quantity}");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Группировка по товару");
            var tovars = supplies.GroupBy(p => p.productId);
            foreach (var tovar in tovars)
            {
                foreach (var el in tovar)
                {
                    Console.WriteLine($"{Products[el.productId - 1].Name}-{Provider[el.providerId - 1].name}");
                }
                Console.WriteLine();
            }
        }
    }
}