using P2FixAnAppDotNetCode.Models.Services;
using System.Collections.Generic;
using System.Linq;
using System;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        //Nouveau code : ajout d'une liste permanente
        private List<CartLine> _cardLines = new List<CartLine>();
        private int LineId =  0;

        /// <summary>
        /// Read-only property for display only
        /// </summary>
        public IEnumerable<CartLine> Lines => GetCartLineList();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        /*private*/ public List<CartLine> GetCartLineList()
        {
            //Ancien code
            //return new List<CartLine>();
            return _cardLines;
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            // TODO implement the method
            if (FindProductInCartLines(product.Id) == null)
                {
                    GetCartLineList().Add(new CartLine
                    {
                        OrderLineId = ++LineId,
                        Product = product,
                        Quantity = quantity
                    });
                }
                else
                {
                    foreach (CartLine line in _cardLines)
                    {
                        if (line.Product.Id == product.Id)
                        {
                            line.Quantity += quantity;
                        }
                    }
                }
            
  
        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            // TODO implement the method
            double total = 0;
            foreach (CartLine line in _cardLines) 
            {
                total += (line.Product.Price * line.Quantity);
            }
            //Ancien code
            //return 0.0;
            return total;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // TODO implement the method

            double average = 0.00;
            if (_cardLines.Count > 0)
            {
                int quantity = 0;
                foreach (CartLine line in _cardLines)
                {
                    quantity += line.Quantity;
                }
                average = GetTotalValue() / quantity;
            }
            return average;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // TODO implement the method
            foreach (CartLine line in _cardLines)
            {
                if(line.Product.Id == productId)
                {
                    return line.Product;
                }
                
            }
            return null;
                
        }

        /// <summary>
        /// Get a specific cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
