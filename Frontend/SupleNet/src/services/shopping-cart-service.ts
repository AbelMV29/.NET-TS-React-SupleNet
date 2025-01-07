import { Result } from "../models/common";
import { ShoppingCart } from "../models/shopping-cart";
import { supleNetInstanceAxios } from "./common-service";

export function getCurrentCart() : Promise<Result<ShoppingCart>>
{
    return supleNetInstanceAxios
    .get<Result<ShoppingCart>>("/cart/current")
    .then(response=>
    {
        return response.data;
    }
    )
    .catch(error=>
    {
        throw new Error(error.message);
    }
    )
}