using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameGenerator
{
    class NameGenerator
    {
        static void Main(string[] args)
        {
            string[] maleNames = { "Efe", "Emre", "Arda", "İhsan", "Ege", "Oğuz", "Oğuzhan", "Cenk", "Kenan", "Mehmet", "Ali", "Veli", "Olcay", "Burak", "Can" };
            string[] femaleNames = { "Emine", "Ayşe", "Canan", "Derya", "Seda", "Sena", "Pınar", "Yağmur", "Eda", "Ela", "Zeynep", "Ece", "Gözde", "Duru", "İrem" };
            string[] surnames = { "İpek", "Yılmaz", "Yıldız", "Işık", "Gezer", "Yalçın", "Şen", "Yazıcı", "Yıldırım", "Sağlam" };

            Console.Write("Do you want this person male or female ('m' for male 'f' for female) ");
            string maleFemaleAns = Console.ReadLine().ToLower();
            bool maleOrFemale = true;
            switch (maleFemaleAns)
            {
                case "m":
                    maleOrFemale = true;
                    break;
                case "f":
                    maleOrFemale = false;
                    break;
                default:
                    Console.WriteLine("Bir hata oldu.");
                    break;
            }

            var rand = new Random();

            bool continueOrNot = true;
            while (continueOrNot)
            {
                int oneTwoAns = rand.Next(2);
                bool oneOrTwoNames = true;
                int nameAmount = 1;
                if (oneTwoAns == 0)
                {
                    oneOrTwoNames = true;
                    nameAmount = 1;
                }
                else
                {
                    oneOrTwoNames = false;
                    nameAmount = 2;
                }

                if (maleOrFemale && (oneOrTwoNames || !oneOrTwoNames))
                {
                    int nameRand = rand.Next(maleNames.Length);
                    int nameRand2 = rand.Next(maleNames.Length);
                    if (nameAmount == 1)
                    {
                        Console.Write(maleNames[nameRand] + " ");
                    }
                    else
                    {
                        Console.Write(maleNames[nameRand] + " " + maleNames[nameRand2] + " ");
                    }
                    int surnameRand = rand.Next(surnames.Length);
                    Console.Write(surnames[surnameRand]);
                }
                if (!maleOrFemale && (oneOrTwoNames || !oneOrTwoNames))
                {
                    int nameRand = rand.Next(femaleNames.Length);
                    int nameRand2 = rand.Next(femaleNames.Length);
                    if (nameAmount == 1)
                    {
                        Console.Write(femaleNames[nameRand] + " ");
                    }
                    else
                    {
                        Console.Write(femaleNames[nameRand] + " " + femaleNames[nameRand2] + " ");
                    }
                    int surnameRand = rand.Next(surnames.Length);
                    Console.Write(surnames[surnameRand]);
                }
                Console.WriteLine();
                Console.Write("Do you want to try again? (y/n) ");
                string continueAns = Console.ReadLine().ToLower();

                switch (continueAns)
                {
                    case "y":
                        continueOrNot = true;
                        break;
                    case "n":
                        continueOrNot = false;
                        break;
                    default:
                        Console.WriteLine("ERROR");
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
