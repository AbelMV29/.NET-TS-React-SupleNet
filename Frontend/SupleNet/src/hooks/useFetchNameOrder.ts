import { useEffect, useState } from "react";
import { GetByNameOrder } from "../services/common-service";

export function useFetchNameOrder<T>(url:string) 
{
    const [loaded, setLoaded] = useState(false);
    const [error, setError] = useState<string | null>(null);
    const [name, setName] = useState(" ");
    const [orderByDate, setOrderByDate] = useState(true);
    const [data, setData] = useState<T[]>([]);

    useEffect(()=>
    {
        setLoaded(false);
        setError(null);
        const controller : AbortController = new AbortController();
        const fetchData = async ()=>
        {
            try
            {
                const resultData = await GetByNameOrder<T>(`${url}?name=${name}&OrderByDate=${orderByDate}`, controller);
                setData(resultData.data);
                setError(null);
                return;
            }
            catch(error)
            {
                const err = error as Error;
                if(err.name === "AbortError")
                    return;
                setError(err.name);
            }
            finally
            {
                if(!controller.signal.aborted)
                    setLoaded(true);
            }
            

            
        }
        fetchData();

        return(()=>
        {
            controller.abort();
        });
    }, [name, orderByDate, url]);

    return {loaded, error, name, setName, orderByDate, setOrderByDate, data}
}
