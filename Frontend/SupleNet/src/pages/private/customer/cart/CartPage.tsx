import { useShoppingCartContext } from "../../../../context/shopping-cart-context";
import { ShoppingCartItem } from "./components/shopping-cart-item/ShoppingCartItem";

export function CartPage()
{
    const {value} = useShoppingCartContext();
    return (<div className="flex flex-col gap-4 w-full ml-auto mr-auto px-10 pt-4 max-w-[1100px]">
        <h2 className="text-4xl font-bold text-violet-700">Mi carrito</h2>
        <div className="flex flex-col">
            {value? value.itemsCart.map((item)=>{
                return (<ShoppingCartItem key={item.productId} {...item}></ShoppingCartItem>);
            }):<p>Sin productos en el carrito</p>}
            {value && value.totalPrice}
        </div>
    </div>);
}