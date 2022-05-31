using ShopOnline.API.Entities;
using ShopOnline.Models.Dtos;

namespace ShopOnline.API.Extensions
{
    public static class DtoConversion
    {
        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products,
                                                           IEnumerable<ProductCategory> productCategories)
        {
            return (from product in products
                    join category in productCategories
                    on product.CategoryId equals category.Id
                    select new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        ImageURL = product.ImageURL,
                        CategoryName = category.Name,
                        Price = product.Price,
                        Qty = product.Qty,
                        CategoryId = product.CategoryId
                    }).ToList();
        }
    }
}
