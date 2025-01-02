import { useEffect, useState } from "react";
import { GetProducts, GetProductsQuery } from "../services/product-service";
import { PaginationProducts } from "../models/product";

export function useFetchProducts({name, page, filterProducts, brandId, categoryId}: GetProductsQuery) : [boolean, string | null, PaginationProducts| null]
{
    const [loaded, setLoaded] = useState(false);
    const [error, setError] = useState<string | null>(null);
    const [data, setData] = useState<PaginationProducts | null>(null)

    useEffect(()=>
    {
        const controller : AbortController = new AbortController();
        setLoaded(false);
        const fetchData = async()=>
        {
            try{
                const response = await GetProducts({name, page, filterProducts, brandId, categoryId},controller);
                setData(response.data);
                setError(null);
            }
            catch(err)
            {
                const error = err as Error;
                setError(error.message);
            }
            finally
            {
                setLoaded(true);
            }

        }

        fetchData();

        return(()=>
        {
            controller.abort();
        });
    }, [name, page, filterProducts, brandId, categoryId]);
    
    return [loaded, error, data]
}