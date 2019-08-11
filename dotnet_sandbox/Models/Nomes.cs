using System.ComponentModel.DataAnnotations;

public class Nomes
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Snome { get; set; }
}