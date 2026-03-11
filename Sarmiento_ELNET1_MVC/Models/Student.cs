using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sarmiento_ELNET1_MVC.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Course { get; set; } = string.Empty;

        public int Age { get; set; }
    }
}