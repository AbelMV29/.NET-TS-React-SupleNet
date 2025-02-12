import { Control, Controller, FieldValues, Path } from "react-hook-form";
import { Input } from "../input/Input";

interface FormInputProps<T extends FieldValues>
{
    name: Path<T>,
    control: Control<T>,
    label: string,
    type: string,
    placeholder: string,
    errorMessage: string | undefined,
    relative: boolean
    children?: React.ReactNode,
}

export function FormInput<T extends FieldValues>({name, control, label, type, placeholder, errorMessage, relative, children} : FormInputProps<T>)
{
    return(
        <Controller
        name={name}
        control={control}
        render={({field})=>(
            <div className={`flex flex-col w-full font-semibold gap-1 ${relative && 'relative'}`}>
                <label>{label}</label>
                <Input {...field} placeholder={placeholder} type={type} ></Input>
                {children}
                <p className="text-red-600 text-[12px] min-h-[18px]">{errorMessage}</p>
            </div>
        )}
        />
    );
}