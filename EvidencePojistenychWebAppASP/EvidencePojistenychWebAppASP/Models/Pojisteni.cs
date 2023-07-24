using System.ComponentModel.DataAnnotations;

namespace EvidencePojistenychWebAppASP.Models
{
    public class Pojisteni
    {
        public int Id { get; set; }

        [Display(Name = "Pojištění")]
        public string NazevPojisteni { get; set; }

        [Display(Name = "Částka")]
        public int CastkaPojisteni { get; set; }

        [Display(Name = "Předmět pojištění")]
        public string PredmetPojisteni { get; set; }

        [Display(Name = "Plantnost od")]
        public DateTime PlatnostOd { get; set; }

        [Display(Name = "Platnost do")]
        public DateTime PlatnostDo { get; set; }

        // Navigation property

        [Display(Name = "Jméno pojištěnce")]
        public Pojistenec? VlastnikPoj { get; set; }
        public int PojistenecId { get; set; }
    }
}