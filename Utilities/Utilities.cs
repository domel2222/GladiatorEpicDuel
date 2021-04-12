using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;


namespace GladiatorEpicDuels
{
    public static class Utilities
    {

        private static Random _rand = new Random();
        private static List<string> _name = new List<string>();
        private static List<string> _messages = new List<string>();
        private static List<string> _technique = new List<string>();

        private static List<int> _tempList = new List<int>();
        private static List<int> _tempList2 = new List<int>();
        private const string _namePath = "name.txt";
        private const string _messagePath = "messages.txt";
        private const string _techiquePath = "technique.txt";
        public static void LoadData()
        {
            _name = System.IO.File.ReadLines(_namePath).ToList();
            _messages = System.IO.File.ReadLines(_messagePath).ToList();
            _technique = System.IO.File.ReadLines(_techiquePath).ToList();

        }

        public static T RandomEnum<T>()
        {
            var kind = Enum.GetValues(typeof(T));

            return (T)kind.GetValue(_rand.Next(kind.Length));
        }

        public static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }


        public static string GetRandomName()
        {
            var name = _name[GetRandomValue(0, _name.Count -1)];

            return name;
        }

        public static string GetRandomMessage()
        {
            var message = _messages[GetRandomValue(0, _messages.Count - 1)];

            return message;
        }

        public static string GetRandomTechniqueName()
        {
            var technique = _technique[GetRandomValue(0, _technique.Count -1)];

            return technique;
        }

        //default min value 0 
        //public static int GetRandomValue(int min = 0, int max = 100)
        public static int GetRandomValue(int min=0, int max = 100)
        {
             var random = _rand.Next(min, max + 1);

            return random;
        }
        
        public static double GetRandomDouble(double min , double max)
        {
            var random = _rand.NextDouble() * (max - min) + min;

            return  Math.Round(random, 1);
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = _rand.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
        {
            while (source.Any())
            {
                yield return source.Take(chunksize).ToList();
                source = source.Skip(chunksize);
            }
        }

        public static List<int> CreatePatternListToLocation(List<int> list, int amout)
        {
            _tempList.Clear();
            _tempList2.Clear();

            _tempList = list.ToList();
            list.Clear();
            foreach (var item in _tempList)
            {
                list.Add(item * 2);

            }
            _tempList2 = list.ToList();
            foreach (var item in _tempList2)
            {
                list.Add(item + 1);

            }
            if (list.Count == amout)
                return list;
            else
            {
                CreatePatternListToLocation(list, amout);
            }
            return list;
        }
        public static bool powerOf2(int number)
        {
            if (number <= 1)
            {
                return false;
            }
            while (number % 2 == 0)
            {
                number = number / 2;
                if (number == 1)
                {
                    return true;
                }
                else if (number < 1)
                {
                    return false;
                }
            }
            return default;
        }
        //shuffle @2
        //public static void Shuffle<T>(this IList<T> list)
        //{
        //    RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        //    int n = list.Count;
        //    while (n > 1)
        //    {
        //        byte[] box = new byte[1];
        //        do provider.GetBytes(box);
        //        while (!(box[0] < n * (Byte.MaxValue / n)));
        //        int k = (box[0] % n);
        //        n--;
        //        T value = list[k];
        //        list[k] = list[n];
        //        list[n] = value;
        //    }
        //}
    }
}
