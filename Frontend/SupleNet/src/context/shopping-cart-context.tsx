import { createContext, ReactNode, useContext, useEffect, useState } from "react";
import { ShoppingCart } from "../models/shopping-cart";
import { getCurrentCart } from "../services/shopping-cart-service";
import { useAuthContext } from "./user-context";

interface ShoppingCartContextType
{
    value: ShoppingCart | null,
    setValue: React.Dispatch<React.SetStateAction<ShoppingCart | null>>
}

const shoppingCartContext = createContext<ShoppingCartContextType>({setValue: ()=>{}, value: null});

export function useShoppingCartContext()
{
    return useContext(shoppingCartContext);
}

export function GlobalShoppingCartContextProvider({children}: {children : ReactNode})
{
    const {value: valueAuth} = useAuthContext();
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
    }, [valueAuth])

    console.log(value);

    return (
        <shoppingCartContext.Provider value={{value, setValue}}>{children}</shoppingCartContext.Provider>
    );
}