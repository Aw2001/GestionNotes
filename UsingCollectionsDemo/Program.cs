using System;
using System.Collections;

namespace UsageCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList lstEtudiant = new SortedList();
            lstEtudiant.Add(1, new Etudiant { NO = 1, Prenom = "Mouhamad Mourtada", Nom = "Diop", NoteCC = 18, NoteDevoir = 14 });
            lstEtudiant.Add(2, new Etudiant { NO = 2, Prenom = "Mame Diarra", Nom = "Ngom", NoteCC = 16.0, NoteDevoir = 18.5 });
            lstEtudiant.Add(3, new Etudiant { NO = 3, Prenom = "Awa", Nom = "Fall", NoteCC = 20, NoteDevoir = 20 });

            
            int nbEtudiantsDeLaListe = lstEtudiant.Count;

            Console.WriteLine("Liste initiale d'étudiants :");
            AfficherListeEtudiants(lstEtudiant);
            
            // Demander à l'utilisateur combien d'étudiants il souhaite ajouter
            int nombreEtudiants = DemanderNombreEtudiants();

            for (int i = 0; i < nombreEtudiants; i++)
            {
                nbEtudiantsDeLaListe++;
                Console.WriteLine($"\nPour l'étudiant numéro {nbEtudiantsDeLaListe}:");

                while (true) {
                    int no = DemanderNumeroOrdre();
                    if (lstEtudiant.ContainsKey(no))
                    {
                        Console.WriteLine($"Le numéro d’ordre {no} existe déjà. Veuillez en choisir un autre.");
                    }
                    else {
                        string prenom = DemanderSaisie("Prénom");
                        string nom = DemanderSaisie("Nom");
                        double noteCC = DemanderNote("Note de Contrôle Continu");
                        double noteDevoir = DemanderNote("Note de Devoir");

                        lstEtudiant.Add(no, new Etudiant { NO = no, Prenom = prenom, Nom = nom, NoteCC = noteCC, NoteDevoir = noteDevoir });
                        break;
                    }
                }
                
                
            }
             // Afficher la liste après ajout des nouveaux étudiants
             AfficherEtudiants(lstEtudiant);
        }
    
        static int DemanderNombreEtudiants()
        {
            int nombreEtudiants;
            while (true)
            {
                Console.Write("Donner le nombre d'étudiants que vous voulez saisir ? ");
                if (int.TryParse(Console.ReadLine(), out nombreEtudiants) && nombreEtudiants > 0)
                {
                    return nombreEtudiants;
                }
                else
                {
                    Console.WriteLine("Veuillez entrer un nombre entier valide pour le nombre d'étudiants.");
                }
            }
        }

        static int DemanderNumeroOrdre()
        {
            int no;
            while (true)
            {
                Console.Write("Numéro d’ordre (NO) : ");
                if (int.TryParse(Console.ReadLine(), out no))
                {
                    return no;
                }
                else
                {
                    Console.WriteLine("Veuillez entrer un numéro d'ordre valide (un nombre entier).");
                }
            }
        }

        static string DemanderSaisie(string champ)
        {
            Console.Write($"{champ} : ");
            return Console.ReadLine();
        }

        static double DemanderNote(string noteType)
        {
            double note;
            while (true)
            {
                Console.Write($"{noteType} : ");
                if (double.TryParse(Console.ReadLine(), out note) && note >= 0 && note <= 20)
                {
                    return note;
                }
                else
                {
                    Console.WriteLine("Veuillez entrer une note valide entre 0 et 20.");
                }
            }
        }


        static void AfficherListeEtudiants(SortedList lstEtudiant)
        {
            int lignesParPage = 5;

            Console.Write("\nChoisissez le nombre de lignes par page (entre 1 et 15) [Appuyez sur Entrée pour utiliser la valeur par défaut (5)] : ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                if (int.TryParse(input, out int nombre) && nombre >= 1 && nombre <= 15)
                {
                    lignesParPage = nombre;
                }
                else
                {
                    Console.WriteLine("Nombre invalide, utilisation de la valeur par défaut (5).");
                }
            }

            double sommeMoyennes = 0;
            int index = 0;
            int totalEtudiants = lstEtudiant.Count;

            foreach (DictionaryEntry etudiant in lstEtudiant)
            {
                Etudiant autreEtudiant = (Etudiant)etudiant.Value;
                Console.WriteLine($"NO: {autreEtudiant.NO}, PréNom: {autreEtudiant.Prenom},Nom: {autreEtudiant.Nom}, NoteCC: {autreEtudiant.NoteCC}, NoteDevoir: {autreEtudiant.NoteDevoir}, Moyenne: {autreEtudiant.Moyenne}");
                sommeMoyennes += autreEtudiant.Moyenne;
                index++;

                if (index % lignesParPage == 0 && index != totalEtudiants)
                {
                    Console.Write("\nAppuyez sur Entrée pour continuer...");
                    Console.ReadLine();
                }
            }

            double moyenneClasse = sommeMoyennes / lstEtudiant.Count;
            Console.WriteLine($"\nMoyenne de la classe : {moyenneClasse:F2}");

        }

         static void AfficherEtudiants(SortedList lstEtudiant)
        {
            AfficherListeEtudiants(lstEtudiant);

            // Option pour quitter
            Console.WriteLine("\nTapez 'q' pour quitter.");
            while (Console.ReadLine().ToLower() != "q") ;
        }
    }
}
