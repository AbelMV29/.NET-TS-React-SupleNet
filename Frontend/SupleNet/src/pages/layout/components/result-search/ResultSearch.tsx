import { useEffect, useState } from "react";
import { ResultSearchItem } from "../result-search-item/ResultSearchItem";
import { Products } from "../../../../models/product";
import { GetProducts } from "../../../../services/product-service";
import { CircularProgress } from "@mui/material";

interface ResultSearchProps
{
    name:string,
}

const baseDiv : string = "absolute flex flex-col gap-2 mt-1 w-[350px] bg-slate-50 shadow-lg p-2";

export function ResultSearch({name} : ResultSearchProps)
{
    const [data, setData] = useState<Products[]>([])
    const [loaded, setLoaded] = useState(false);
    const [message, setMessage] = useState<string| null>(null);
    useEffect(()=>
    {
        if(!name)
            return;
        const controller: AbortController = new AbortController();
        const fetchData = async ()=>
        {
            try
            {
                const dataResponse = await GetProducts({name:name, page:1}, controller);

                setData(dataResponse.data.products);
                setMessage(null);
            }
            catch(err)
            {
                const result = err as Error
                setMessage(result.message);

                console.log(result.message);
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
    }, [name])

    if(name && !loaded)
        return (
        <div className={`${baseDiv} items-center`}>
            <CircularProgress></CircularProgress>
        </div>
        );

    if(name && message)
        return (
        <div className={baseDiv}>
            <p className="text-red-600">{message}</p>
        </div>
        );

    if(name && loaded && !message)
    {
        return(<div className={baseDiv}>
            <p>Resultados para proteina {name}</p>
            <hr></hr>
            {data.length > 0 ? data.map(p=>
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