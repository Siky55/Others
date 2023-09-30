using System.ComponentModel.DataAnnotations;

namespace PVA_project.Data.Classes
{
    public class CompanyKeys

    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CompanyKey { get; set; }

        [Required]
        public string CompanyHash { get; set; }

    }
}
