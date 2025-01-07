export interface ShoppingCart
{
    totalPrice: number,
    itemsCart: CartItem[]
}

export interface CartItem
{
    productId: string,
    productName: string,
    price: number,
    subTotalPrice: number,
    quantity: number
}