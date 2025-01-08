import { FIlterProducts } from "../services/product-service";

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