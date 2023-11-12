using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibreriaSXXI.Models;

public partial class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; }
    public int Chapters { get; set; }
    public int Pages { get; set; }
    public decimal Price { get; set; }
    public int AuthorId { get; set; }
    public virtual Author? Author { get; set; }
}
