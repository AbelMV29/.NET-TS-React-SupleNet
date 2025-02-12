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
        if(!valueAuth || valueAuth?.["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] !== "Customer")
        {
            setValue(null);
            return;
        }
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

    return (
        <shoppingCartContext.Provider value={{value, setValue}}>{children}</shoppingCartContext.Provider>
    );
}