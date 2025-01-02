import React from "react";

interface InputProps
{
    focus?: ()=>void,
    over?: ()=>void,
    onChange?: (value:string)=> void,
    placeholder:string
    value: string,
    name?: string,
    type?:string
}
export const Input = React.forwardRef<HTMLInputElement, InputProps>(
  ({ focus, over, onChange, value, name, placeholder, type }, ref) => {
    return (
      <input
        ref={ref}
        name={name}
        className="bg-slate-200 p-2 rounded-md outline-none transition-colors duration-500
         focus:outline focus:outline-2 focus:outline-violet-700 font-semibold w-full"
        type={type?? 'text'}
        placeholder={placeholder}
        value={value}
        onFocus={focus}
        onBlur={over}
        onChange={(event) => {
          onChange?.(event.target.value);
        }}
      />
    );
  }
);