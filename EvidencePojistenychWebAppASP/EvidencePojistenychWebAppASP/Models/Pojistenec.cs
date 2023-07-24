using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace EvidencePojistenychWebAppASP.Models
{
    
    public class Pojistenec
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vyplňte jméno")]
        [Display(Name = "Jméno")]
        public string Jmeno { get; set; }

        [Required(ErrorMessage = "Vyplňte příjmení")]
        [Display(Name = "Příjmení")]
        public string Prijmeni { get; set; }
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        public int TelCislo { get; set; }

        [Display(Name = "Ulice a číslo popisné")]
        public string UliceCisloPop { get; set; }

        [Display(Name = "Město")]
        public string Mesto { get; set; }

        [Display(Name = "PSČ")]
        public int Psc { get; set; }

        // Navigation property

        [Display(Name = "Název pojištění")]
        public virtual ICollection<Pojisteni>? MojePojisteni { get; set; }



        /// <summary>
        /// Pro zobrazení celého jména
        /// </summary>
        public string CeleJmeno
        {
            get { return Jmeno + " " + Prijmeni; }
        }

        /// <summary>
        /// Pro zobrazení Ulice, č.popisného a Města pod názvem Bydliště
        /// </summary>
        [Display(Name = "Bydliště")]

        public string Bydliste
        {
            get { return UliceCisloPop + ", " + Mesto; }

        }



    }
}
