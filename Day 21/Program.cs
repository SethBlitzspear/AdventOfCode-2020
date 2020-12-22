using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_21
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> freeFrom = new List<string>();
            List<string> allIngredients = new List<string>();
            List<string> allOccourances = new List<string>();
            string[] Foods = File.ReadAllLines("Food.txt");
            Dictionary<string, List<List<string>>> Potentials = new Dictionary<string, List<List<string>>>();

            foreach (string food in Foods)
            {
                string[] ingredientsArray = food.Split('(')[0].Split(' ');
                string[] allergens = food.Split('(')[1].Split(' ');

                List<string> ingredients = new List<string>();
                for (int ingredientCount = 0; ingredientCount < ingredientsArray.Length - 1; ingredientCount++)
                {
                    string ingredient = ingredientsArray[ingredientCount];

                    allOccourances.Add(ingredient);
                    if (!allIngredients.Contains(ingredient))
                    {
                        allIngredients.Add(ingredient);
                    }
                    ingredients.Add(ingredient);
                }

                for (int allergenCount = 1; allergenCount < allergens.Length; allergenCount++)
                {
                    string allergen = allergens[allergenCount].Substring(0, allergens[allergenCount].Length - 1);
                    if (Potentials.ContainsKey(allergen))
                    {
                        Potentials[allergen].Add(ingredients);
                    }
                    else
                    {
                        List<List<string>> newIngerdients = new List<List<string>>();
                        newIngerdients.Add(ingredients);
                        Potentials.Add(allergen, newIngerdients);
                    }
                }
            }
            Dictionary<string, List<string>> shortList = new Dictionary<string, List<string>>();
            
           
            
            foreach (string allergen in Potentials.Keys)
            {
                List<string> AllIngredients = new List<string>();

                foreach (List<string> ingredientList in Potentials[allergen])
                {
                    foreach (string ingredient in ingredientList)
                    {
                        if (!AllIngredients.Contains(ingredient))
                        {
                            AllIngredients.Add(ingredient);
                        }
                    }
                }
                string FoundIngredient = "";
                foreach (string ingredient in AllIngredients)
                {
                    bool matchFound = true;
                    foreach (List<string> ingredientList in Potentials[allergen])
                    {
                        if (!ingredientList.Contains(ingredient))
                        {
                            matchFound = false;
                        }
                    }
                    if (matchFound)
                    {
                        Console.WriteLine("allergen " + allergen + " found match in " + ingredient);
                        FoundIngredient = ingredient;
                        if(shortList.ContainsKey(allergen))
                        {
                            shortList[allergen].Add(ingredient);
                        }
                        else
                        {
                            List<string> newList = new List<string>();
                            newList.Add(FoundIngredient);
                            shortList.Add(allergen, newList);
                        }
                    }
                }
                if (FoundIngredient != "")
                {
                   // actuals.Add(FoundIngredient, allergen);
                }
                else
                {
                    int satop = 1;
                }
       /*         Potentials.Remove(allergen);
                foreach (List<List<string>> ingredientlists in Potentials.Values)
                {
                    foreach (List<string> list in ingredientlists)
                    {
                        if (list.Contains(FoundIngredient))
                        {
                            list.Remove(FoundIngredient);
                        }
                    }
                }*/


            }
            /* Dictionary<string, List<string>> actuals = new Dictionary<string, List<string>>();
             foreach (string allergen in Potentials.Keys)
             {
                 actuals.Add(allergen, Potentials[allergen][0]);
                 for (int listCount = 0; listCount < Potentials[allergen].Count; listCount++)
                 {
                     string[] allergenCheck = actuals[allergen].ToArray();
                     foreach (string ingredient in allergenCheck)
                     {
                         if (!Potentials[allergen][listCount].Contains(ingredient))
                         {
                             actuals[allergen].Remove(ingredient);
                         }
                     }
                 }
             }
            */
            Dictionary<string, string> actuals = new Dictionary<string, string>();
            Dictionary<string, List<string>> ordered = shortList.OrderBy(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);
            while (ordered.Count > 0)
            {
                string allergen = ordered.Keys.ToArray()[0];
                if (shortList[allergen].Count == 1)
                {
                   
                    string ingredient = shortList[allergen][0];
                    actuals.Add(allergen, ingredient);
                    foreach (string removeAllergen in shortList.Keys)
                    {
                        if (removeAllergen != allergen)
                        {
                            if (shortList[removeAllergen].Contains(ingredient))
                            {
                                shortList[removeAllergen].Remove(ingredient);
                            }
                        }
                    }
                }
                else
                {
                    int stop = 1;
                }
                shortList.Remove(allergen);
                ordered = shortList.OrderBy(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);
            }

            freeFrom.AddRange(allIngredients);
            foreach (string ingredients in actuals.Values)
            {

                if (freeFrom.Contains(ingredients))
                {
                    freeFrom.Remove(ingredients);
                }
                else
                {
                    int stop = 1;
                }

            }

            int appears = 0;
            foreach (string ingredient in freeFrom)
            {
                appears += allOccourances.FindAll(x => x == ingredient).Count;
            }
            Console.WriteLine(appears);
            Dictionary<string, string> orderedActuals = actuals.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            string dangerous = "";
            foreach (string ingredient in orderedActuals.Values)
            {
                dangerous += ingredient + ",";
            }
            dangerous = dangerous.Substring(0, dangerous.Length - 1);
            Console.WriteLine(dangerous);
            Console.ReadLine();
        }
    }
}
