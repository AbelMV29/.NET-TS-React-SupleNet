import React from "react";
import { useShoppingCartContext } from "../../../../context/shopping-cart-context";
import { ShoppingCartItem } from "./components/shopping-cart-item/ShoppingCartItem";

export function CartPage()
{
    const {value} = useShoppingCartContext();
    return (<div className="flex flex-col gap-4 w-full ml-auto mr-auto px-10 pt-4 max-w-[1100px]">
        <h2 className="text-4xl font-bold text-violet-700">Mi carrito</h2>
        <div className="flex flex-col gap-4 bg-white shadow-lg p-4 rounded-xl">
            <h3 className="text-2xl font-bold text-violet-700">Artículos en el carrito</h3>
            {value && value.itemsCart.length>0? value.itemsCart.map((item)=>{
                return (<React.Fragment key={item.productId}>
                    <ShoppingCartItem {...item} />
                    <hr />
                  </React.Fragment>);
            }):<p>Sin productos en el carrito</p>}
            {value && value.totalPrice>0 && "$"+value.totalPrice.toFixed(2)}
        </div>
    </div>);
}