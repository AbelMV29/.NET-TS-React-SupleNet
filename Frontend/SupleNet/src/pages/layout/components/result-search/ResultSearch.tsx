import { ResultSearchItem } from "../result-search-item/ResultSearchItem";
import { CircularProgress } from "@mui/material";
import { useFetchProducts } from "../../../../hooks/useFetchProducts";

interface ResultSearchProps
{
    name:string,
}

const baseDiv : string = "absolute flex flex-col gap-2 mt-1 w-[350px] bg-slate-50 shadow-lg p-2";

export function ResultSearch({name} : ResultSearchProps)
{
    const [loaded, error, data] = useFetchProducts({name: name, page: 1,});

    if(name && !loaded)
        return (
        <div className={`${baseDiv} items-center`}>
            <CircularProgress></CircularProgress>
        </div>
        );

    if(name && error)
        return (
        <div className={baseDiv}>
            <p className="text-red-600">{error}</p>
        </div>
        );

    if(name && loaded && !error)
    {
        return(<div className={baseDiv}>
            <p>Resultados para proteina {name}</p>
            <hr></hr>
            {data!.products.length > 0 ? data?.products.map(p=>
                {
                    return(<ResultSearchItem key={p.id} image={p.image} name={p.name}/>);
                }
            ):"Sin resultados.."}
        </div>);
    }

    return(
    <div className="absolute mt-1 xl:min-w-[350px] bg-slate-50 shadow-md p-2">
        Busque un producto...
    </div>
    );
}