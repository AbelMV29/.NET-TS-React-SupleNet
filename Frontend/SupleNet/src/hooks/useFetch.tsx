import { useEffect, useState } from "react";

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
            catch (error) {
                const err = error as Error;
                if(err.name === 'AbortError')
                    return;
                setError(err.message)
            }
            finally
            {
                if(!controller.signal.aborted)
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