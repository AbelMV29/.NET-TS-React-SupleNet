import { Link } from "react-router";
import { Products } from "../../models/product";
import { Button } from "../button/Button";
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart';

export function ProductCard({id, name, image, price}:Products)
{
    return(
        <Link 
        to={`/products/${id}`} 
        key={id} 
        className="flex flex-col p-2 justify-start text-center gap-2 shadow-2xl rounded-2xl items-center h-[250px] w-[200px] hover:-translate-y-2 transition-[1s]">
            <img src={image} className="w-full"/>
            <h4 className="font-bold text-[16px]">{name}</h4>
            <p className="text-sm">${price.toFixed(2)}</p>
            <Button size="small" text="Comprar" type="button"><AddShoppingCartIcon></AddShoppingCartIcon></Button>
        </Link>
    );
}