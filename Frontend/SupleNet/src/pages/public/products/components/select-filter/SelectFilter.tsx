interface SelectFilterProps
{
    value: number
    setValue: (key: string, newValue: string) => void;
}

export function SelectFilter({value, setValue} : SelectFilterProps)
{
    return(
        <div className="flex flex-col gap-1">
            <p>Ordenar por</p>
            <select value={value} className="bg-slate-200 p-2 w-full" onChange={(e)=>setValue("filterProducts", e.target.value)}>
                <option value="0">Menor precio</option>
                <option value="1">Mayor precio</option>
                <option value="2">Destacados</option>
            </select>
        </div>
        
    );
}