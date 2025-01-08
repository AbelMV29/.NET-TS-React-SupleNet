namespace SupleNet.Application.UseCases.ItemCart.Queries.GetCartUser
{
    public class GetCartUserQueryResponse
    {
        public GetCartUserQueryResponse(GetCartUserItemQueryResponse[] itemsCart, decimal totalPrice)
        {
            ItemsCart = itemsCart;
            TotalPrice = totalPrice;
        }

        public class GetCartUserItemQueryResponse
        {
            public GetCartUserItemQueryResponse(Guid productId, string productName, decimal price, decimal subTotalPrice, int quantity)
            {
                ProductId = productId;
                ProductName = productName;
                Price = price;
                SubTotalPrice = subTotalPrice;
                Quantity = quantity;
            }

            public Guid ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal Price { get; set; }
            public decimal SubTotalPrice { get; set; }
            public int Quantity { get; set; }
        }
        public GetCartUserItemQueryResponse[] ItemsCart {  get; set; }
        public decimal TotalPrice { get; set; }

    }

}
