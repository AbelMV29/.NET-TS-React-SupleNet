import { Link } from "react-router";
import { Products } from "../../models/product";
import { Button } from "../button/Button";
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart';
import { addItemToCart } from "../../services/shopping-cart-service";
import { toast } from "sonner";
import { useAuthContext } from "../../context/user-context";

export function ProductCard({id, name, image, price}:Products)
{
    const {value} = useAuthContext();
    const addItem = async ()=>
    {
        const controller: AbortController = new AbortController();
        try 
        {
            const result = await addItemToCart(id, controller);
            toast.success(result.message, { duration: 3000, className: "bg-violet-700 text-white font-bold" });
        } catch (err) {
            const error = err as Error;
            toast.error(error.message, { duration: 3000, className: "bg-red-500 text-white font-bold" });
        }
    }
    
    return(
        <div className="text-center gap-2 shadow-2xl rounded-2xl h-[250px] w-[200px] hover:-translate-y-2 transition-[1s]">
            <Link 
            to={`/products/${id}`} 
            key={id} 
            className="flex flex-col p-2 justify-start items-center">
                <img src={image} className="w-full"/>
                <h4 className="font-bold text-[16px]">{name}</h4>
                <p className="text-sm">${price.toFixed(2)}</p>
                <Button size="small" text="Comprar" type="button"></Button>
            </Link>
            {!value 
                ? 
                <Link to={'/login'}>Añadir al carrito <AddShoppingCartIcon></AddShoppingCartIcon></Link>
                : 
                    (value["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] === 'Customer' 
                    &&
                    <button onClick={addItem}>Añadir al carrito <AddShoppingCartIcon></AddShoppingCartIcon></button>)
            }
        </div>
        
    );
}