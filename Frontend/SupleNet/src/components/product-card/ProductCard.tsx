import { Link } from "react-router";
import { Products } from "../../models/product";
import { Button } from "../button/Button";
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart';

export function ProductCard({id, name, image, price}:Products)
{
    return(
        <Link 
        to={`products/${id}`} 
        key={id} 
        className="flex flex-col p-2 py-4 items-center gap-4 shadow-2xl w-[300px] hover:-translate-y-2 transition-[1s]">
            <img src={image} className=" w-full"/>
            <h4 className="font-bold">{name}</h4>
            <p>${price.toFixed(2)}</p>
            <Button text="Comprar" type="button"><AddShoppingCartIcon></AddShoppingCartIcon></Button>
        </Link>
    );
}