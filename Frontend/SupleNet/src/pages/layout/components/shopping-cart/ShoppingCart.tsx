import { Link } from "react-router";
import { useAuthContext } from "../../../../context/user-context";
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart';

export function ShoppingCart()
{
    const {value} = useAuthContext();


    if(!value)
        return (
        <Link to={'/login'} className="relative group">
            <AddShoppingCartIcon className="text-violet-700"/>
            <div className="leading-none p-1 text-sm rounded-full left-3 top-4 bg-violet-700 absolute text-white font-semibold">0</div>
            <span className=" bg-violet-700 font-semibold top-[-16px]
             -left-5 text-white absolute text-xs rounded-full px-1 text-nowrap
             transition-all duration-300 opacity-0 group-hover:opacity-100">Mi carrito</span>
        </Link>);

    if(value?.["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] === 'Admin')
        return(<></>);
}