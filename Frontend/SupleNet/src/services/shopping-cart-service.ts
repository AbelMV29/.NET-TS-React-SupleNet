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