import { Products } from "../../models/product";
import { ResultSearchItem } from "../result-search-item/ResultSearchItem";

interface ResultSearchProps
{
    name:string,
    data: Products[]
}

export function ResultSearch({name, data} : ResultSearchProps)
{
    if(name)
    {
        return(<div className="absolute flex flex-col gap-2 mt-1 xl:min-w-[300px] bg-slate-50 shadow-md p-2">
            <p>Resultados para proteina {name}</p>
            <hr></hr>
            {data.map(p=>
                {
                    return(<ResultSearchItem key={p.id} image={p.image} name={p.name}/>);
                }
            )}
        </div>);
    }
    return(<div className="absolute mt-1 xl:min-w-[300px] bg-slate-50 shadow-md p-2">
        Busque un producto...
    </div>);
}