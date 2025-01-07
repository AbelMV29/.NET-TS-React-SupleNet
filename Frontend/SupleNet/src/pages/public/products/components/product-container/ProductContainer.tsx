import { GetProductsQuery } from "../../../../../services/product-service";
import { useFetchProducts } from "../../../../../hooks/useFetchProducts";
import { CircularProgress } from "@mui/material";
import { ProductCard } from "../../../../../components/product-card/ProductCard";

interface ProductContainerProps
{
    productsQuery: GetProductsQuery
}

export function ProductContainer({productsQuery} : ProductContainerProps)
{
    const [loaded, error, data] = useFetchProducts(productsQuery);

    return(
        (!loaded)?
            (<CircularProgress></CircularProgress>)
        :error? <p>{error}</p>
            :data?.products.length ===0? <p>Sin resultados</p> 
                :data?.products.map(p=>
                {
                    return(<ProductCard id={p.id} image={p.image} name={p.name} price={p.price} key={p.id}></ProductCard>);
                }
                )
    );
}