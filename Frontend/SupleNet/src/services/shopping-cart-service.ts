import { Result } from "../models/common";
import { ShoppingCart } from "../models/shopping-cart";
import { supleNetInstanceAxios } from "./common-service";

export async function getCurrentCart() : Promise<Result<ShoppingCart>>
{
    return await supleNetInstanceAxios
    .get<Result<ShoppingCart>>("/cart/current")
    .then(response=>
    {
        return response.data;
    }
    )
    .catch(()=>
        
        {throw new Error();}
    )
}

export async function addItemToCart(productId: string, controller: AbortController)
{
    return await supleNetInstanceAxios
    .put<Result<object>>(`/cart/additem`, {productId: productId}, {signal:controller.signal})
    .then(response=>
        {
            return response.data;
        }
    )
    .catch(error =>
    {
        throw new Error(error.response?.data || "Ocurrió un error inesperado");
    }
    );
    
}