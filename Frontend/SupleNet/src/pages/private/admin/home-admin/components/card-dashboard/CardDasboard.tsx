import { Link } from "react-router";

export interface CardDashboardProps
{
    path:string,
    title: string,
    icon: JSX.Element,
    value: string,
    description: JSX.Element
}

export function CardDashboard({path, title, icon, value, description} : CardDashboardProps)
{
    return(
        <div className="bg-white h-max rounded-3xl shadow-lg hover:bg-violet-700 hover:text-white transition-colors w-[243px] group">
            <Link to={path} className="flex flex-col gap-2 p-4 ">
            <div className="flex flex-row justify-between items-center">
                <span className="text-lg font-semibold text-violet-700 group-hover:text-white">{title}</span>
                {icon}
            </div>
            <div className="flex flex-col gap-1">
                <span className="text-lg font-bold">
                    {value}
                </span>
                {description}
            </div>
        </Link>
        </div>
        
    );
}