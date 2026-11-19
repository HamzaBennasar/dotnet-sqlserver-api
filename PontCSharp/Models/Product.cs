
using PontCSharp.Repositories;

namespace PontCSharp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Product Id:{Id}, Name: {Name}, Price: {Price:c}";
        }

        


    }


}
