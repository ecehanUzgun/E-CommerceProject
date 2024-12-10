using MODEL.Entities;
using Newtonsoft.Json;

namespace MVC.Models.ShoppingTools
{
    [Serializable]
    public class Cart
    {
        public Cart()
        {
            _myCart = new Dictionary<int, CartItem>();
        }

        [JsonProperty("_myCart")]
        readonly Dictionary<int, CartItem> _myCart;

        [JsonProperty("GetCartItems")]
        public List<CartItem> GetCartItems
        {
            get
            {
                return _myCart.Values.ToList();
            }
            
        }

        public void AddToCart(CartItem item)
        {
            if (_myCart.ContainsKey(item.Id))
            {
                _myCart[item.Id].Amount++;
                return;
            }
            _myCart.Add(item.Id, item); 
        }

        public void Increase(int id)
        {
            _myCart[id].Amount++;
        }

        public void Decrease(int id)
        {
            _myCart[id].Amount--;
            if (_myCart[id].Amount == 0) _myCart.Remove(id); //Dictionary'deki remove metodu, verdiginiz anahtardaki veriyi siler...
        }

        public void RemoveFromCart(int id)
        {
            _myCart.Remove(id);
        }

        [JsonProperty("TotalPrice")]
        public decimal TotalPrice
        {
            get
            {
                return _myCart.Values.Sum(x => x.SubTotal);
            }
        }
       
    }
}
