import { Result } from "../models/common";
import { PaginationProducts } from "../models/product";
import { supleNetInstanceAxios } from "./common-service";

export interface GetProductsQuery
{
    page: number,
    name: string,
    filterProducts?: FIlterProducts,
    categoryId?: string | null,
    brandId?: string | null
}

export enum FIlterProducts
{
    Lower = 0,
    Upper = 1,
    Feature = 2
}

export async function GetProducts({page = 1, name = "", filterProducts = FIlterProducts.Feature, categoryId = null, brandId = null} : GetProductsQuery, controller: AbortController) : Promise<Result<PaginationProducts>>
{
    const categoryUrl: string = `&categoryId=${categoryId?? ''}`;
    const brandUrl: string = `&brandId=${brandId?? ''}`;
    return supleNetInstanceAxios
    .get<Result<PaginationProducts>>(`/products?Page=${page}&name=${name}&filterProducts=${filterProducts}${categoryUrl}${brandUrl}`, {signal: controller.signal})
    .then(response=>
    {
        return response.data;
    })
    .catch(error=>{
        throw new Error("Error al obtener los datos, código: "+error)
    });
}