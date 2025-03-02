using System;

namespace UsageCollections
{
    public class Etudiant
    {
        public string Nom {  get; set; }
        public string Prenom { get; set; }
        public int NO {  get; set; }
        public double NoteCC { get; set; }
        public double NoteDevoir {  get; set; }
        public double Moyenne => (NoteCC * 0.33) + (NoteDevoir * 0.67);



    }
}
