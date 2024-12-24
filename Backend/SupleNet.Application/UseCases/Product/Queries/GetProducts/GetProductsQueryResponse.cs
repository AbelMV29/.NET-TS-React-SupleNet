namespace SupleNet.Application.UseCases.Product.Queries.GetProducts
{
    public class GetProductsQueryResponse
    {
        public GetProductsQueryResponse()
        {
            
        }
        public GetProductsQueryResponse(int page, int totalPages, GetProductsItemQueryResponse[] products)
        {
            Page = page;
            TotalPages = totalPages;
            Products = products;
        }

        public class GetProductsItemQueryResponse
        {
            public GetProductsItemQueryResponse()
            {
                
            }
            public GetProductsItemQueryResponse(Guid id, string name, decimal price, string image)
            {
                Id = id;
                Name = name;
                Price = price;
                Image = image;
            }

            public Guid Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Image { get; set; }
        }
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public GetProductsItemQueryResponse[] Products { get; set; }

    }

}
