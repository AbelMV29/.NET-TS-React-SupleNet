import { Link } from "react-router";

interface ButtonProps
{
    text: string,
    action? : ()=>void,
    color: string,
    path?: string
}

export function Button({text, action, path}: ButtonProps)
{
    if(path)
    {
        return(
            <Link to={path}>
                <button 
                type="button" 
                className={`font-semibold bg-violet-800 px-3 py-2 hover:opacity-85 transition-[.75s] text-white rounded-md`}
                onClick={action}
                >
                    {text}
                </button>
            </Link>
            
            );
    }

    return(
        <button 
        type="button" 
        className={`font-semibold bg-violet-800 px-3 py-2 hover:opacity-85 transition-[.75s] text-white rounded-md`}
        onClick={action}
        >
            {text}
        </button>
        );
}