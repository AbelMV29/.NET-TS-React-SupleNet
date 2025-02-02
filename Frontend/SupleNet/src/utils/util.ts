import { toast } from "sonner";
import { FIlterProducts } from "../services/product-service";
import { addItemToCart, getCurrentCart } from "../services/shopping-cart-service";
import { ShoppingCart } from "../models/shopping-cart";

export function filterToNumber(filter: FIlterProducts)
{
    switch(filter)
    {
        case FIlterProducts.Lower:
            return 0;
        case FIlterProducts.Upper:
            return 1;
        case FIlterProducts.Feature:
            return 2;
    }
}

export function numberToFilter(number: number)
{
    switch(number)
    {
        case 0:
            return FIlterProducts.Lower;
        case 1:
            return FIlterProducts.Upper;
        case 2:
            return FIlterProducts.Feature;
    }
}

export const addItem = async (id: string, setCart: (value: ShoppingCart | null)=>void)=>
    {
        const controller: AbortController = new AbortController();
        try 
        {
            const result = await addItemToCart(id, controller);
            toast.success(result.message, { duration: 3000, className: "bg-violet-700 text-white font-bold" });
            setCart((await getCurrentCart()).data);
        } catch (err) {
            const error = err as Error;
            toast.error(error.message, { duration: 3000, className: "bg-red-500 text-white font-bold" });
        }
    }
export function toastAlert(type: 'success' | 'error', message: string)
{
    if(type === 'success')
    {
        toast.success(message, { duration: 3000, className: "bg-violet-700 text-white font-bold" });
    }
    else
    {
        toast.error(message, { duration: 3000, className: "bg-red-500 text-white font-bold" });
    }
}       