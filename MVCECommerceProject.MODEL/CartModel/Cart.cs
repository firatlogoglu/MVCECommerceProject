using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCECommerceProject.MODEL.CartModel
{
    public class Cart
    {
        Dictionary<Guid, CartItem> _myCart = new Dictionary<Guid, CartItem>();

        public List<CartItem> MyCart
        {
            get
            {
                return _myCart.Values.ToList();
            }
        }

        public void AddItem(CartItem item)
        {
            if (_myCart.ContainsKey(item.ID))
            {
                _myCart[item.ID].Quantity += item.Quantity;
                return;
            }
            _myCart.Add(item.ID, item);
        }
    }
}