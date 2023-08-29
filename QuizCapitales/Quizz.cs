using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace QuizCapitales
{
    internal class Quizz
    {

        static string[] pays = { "Albanie", "Allemagne", "Andorre", "Autriche", "Belgique", "Biélorussie", "Bosnie-Herzégovine", "Bulgarie", "Chypre", "Croatie" };




        static string[] capitales = { "Tirana", "Berlin", "Andorre-la-Vieille", "Vienne", "Bruxelles", "Minsk", "Sarajevo", "Sofia", "Nicosie", "Zagreb" };


        public static void Jouer()
        {
            bool continuer = true; //! bool pour continuer ou pas le jeux 
            while (continuer)
            {
                int repCorrecte = 0;
                for (int i = pays.Length - 1; i >= 0; i--)
                {
                    if (PosserQuestion(i)) repCorrecte++; //! de gauche a droite
                }




                if (repCorrecte >= 0 && repCorrecte <= 5) //! condition si résulta moin de 5 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Tu n'as EU que {repCorrecte} sur {pays.Length}  Tu es trop nul Rentre chez ta mère!");
                    Console.ResetColor();
                }
                else //! + de 5 
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Félicitation vous avez eu {repCorrecte} réponse(s) correcte(s) sur {pays.Length} Tu es Trop Un BG Ta défoncer Ta mère !  ");
                    Console.ResetColor();
                }
                continuer = DemandeSiRejouer();




            }
        }
        //! Variante acceptant un nombre qulconque de numéros de questions
        public static void Jouer(params int[] numQuestions)

        {
            bool continuer = true;
            while (continuer)
            {
                int repCorrecte = 0;
                foreach (int num in numQuestions)
                {
                    if (num > 0 && num <= pays.Length && PosserQuestion(num - 1)) repCorrecte++;
                }
                if (repCorrecte == numQuestions.Length)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($"Bravo  Continue comme ça !   ");  //! si bonne réponse alor bravo        //Console.WriteLine($"Bravo  réponse(s) correcte(s)   Continue comme ça !   ");
                    Console.ResetColor();
                }

                if (repCorrecte >= 0 && repCorrecte <= 2) //! condition si résulta moin de 5 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Tu n'as EU que {repCorrecte} Réponse corecte !   Tu es trop nul Rentre chez ta mère!");
                    Console.ResetColor();
                }
                else //! + de 5 
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Félicitation vous avez eu {repCorrecte} réponse(s) correcte(s) sur {pays.Length} Tu es Trop Un BG Ta défoncer Ta mère !  ");
                    Console.ResetColor();
                }

                continuer = DemandeSiRejouer();
            }


        }
        //! fin de  while 

        public static (int, int, int) GenererNumero()
        {
            (int n1, int n2, int n3) numéros;
            Random rend = new Random(); //! génération random
            numéros.n1 = rend.Next(1, 11);
            numéros.n2 = rend.Next(1, 11);
            numéros.n3 = rend.Next(1, 11);
            return numéros;
        }

        public static (int, int, int, int, int, int) SaisirNumero()
        {
            (int n1, int n2, int n3, int n4, int n5, int n6) numéros;
            
            numéros.n1 = SaisirNombre(1, 10);
            numéros.n2 = SaisirNombre(1, 10);
            numéros.n3 = SaisirNombre(1, 10);
            numéros.n4 = SaisirNombre(1, 10);
            numéros.n5 = SaisirNombre(1, 10);
            numéros.n6 = SaisirNombre(1, 10);
            return numéros;
        }
        static int SaisirNombre(int min,int max)
        {
            Console.WriteLine($"Saisire un nombre compris entre : {min} et {max}");
            bool repOk;
            int num;
            do
            {
                string? rep = Console.ReadLine();
                repOk = int.TryParse(rep, out num) && num>= min && num<= max;
            }while (!repOk);
            return num;
        }


        static bool PosserQuestion(int numQuestion)
        {

            Console.ForegroundColor = ConsoleColor.DarkMagenta; //! couleur text
            Console.WriteLine($"\nQuelle est la capitale du pays suivant: {pays[numQuestion]}? ");
            Console.ResetColor(); //! rest de couleur 
            string? rep = Console.ReadLine();
            Console.Clear(); //! nettoyage de la console = plus propre 
            if (rep == capitales[numQuestion])
            {



                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"Bravo  Continue comme ça !   ");  //! si bonne réponse alor bravo        //Console.WriteLine($"Bravo  réponse(s) correcte(s)   Continue comme ça !   ");
                Console.ResetColor();


                return true;
            }

            else
                Console.WriteLine($"\nMauvaise réponse. la réponse étai : {capitales[numQuestion]} tu es NULE !!! QUESTION SUIVANTE !.... ou pas 😋  "); // sinon c'est mauvais 
            return false;

        }
        //! mise en place de la rejouabilliter 
        static bool DemandeSiRejouer()
        {
            Console.WriteLine("Voulez-vous rejouer avec moi ? ou bien tu préfère rentrer chez ta mère espèce de beauf 😏 oui / non ");
            string Rep2 = Console.ReadLine();
            if (Rep2 == "Oui" || Rep2 == "oui" || Rep2=="Y")
            {
                Console.Clear();
                return true;
            }
            else
            {

                Console.WriteLine("Merci d'avoir jouer avec moi ! t'es trop null façon !!! 🤣");
                return false;
            }
        }
    }
}

