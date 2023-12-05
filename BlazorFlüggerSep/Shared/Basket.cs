using Domain.Models;


namespace BlazorFlüggerSep.Shared
{
    public static class Basket
    {
        public static List<Product> ProductsInBasket = new List<Product>();

        public static string AddProductToBasket(Product p)
        {
            if (!ProductsInBasket.Exists(product => product.ProductId == p.ProductId))
            {
                ProductsInBasket.Add(p);
                return "Item has been added";
            }

            return "Item has already been added";
            
        }
        
        public static bool RemoveProductFromBasket(int index)
        {
            Product? productToRemove = ProductsInBasket.Find(product => product.ProductId == index);
            if (productToRemove != null) return ProductsInBasket.Remove(productToRemove);
            return false;
        }
    }
}

