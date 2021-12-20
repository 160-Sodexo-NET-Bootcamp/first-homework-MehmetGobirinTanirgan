namespace MehmetGobirinTanirgan_Homework1_BookApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string SerialNumber { get; set; }
        public double Price { get; set; }

        public Book(int id, string name, string author, string serialNumber, double price)
        {
            this.Id = id;
            this.Name = name;
            this.Author = author;
            this.SerialNumber = serialNumber;
            this.Price = price;
        }

        public Book()
        {

        }
    }
}
