import { useSearchParams } from "react-router";
import { FIlterProducts, GetProductsQuery } from "../../../services/product-service";
import { useEffect, useState } from "react";
import { FilterSide } from "./components/filter-side/FilterSide";
import { Input } from "../../../components/input/Input";
import { SelectFilter } from "./components/select-filter/SelectFilter";
import { filterToNumber } from "../../../utils/util";
import { ProductContainer } from "./components/product-container/ProductContainer";


export function ProductsPage() {
    const [urlSearchParams, setUrlSearchParams] = useSearchParams();

    const category = urlSearchParams.get("categoryId");
    const page = urlSearchParams.get("page");
    const name = urlSearchParams.get("name");
    const brand = urlSearchParams.get("brandId");
    const filterProducts = urlSearchParams.get("filterProducts") ? parseInt(urlSearchParams.get("filterProducts")!) as FIlterProducts : FIlterProducts.Feature;

    const [queryParams, setQueryParams] = useState<GetProductsQuery>(
        {
            page: page ? parseInt(page) : 1,
            name: name ?? '',
            categoryId: category,
            brandId: brand,
            filterProducts: filterProducts
        });

    function setQuery(key: string, newValue: string): void {
        setQueryParams({ ...queryParams, [key]: newValue });
        urlSearchParams.set(key, newValue);
        setUrlSearchParams(urlSearchParams);
    }

    useEffect(() => {
        setQueryParams({
            page: page ? parseInt(page) : 1,
            name: name ?? '',
            categoryId: category,
            brandId: brand,
            filterProducts: filterProducts
        });
    }, [category, page, name, brand, filterProducts]);

    return (
        <div className="flex flex-col gap-4 w-full ml-auto mr-auto px-10  pt-4 max-w-[1100px]">
            <h1 className="text-3xl font-bold text-violet-700">Productos</h1>
            <div className="flex flex-wrap sm:flex-nowrap flex-row gap-2 font-semibold items-center">
                <div className="flex-grow flex flex-col gap-1">
                    <p>Buscar por nombre del producto</p>
                    <Input
                        placeholder="Nombre del producto"
                        value={queryParams.name} onChange={(value) => 
                            {
                                setQuery("name", value);
                            }}/>
                </div>
                <SelectFilter
                    value={filterToNumber(filterProducts)}
                    setValue={setQuery} />
            </div>
            <FilterSide
                key={"brand"}
                filterType="brand" 
                title="Marcas" value={queryParams.brandId ?? ''} 
                setValue={(value) => { setQuery("brandId", value)}}/>
            <div className="flex flex-row gap-3">
                <FilterSide
                    key={"category"} 
                    filterType="category" 
                    title="Categorías" 
                    value={queryParams.categoryId ?? ''} 
                    setValue={(value) => { setQuery("categoryId", value)}}/>
                <hr/>
                <ProductContainer 
                productsQuery={queryParams}/>
            </div>
        </div>
    );
}