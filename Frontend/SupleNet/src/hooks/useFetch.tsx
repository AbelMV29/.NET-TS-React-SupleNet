import { useEffect, useState } from "react";
import { GetProducts } from "../services/product-service";
import { Result } from "../models/common";
import { PaginationProducts } from "../models/product";

interface UseFetchProps<T> {
    dependencyChanges: unknown[]
    action: (abortCotroller: AbortController) => Promise<T>
}
export function useFetch<T>({ action, dependencyChanges }: UseFetchProps<T>) {
    const [loaded, setLoaded] = useState(false);
    const [error, setError] = useState<string | null>(null);
    const [data, setData] = useState<T>()

    useEffect(() => {
        const controller = new AbortController();
        setError(null);
        setLoaded(false);
        const fetch = async () => {
            try {
                setData(await action(controller));
            }
            catch (err) {
                const error = err as Error;
                setError(error.message)
            }
            finally
            {
                setLoaded(true);
            }
        }
        fetch();
        return ()=>
        {
            controller.abort();
        }
    }, [action, ...dependencyChanges]
    )

    return {loaded, error, data}
}

export function Uso() {
    const [name, setName] = useState("");
    GetProducts({ name: "", page: 1 }, new AbortController())
    useFetch<Result<PaginationProducts>>({
        action: (controller) => {
            return GetProducts({ name: "", page: 1 }, controller)
        }, dependencyChanges: [name]
    })

    return (<></>);
}