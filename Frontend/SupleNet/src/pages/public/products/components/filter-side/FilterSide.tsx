import { CircularProgress } from "@mui/material";
import { useFetchNameOrder } from "../../../../../hooks/useFetchNameOrder";
import { InputRadio } from "../input-radio/InputRadio";
import { Category } from "../../../../../models/categories";
import { Brand } from "../../../../../models/brands";

export type FilterGeneric = 'brand' | 'category';

const classCategory = 'flex flex-col items-start gap-4';
const classBrand = 'flex flex-row items-center gap-2';

interface FilterSideProps
{
    filterType: FilterGeneric,
    title: string, 
    value: string,
    setValue: (key: string, newValue: string) => void
}

export function FilterSide({filterType, title, value, setValue}: FilterSideProps)
{
    const path = filterType === 'brand' ? '/brands' : '/category';
    const [loaded, error, name, setName, order, setOrder, data] = useFetchNameOrder<Category | Brand>(path);

    if(!loaded)
        {
            return <CircularProgress></CircularProgress>
        }

    if(error)
    {
        return <div>Error: {error}</div>
    }

    

    return(
        <div className={`${filterType === 'brand'? classBrand: classCategory}`}>
            <p className="text-violet-700 font-semibold text-lg">{title}</p>
            {filterType === 'brand' ? <InputRadio label="Todos" nameProperty={filterType}  setValue={setValue} checked={true} value="" key="0"></InputRadio>
            :<InputRadio label="Todas las categorías" nameProperty={filterType} setValue={setValue} hecked={true} value="" key="0"></InputRadio>}
            {data.map(e=>
                {
                    return(<InputRadio label={e.name} nameProperty={filterType} setValue={setValue} hecked={false} value={e.id} key={e.id}></InputRadio>);
                }
            )}
        </div>
    );
}