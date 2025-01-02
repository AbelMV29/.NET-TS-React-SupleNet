import { CircularProgress } from "@mui/material";
import { useFetchProducts } from "../../../../../hooks/useFetch";
import { FIlterProducts } from "../../../../../services/product-service";
import { ProductCard } from "../../../../../components/product-card/ProductCard";

export function Features()
{
    const [loaded, error, data] = useFetchProducts({name:"", page:1,filterProducts:FIlterProducts.Feature});

    return(<section className="flex flex-col items-center gap-9">
        <h2 className="font-bold text-3xl text-violet-700">Productos Destacados</h2>
        
        {!loaded ? (
            <CircularProgress></CircularProgress>
        ): error ?(
            <p>Sin productos que mostrar</p>
        ):(<div className="flex flex-row justify-center lg:justify-start flex-wrap w-full">
            
            
            {data?.products.slice(0, 4).map(product=>
            {
                return(<ProductCard key={product.id} id={product.id} name={product.name} image={product.image} price={product.price}></ProductCard>);
            }
            )}
            </div>
        )}
    </section>);
}