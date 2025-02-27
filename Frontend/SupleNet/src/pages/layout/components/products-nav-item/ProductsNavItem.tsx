import { Link, NavLink } from "react-router";
import { useFetchNameOrder } from "../../../../hooks/useFetchNameOrder";
import { Category } from "../../../../models/categories";
import { useState } from "react";

export function ProductNavItem()
{
    const {loaded, error, data} = useFetchNameOrder<Category>("/category");
    const [isHover, setIsHover] = useState(false);
    return(
        <NavLink to={"products"} className="relative w-max" onMouseEnter={()=>{setIsHover(true)}} onMouseLeave={()=>{setIsHover(false)}}>
            Productos
            {isHover && loaded && !error && data.length > 0 && (
                <div className="flex flex-col absolute gap-3 p-2 rounded-lg bg-white w-max shadow-2xl left-[-10px]" id="categories">
                    {data.map(c=>
                {
                    return (<Link key={c.id} to={`products?categoryId=${c.id}`}>{c.name}</Link>);
                }
                )}
                </div>
                
            )}
        </NavLink>
    );
}