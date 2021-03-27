/*Write a program that helps you decide what clothes to wear from your wardrobe. You will receive the clothes,
 which are currently in your wardrobe, sorted by their color in the following format:
"{color} -> {item1},{item2},{item3}…"
If you receive a certain color, which already exists in your wardrobe, just add the clothes to its records. 
You can also receive repeating items for a certain color and you have to keep their count.
In the end, you will receive a color and a piece of clothing, which you will look for in the wardrobe, separated by a space in the following format:
"{color} {clothing}"
Your task is to print all the items and their count for each color in the following format: 
"{color} clothes:
* {item1} - {count}
* {item2} - {count}
* {item3} - {count}
…
* {itemN} - {count}"
If you find the item you are looking for, you need to print "(found!)" next to it:
"* {itemN} - {count} (found!)"*/


using System;
using System.Collections.Generic;
using System.Linq;

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
                List<string> clothesRange = Console.ReadLine().Split(new string[]{",", " -> "}, 
                StringSplitOptions.RemoveEmptyEntries).ToList();

                string color = clothesRange[0];
                clothesRange.Remove(color);

                if (wardrobe.ContainsKey(color))
                {
                    EditColor(wardrobe, color, clothesRange);
                }
                else
                {
                    AddNewColor(wardrobe, color, clothesRange);
                }
            }
            
            string[] searchInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string colorForSearch = String.Empty;
            string dressForSearch = String.Empty;
            
            if (searchInput.Length > 2)
            {
                colorForSearch = $"{searchInput[0]} {searchInput[1]}";
                dressForSearch = searchInput[2];
            }
            else
            {
                 colorForSearch = searchInput[0];
                 dressForSearch = searchInput[1];   
            }

            PrintWardrobeContent(wardrobe, colorForSearch, dressForSearch);
        }

        private static void EditColor(Dictionary<string, Dictionary<string, int>> wardrobe,string 
        color, List<string> clothesRange)
        {
            
            var dressData = wardrobe[color];

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
        
        private static void AddNewColor(Dictionary<string, Dictionary<string, int>> wardrobe, string 
        color, List<string> clothesRange)
        {
            wardrobe.Add(color, new Dictionary<string, int>());
                    
            var dressDict = wardrobe[color];

            for (int j = 0; j < clothesRange.Count; j++)
            {
                var currentCloth = clothesRange[j];
                
                if (dressDict.ContainsKey(currentCloth))
                {
                    dressDict[currentCloth]++;
                    continue;
                }
                
                dressDict.Add(currentCloth, 1);
            }
        }

        private static void PrintWardrobeContent(Dictionary<string, Dictionary<string, int>> 
        wardrobe, string colorForSearch, string dressForSearch)
        {
            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                
                foreach (var dress in color.Value)
                {
                    if (dress.Key == dressForSearch && color.Key == colorForSearch)
                    {
                        Console.WriteLine($"* {dress.Key} - {dress.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {dress.Key} - {dress.Value}");
                    }
                }
            }
        }
    }
}