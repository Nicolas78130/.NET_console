using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Puissance4final
{
    class Program
    {
        //[System.STAThreadAttribute()]
        static void Main(string[] args)
        {
            int[,] plateauJeu = new int[6, 7];
            //Fenetre nico = new Fenetre(plateauJeu);
            bool veutRejouer = true;
            int joueur = 1; //veutRejouer = true;
            while (veutRejouer == true)
            {

                //int i = 1; //Compteur de tour
                //while (veutRejouer==true)
                //{
                //Début du tour = selection de la colonne et descente du jeton
                joueur = joueur % 2 + 1;
                Console.WriteLine("It is the turn of player " + joueur);
                DescenteJeton(plateauJeu, joueur);
                AfficherMatrice(plateauJeu);
                bool Enligne = Puissance4Ligne(plateauJeu);
                bool EnColonne = Puissance4Colonne(plateauJeu);
                bool EnDiagBas = Puissance4DiagBas(plateauJeu);
                bool EnDiagHaut = Puissance4DiagHaut(plateauJeu);
                Console.WriteLine(Enligne);

                //Vérification à chaque tour si le joueur a gagné la partie ou non
                if (Enligne == true)
                {
                    Console.WriteLine("Player " + joueur + " wins !");
                    //System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Do you want to play again ? yes or no ?");
                    //System.Threading.Thread.Sleep(4000);
                    string val = Console.ReadLine();
                    if (val == "no") veutRejouer = false;
                    else
                    {
                        for (int i = 0; i < plateauJeu.GetLength(0); i++)
                        {
                            for (int j = 0; j < plateauJeu.GetLength(1); j++)
                            {
                                plateauJeu[i, j] = 0;
                            }
                        }
                        AfficherMatrice(plateauJeu);
                    }

                }
                else if (EnColonne == true)
                {
                    Console.WriteLine("Player " + joueur + " wins !");
                    //System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Do you want to play again ? yes or no ?");
                    //System.Threading.Thread.Sleep(4000);
                    string val = Console.ReadLine();
                    if (val == "no") veutRejouer = false;
                    else
                    {
                        for (int i = 0; i < plateauJeu.GetLength(0); i++)
                        {
                            for (int j = 0; j < plateauJeu.GetLength(1); j++)
                            {
                                plateauJeu[i, j] = 0;
                            }
                        }
                        AfficherMatrice(plateauJeu);
                    }
                }
                else if (EnDiagBas == true )
                {
                    Console.WriteLine("Player " + joueur + " wins !");
                    //System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Do you want to play again ? yes or no ?");
                    //System.Threading.Thread.Sleep(4000);
                    string val = Console.ReadLine();
                    if (val == "no") veutRejouer = false;
                    else
                    {
                        for (int i = 0; i < plateauJeu.GetLength(0); i++)
                        {
                            for (int j = 0; j < plateauJeu.GetLength(1); j++)
                            {
                                plateauJeu[i, j] = 0;
                            }
                        }
                        AfficherMatrice(plateauJeu);
                    }
                }
                else if (EnDiagHaut == true )
                {
                    Console.WriteLine("Player " + joueur + " wins !");
                    //System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Do you want to play again ? yes or no ?");
                    //System.Threading.Thread.Sleep(4000);
                    string val = Console.ReadLine();
                    if (val == "no") veutRejouer = false;
                    else
                    {
                        for (int i = 0; i < plateauJeu.GetLength(0); i++)
                        {
                            for (int j = 0; j < plateauJeu.GetLength(1); j++)
                            {
                                plateauJeu[i, j] = 0;
                            }
                        }
                        AfficherMatrice(plateauJeu);
                    }
                }
            }
        }

        //Affiche le plateau de jeu dans la console
        //Pas utile avec l'utilisation de l'interface graphique
        static void AfficherMatrice(int[,] matrice)
        {
            if (matrice == null) Console.WriteLine("Matrice null");
            else
            {
                if (matrice.GetLength(0) == 0 && matrice.GetLength(1) == 0) Console.WriteLine("Matrice vide");
                else
                {
                    for (int ligne = 0; ligne < matrice.GetLength(0); ligne++)
                    {
                        for (int colonne = 0; colonne < matrice.GetLength(1); colonne++)
                        {
                            Console.Write(matrice[ligne, colonne]);
                            Console.Write(" ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }

        //Redemande la colonne si elle n'existe pas ou qu'elle est pleine
        static int ChoixColonne(int[,] matrice)
        {
            Console.WriteLine("Choose a column : ");
            int colonne = DemanderNombreValide() - 1;
            Console.WriteLine();

            while ((colonne < 0 || colonne > 6) || matrice[0, colonne] != 0)
            {
                Console.Write("Choose a valid column : ");
                colonne = DemanderNombreValide() - 1;
                Console.WriteLine();
            }
            return colonne;
        }

        //Descend le jeton jusqu'a la dernière case libre de la colonne choisie à l'aide de la fonction précédente
        static void DescenteJeton(int[,] matrice, int joueur)
        {
            int colonne = ChoixColonne(matrice);
            int i = matrice.GetLength(0) - 1;
            while (matrice[i, colonne] != 0)
            {
                i--;
            }
            matrice[i, colonne] = joueur;
        }

        static bool Puissance4Ligne(int[,] matrice)
        {
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1) - 4; j++)
                {

                    if (matrice[i, j] != 0 && matrice[i, j] == matrice[i, j + 1] && matrice[i, j] == matrice[i, j + 2] && matrice[i, j] == matrice[i, j + 3])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static bool Puissance4Colonne(int[,] matrice)
        {
            for (int i = 0; i < matrice.GetLength(0) - 3; i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++)
                {

                    if (matrice[i, j] != 0 && matrice[i, j] == matrice[i + 1, j] && matrice[i, j] == matrice[i + 2, j] && matrice[i, j] == matrice[i + 3, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static bool Puissance4DiagBas(int[,] matrice)
        {
            for (int i = 0; i < matrice.GetLength(0) - 3; i++)
            {
                for (int j = 0; j < matrice.GetLength(1) - 3; j++)
                {

                    if (matrice[i, j] != 0 && matrice[i, j] == matrice[i + 1, j + 1] && matrice[i, j] == matrice[i + 2, j + 2] && matrice[i, j] == matrice[i + 3, j + 3])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static bool Puissance4DiagHaut(int[,] matrice)
        {
            for (int i = 3; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1) - 3; j++)
                {

                    if (matrice[i, j] != 0 && matrice[i, j] == matrice[i - 1, j + 1] && matrice[i, j] == matrice[i - 2, j + 2] && matrice[i, j] == matrice[i - 3, j + 3])
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        //Méthode pour la saisie de colonne pour éviter le bug du jeu si l'ont appuis sur une mauvaise touche
        static int DemanderNombreValide()
        {
            int colonne = 0;
            while (!Int32.TryParse(Console.ReadLine(), out colonne))
            {
                Console.WriteLine("You can't choose this column. Choose a valid one please.");
            }
            return colonne;
        }
    }
}