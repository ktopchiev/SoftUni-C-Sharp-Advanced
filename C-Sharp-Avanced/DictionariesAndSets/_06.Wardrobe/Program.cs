using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe =
                new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] clothesInput = Console.ReadLine().Split(new char[]{' ', ','}, StringSplitOptions.RemoveEmptyEntries);
                List<string> clothesRange = new List<string>();
                
                for (int j = 2; j < clothesInput.Length; j++)
                {
                    clothesRange.Add(clothesInput[j]);
                }
                
                string color = clothesInput[0];

                if (wardrobe.ContainsKey(color))
                {
                    foreach (var clr in wardrobe.Where(x => x.Key == color))
                    {
                        var dressData = clr.Value;

                        for (int j = 0; j < clothesRange.Count; j++)
                        {
                            if (dressData.ContainsKey(clothesRange[j]))
                            {
                                dressData[clothesRange[j]]++;
                            }
                            else
                            {
                                dressData.Add(clothesRange[j], 1);
                            }
                        }
                    }
                }
                else
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                    
                    var dressDict = wardrobe[color];

                    for (int j = 0; j < clothesRange.Count; j++)
                    {
                        var currentCloth = clothesRange[j];
                        dressDict.Add(currentCloth, 1);
                    }
                    
                }
            }
            
            string[] searchInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string colorForSearch = searchInput[0];
            string dressForSearch = searchInput[1];

            string printString = BuildString(wardrobe, colorForSearch, dressForSearch);

            Console.WriteLine(printString);
        }

        private static string BuildString(Dictionary<string, Dictionary<string, int>> wardrobe,
            string colorForSearch, string dressForSearch)
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (var color in wardrobe)
            {
                sb.Append($"{color.Key} clothes:").AppendLine();
                
                foreach (var dress in color.Value)
                {
                    sb.Append($"* {dress.Key} - {dress.Value}");
                    if (dress.Key == dressForSearch && color.Key == colorForSearch)
                    {
                        sb.Append(" (found!)");
                    }

                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }
    }
}