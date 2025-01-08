import { Link } from "react-router";

interface ButtonProps
{
    text: string,
    action? : ()=>void,
    path?: string,
    type?: 'button' | 'reset' | 'submit',
    children?: React.ReactNode
}

export function Button({text, action, path, type, children}: ButtonProps)
{
    if(path)
    {
        return(
            <Link to={path}>
                <button 
                type={type?? "button"} 
                className={`font-semibold bg-violet-800 px-3 py-2 hover:opacity-85 transition-[.75s] text-white rounded-md`}
                onClick={action}
                >
                    {children} {text}
                </button>
            </Link>
            
            );
    }

    return(
        <button 
        type={type?? "button"} 
        className={`font-semibold bg-violet-800 px-3 py-2 hover:opacity-85 transition-[.75s] text-white rounded-md`}
        onClick={action}
        >
            {children} {text}
        </button>
        );
}