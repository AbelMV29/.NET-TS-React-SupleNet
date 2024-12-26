interface InputProps
{
    focus?: ()=>void,
    over?: ()=>void,
    onChange?: (value:string)=> void,
    value: string
}

export function Input({focus, over, onChange, value}: InputProps) {
    return (
      <input
        className="bg-slate-200 p-2 rounded-md outline-none transition-colors duration-500
         focus:outline focus:outline-2 focus:outline-violet-700 font-semibold xl:min-w-[300px]"
        type="text"
        placeholder="Buscar producto..."
        value={value}
        onFocus={focus} onBlur={over} onChange={(event)=>{onChange!(event.target.value)}}
      />
    );
  }