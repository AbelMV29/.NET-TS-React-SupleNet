import { FilterGeneric } from "../filter-side/FilterSide"

interface InputRadioProps {
    label: string,
    value: string,
    nameProperty: FilterGeneric,
    setValue: (newVale: string)=>void,
    checked: boolean
  }
  
  export function InputRadio({label, value, nameProperty, setValue, checked}: InputRadioProps) {
    return (
        <div>
            <input defaultChecked={checked} className="hidden peer" id={label} name={nameProperty} value={value} onClick={()=>{setValue(value)}} type="radio"/>
            <label className="text-sm bg-violet-100 hover:bg-violet-200 cursor-pointer peer-checked:bg-violet-700 p-2 peer-checked:text-white transition-colors rounded-3xl" htmlFor={label}>
                {label}
            </label>
        </div>
        
        
    );
  }