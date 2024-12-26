import { Result } from "../models/common";
import { PaginationProducts } from "../models/product";

export async function getProducts() : Promise<Result<PaginationProducts>>
{
    const response = await fetch(`${import.meta.env.VITE_API_BASE}Products`)

    const data : Result<PaginationProducts>= await response.json();

    return data;
}