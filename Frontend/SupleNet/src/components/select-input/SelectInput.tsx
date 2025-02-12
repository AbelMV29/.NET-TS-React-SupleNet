import { Control, Controller, FieldValues, Path } from "react-hook-form";
import { Category } from "../../models/categories";
import { Brand } from "../../models/brands";

interface FormInputProps<T extends FieldValues>
{
    name: Path<T>,
    control: Control<T>,
    label: string,
    errorMessage: string | undefined,
    data: Category[] | Brand[]
}

export function SelectInput<T extends FieldValues>({name, control, label, errorMessage, data} : FormInputProps<T>)
{
    return(
        <Controller
        name={name}
        control={control}
        render={({field})=>(
            <div className={`flex flex-col w-full font-semibold gap-1`}>
                <label>{label}</label>
                <select {...field} className="bg-slate-200 p-2 rounded-md
                outline-none transition-colors duration-500
         focus:outline focus:outline-2 focus:outline-violet-700 font-semibold w-full">
                    <option value="">Selecciona una opción</option>
                    {data.map(e=>
                        {
                            return(<option value={e.id} key={e.id}>{e.name}</option>);
                        }
                    )}
                </select>
                <p className="text-red-600 text-[12px] min-h-[18px]">{errorMessage}</p>
            </div>
        )}
        />
    );
}