import { Link } from "react-router";

interface FaetureItem{
    image: string,
    name: string,
    path:string
}

export function FeatureItem({image, name, path}: FaetureItem)
{
    return(
        <Link to={path} className="flex flex-col gap-2">
            <img src={image}/>
            <p className="text-black font-semibold text-lg">{name}</p>
        </Link>
    );
}