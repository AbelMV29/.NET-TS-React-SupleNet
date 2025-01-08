import { useEffect, useState } from "react";
import { GetByNameOrder } from "../services/common-service";

export function useFetchNameOrder<T>(url:string) : 
[string, React.Dispatch<React.SetStateAction<string>>, boolean, React.Dispatch<React.SetStateAction<boolean>>, T[]]
{
    const [name, setName] = useState("");
    const [orderByDate, setOrderByDate] = useState(false);
    const [data, setData] = useState<T[]>([]);

    useEffect(()=>
    {
        const controller : AbortController = new AbortController();
        const fetchData = async ()=>
        {
            const resultData = await GetByNameOrder<T>(`${url}?name=${name}&OrderByDate=${orderByDate}`, controller);
            if(resultData.isSuccess)
            {
                setData(resultData.data);
            }
        }
        fetchData();

        return(()=>
        {
            controller.abort();
        });
    }, [name, orderByDate]);

    return [name, setName, orderByDate, setOrderByDate, data]
}
