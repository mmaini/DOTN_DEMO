using System.ComponentModel.DataAnnotations;

namespace DOTNWeb_Client.ViewModels
{
    public class DetailsVM
    {
        public DetailsVM() 
        {
            Count = 1;
        }
        [Range(1, int.MaxValue, ErrorMessage ="Please enter a value greater than 0")]
        public int Count { get; set; }
        public double Price { get; set; }

    }
}
