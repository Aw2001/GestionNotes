using System;


    public class Etudiant
    {
        public string Nom {  get; set; }
        public string Prenom { get; set; }
        public int NO {  get; set; }
        public double NoteCC { get; set; }
        public double NoteDevoir {  get; set; }

        // Calcul de la moyenne avec pondération
        public double Moyenne => (NoteCC * 0.33) + (NoteDevoir * 0.67);

        public override string ToString()
        {
            return $"{NO} - {Prenom} {Nom} | CC: {NoteCC} | Devoir: {NoteDevoir} | Moy: {Moyenne:F2}";
        }

    }


