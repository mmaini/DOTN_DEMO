using Blazored.LocalStorage;
using DOTN_Common;
using DOTNWeb_Client.Service.IService;
using DOTNWeb_Client.ViewModels;

namespace DOTNWeb_Client.Service
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        public event Action OnChange;
        public CartService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task DecrementCart(ShoppingCart cart)
		{
			var localCart = await _localStorage.GetItemAsync<List<ShoppingCart>>(SD.ShoppingCart);   
           for(int i = 0; i < localCart.Count; i++)
            {
                if (localCart[i].ProductId == cart.ProductId)
                {
                    if (localCart[i].Count ==1 || localCart[i].Count ==0 || cart.Count==0)
                    {
                        localCart.Remove(localCart[i]);
                    }
                    else
                    {
                        localCart[i].Count -= cart.Count;
                    }
                }
            }

            await _localStorage.SetItemAsync(SD.ShoppingCart, localCart);
            OnChange.Invoke();
        }

        public async Task IncrementCart(ShoppingCart cart)
        {
            //dohvati košaricu
            var localCart = await _localStorage.GetItemAsync<List<ShoppingCart>>(SD.ShoppingCart);
            bool itemCart = false;
            if(localCart == null)
            {
                localCart = new List<ShoppingCart>();
            }
            //prošetaj po košarici ako nećeg već u njoj ima
            foreach(var obj in localCart)
            {
                if(obj.ProductId == cart.ProductId)
                {
                    //već postoji u košarici samo uvećaj count
                    itemCart = true;
                    obj.Count += cart.Count;
                }
            }

            //ako proizvod nije u košarici, dodaj ga
            if (!itemCart)
            {
                localCart.Add(new ShoppingCart()
                {
                    ProductId = cart.ProductId,
                    Count = cart.Count
                });
            }

            await _localStorage.SetItemAsync(SD.ShoppingCart, localCart);
            OnChange.Invoke();
        }
    
    
    }
}
