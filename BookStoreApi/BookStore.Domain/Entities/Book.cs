namespace BookStore.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }


    //navigation prop
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
