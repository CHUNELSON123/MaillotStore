using MaillotStore.Models;

namespace MaillotStore.Services
{
    public class CartService
    {
        private readonly List<OrderItem> _items = new();

        public event Action OnCartChanged;

        public IReadOnlyList<OrderItem> GetCartItems() => _items.AsReadOnly();

        public void AddToCart(OrderItem item)
        {
            // Check if the same product with the same customization AND size already exists
            var existingItem = _items.FirstOrDefault(i =>
                i.ProductId == item.ProductId &&
                i.PlayerName == item.PlayerName &&
                i.PlayerNumber == item.PlayerNumber &&
                i.Size == item.Size); // Add size to the check

            if (existingItem != null)
            {
                // If it exists, just increase the quantity
                existingItem.Quantity += item.Quantity;
                existingItem.Subtotal = existingItem.Product.Price * existingItem.Quantity;
            }
            else
            {
                // Otherwise, add the new item to the cart
                _items.Add(item);
            }

            // Notify any components that are listening that the cart has changed
            NotifyCartChanged();
        }

        private void NotifyCartChanged() => OnCartChanged?.Invoke();

        // Add these methods inside the CartService class in Services/CartService.cs

        public void RemoveFromCart(OrderItem itemToRemove)
        {
            _items.Remove(itemToRemove);
            NotifyCartChanged();
        }

        public void UpdateQuantity(OrderItem itemToUpdate, int amount)
        {
            var item = _items.FirstOrDefault(i => i.ProductId == itemToUpdate.ProductId && i.PlayerName == itemToUpdate.PlayerName && i.PlayerNumber == itemToUpdate.PlayerNumber);
            if (item != null)
            {
                item.Quantity += amount;
                if (item.Quantity < 1)
                {
                    item.Quantity = 1;
                }
                item.Subtotal = item.Product.Price * item.Quantity;
                NotifyCartChanged();
            }
        }

        public void ClearCart()
        {
            _items.Clear();
            NotifyCartChanged();
        }
    }
}