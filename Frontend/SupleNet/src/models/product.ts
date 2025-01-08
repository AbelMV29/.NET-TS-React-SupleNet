export interface Products
{
    id: string,
    name: string,
    price: number,
    image: string
}

export interface PaginationProducts
{
    page: number,
    totalPage: number,
    products: Products[]
}

