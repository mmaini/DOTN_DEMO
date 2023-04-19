using System.ComponentModel.DataAnnotations;

namespace DOTN_Models
{
	public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public bool ShopFavorites { get; set; }
        public bool CustomerFavorites { get; set; }
        public string Color { get; set; }
        public string ImageUrl { get; set; }
        [Range(1, int.MaxValue, ErrorMessage ="Please select a category")]
        public int CategoryId { get; set; }
        [Range(0.0, Double.PositiveInfinity, ErrorMessage = "Price should be a positive number")]
        public double Price { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
