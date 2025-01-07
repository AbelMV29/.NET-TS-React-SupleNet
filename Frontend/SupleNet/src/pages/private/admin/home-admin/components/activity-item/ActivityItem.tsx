import { Link } from "react-router";

interface ActivityItemProps
{
    idSale: string,
    fullName:string,
    email:string,
    price: number
}

export function ActivityItem({idSale, fullName, email, price} : ActivityItemProps)
{
    return(
        <Link to={`sales/${idSale}`} className="w-full flex flex-row justify-between items-center">
            <div className="flex flex-col gap-2">
                <p>{fullName}</p>
                <span className="text-slate-400">{email}</span>
            </div>
            <span className="text-violet-700">
                ${price}
            </span>
        </Link>
    );
}