import { createContext, ReactNode, useContext, useEffect, useState } from "react";
import { ShoppingCart } from "../models/shopping-cart";
import { getCurrentCart } from "../services/shopping-cart-service";

interface ShoppingCartContextType
{
    value: ShoppingCart | null,
    setValue: React.ForwardedRef<ShoppingCart | null>
}

const shoppingCartContext = createContext<ShoppingCartContextType>({setValue: ()=>{}, value: null});

export function useShoppingCartContext()
{
    return useContext(shoppingCartContext);
}

export function GlobalShoppingCartContextProvider({children}: {children : ReactNode})
{

    const [value, setValue] = useState<ShoppingCart | null>(null);

    useEffect(()=>
    {
        const fetchCurrentCart = async()=>
        {
            try
            {
                setValue((await getCurrentCart()).data)
            }
            catch
            {
                setValue(null);
            }
        }

        fetchCurrentCart();
    }, [])

    console.log(value);

    return (
        <shoppingCartContext.Provider value={{value, setValue}}>{children}</shoppingCartContext.Provider>
    );
}