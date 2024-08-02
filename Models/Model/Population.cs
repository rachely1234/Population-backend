using SQLite;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;


namespace Models.Model
{
    public class Population
    {
        public int Id { get; set; }

        [Required] 
        [Column("popolation")]
        public string Name { get; set; }

        

    }
}
