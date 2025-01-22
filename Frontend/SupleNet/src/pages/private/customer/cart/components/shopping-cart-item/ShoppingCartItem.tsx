import { Link } from "react-router";
import { CartItem } from "../../../../../../models/shopping-cart";

export function ShoppingCartItem({price, productId, productName, quantity, subTotalPrice} : CartItem)
{
    return(
        <div className="flex flex-row justify-between items-center">
            <div className="flex flex-row gap-4">
                <img src="" alt={productName}/>
                <div className="flex flex-col text-center justify-center">
                    <Link to={`/products/${productId}`}><h3>{productName}</h3></Link>
                    <p>${price.toFixed(2)}</p>
                </div>
            </div>
            <div className="flex flex-row gap-4 items-center">
                <button>-</button>
                <p>{quantity}</p>
                <button>+</button>
                <div className="flex flex-col text-center justify-center">
                    <p>Total producto</p>
                    <p>{subTotalPrice.toFixed(2)}</p>
                </div>
                <button>Eliminar</button>
            </div>
        </div>
    );
}