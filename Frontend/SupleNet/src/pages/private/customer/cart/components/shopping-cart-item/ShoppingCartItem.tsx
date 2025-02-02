import { Link } from "react-router";
import { CartItem, ShoppingCart } from "../../../../../../models/shopping-cart";
import DeleteIcon from '@mui/icons-material/Delete';
import { addItem, toastAlert } from "../../../../../../utils/util";
import { useShoppingCartContext } from "../../../../../../context/shopping-cart-context";
import { getCurrentCart, removeFullItemFromCart, removeItemFromCart } from "../../../../../../services/shopping-cart-service";

const removeItem = async (productId: string, setCart: (value: ShoppingCart | null) => void) => {
    const controller: AbortController = new AbortController();
    try {
        const result = await removeItemFromCart(productId, controller);
        toastAlert('success', result.message ?? '');
        setCart((await getCurrentCart()).data);
    } catch (err) {
        const error = err as Error;
        toastAlert('error', error.message);
    }
}
const removeFullItem = async (productId: string, setCart: (value: ShoppingCart | null) => void) => {
    const controller: AbortController = new AbortController();
    try {
        const result = await removeFullItemFromCart(productId, controller);
        toastAlert('success', result.message ?? '');
        setCart((await getCurrentCart()).data);
    } catch (err) {
        const error = err as Error;
        toastAlert('error', error.message);
    }
};
export function ShoppingCartItem({ price, productId, productName, quantity, subTotalPrice }: CartItem) {
    const { setValue } = useShoppingCartContext();

    function removeItemClick() {
        removeItem(productId, setValue);
    }

    function removeFullItemClick() {
        removeFullItem(productId, setValue);
    }

    function addItemClick() {
        addItem(productId, setValue);
    }

    return (
        <div className="flex flex-row justify-between items-center">
            <div className="flex flex-row gap-4">
                <img src="" alt='image' className="w-[100px] h-[100px] bg-red-500 rounded-md" />
                <div className="flex flex-col text-start justify-center">
                    <Link to={`/products/${productId}`} className="font-semibold"><h3>{productName}</h3></Link>
                    <p>${price.toFixed(2)}</p>
                </div>
            </div>
            <div className="flex flex-row gap-4 items-center">
                <button className="border-[1px] border-slate-400 px-2 rounded-md hover:bg-slate-100 active:opacity-75" onClick={removeItemClick}>-</button>
                <p>{quantity === 1 ? quantity + ' unidad' : quantity + ' unidades'}</p>
                <button className="border-[1px] border-slate-400 px-2 rounded-md hover:bg-slate-100 active:opacity-75" onClick={addItemClick}>+</button>
                <div className="flex flex-row text-center justify-center">
                    <p><span className="font-semibold">Total producto:</span> ${subTotalPrice.toFixed(2)}</p>
                </div>
                <button className="hover:-translate-y-1 transform transition-all duration-200" onClick={removeFullItemClick}>
                    <DeleteIcon className="text-red-500"></DeleteIcon>
                </button>
            </div>
        </div>
    );
}