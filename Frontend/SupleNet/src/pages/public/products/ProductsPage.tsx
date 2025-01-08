import { useSearchParams } from "react-router";
import { FIlterProducts, GetProductsQuery } from "../../../services/product-service";
import { useFetchProducts } from "../../../hooks/useFetchProducts";
import { useState } from "react";
import { FilterSide } from "./components/filter-side/FilterSide";
import { Input } from "../../../components/input/Input";
import { SelectFilter } from "./components/select-filter/SelectFilter";
import { CircularProgress } from "@mui/material";
import { filterToNumber } from "../../../utils/util";
import { ProductCard } from "../../../components/product-card/ProductCard";


export function ProductsPage() {
    const [urlSearchParams, setUrlSearchParams] = useSearchParams();
    
    const category = urlSearchParams.get("category");
    const page = urlSearchParams.get("page");
    const name = urlSearchParams.get("name");
    const brand = urlSearchParams.get("brand");
    const filterProducts = urlSearchParams.get("filterProducts") ? parseInt(urlSearchParams.get("filterProducts")!) as FIlterProducts : FIlterProducts.Feature;

    const [queryParams, setQueryParams] = useState<GetProductsQuery>(
        {
            page: page ? parseInt(page) : 1,
            name: name?? '',
            categoryId: category,
            brandId: brand,
            filterProducts: filterProducts
        });

    const [loaded, error, data] = useFetchProducts(queryParams);

    function setQuery(key:string, newValue: string) : void
    {
        setQueryParams({...queryParams, [key]: newValue});
        urlSearchParams.set(key, newValue);
        setUrlSearchParams(urlSearchParams);
        console.log(queryParams);
    }

    if(!loaded)
        return(<CircularProgress></CircularProgress>);

    if(error)
        return(<div>Error</div>);
    return (
        <div className="flex flex-col gap-4 w-full ml-auto mr-auto px-10  pt-4 max-w-[1100px]">
            <div className="flex flex-row gap-2">
                <div className="w-[180%]">
                    <Input placeholder="Nombre del producto" value={queryParams.name} onChange={(value)=>{setQueryParams({...queryParams, name: value})}}></Input>
                </div>
                <SelectFilter value={filterToNumber(filterProducts)} setValue={setQuery}/>
            </div>
            <FilterSide filterType="brand" title="Marcas" value={queryParams.brandId?? ''} setValue={setQuery}></FilterSide>
            <div className="flex flex-row gap-3">
                <FilterSide filterType="category" title="Categorías" value={queryParams.categoryId?? ''} setValue={setQuery}></FilterSide>
                <div className="flex flex-row flex-wrap gap-2">
                    {data &&  data?.products.length>0? data?.products.map(p=> <ProductCard id={p.id} image={p.image} name={p.name} price={p.price} key={p.id}></ProductCard>): <div>No hay productos</div>}
                </div>
            </div>
        </div>
    );
}