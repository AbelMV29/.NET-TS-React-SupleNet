import { NavLink, Outlet } from "react-router";
import { Input } from "../input/Input";
import { Button } from "../button/Button";
import { useEffect, useState } from "react";
import { ResultSearch } from "../result-search/ResultSearch";
import { getProducts } from "../../services/product-service";
import { Products } from "../../models/product";

export function Navbar()
{
    const [search, setSearch] = useState(false);
    const [name, setName] = useState("");
    const [data, setData] = useState<Products[]>([])
    useEffect(()=>
    {
        const fetchData = async ()=>
        {
            const dataResponse = await getProducts();
            if(dataResponse)
                setData(dataResponse.data.products);

            console.log(data[0]);
        }
        fetchData();
    }, [name])

    return(
    <>
        <nav className="flex flex-row gap-8 justify-evenly items-center px-10 py-3">
            <h1 className="font-bold text-2xl text-violet-700">SupleNet</h1>
            <ul className="flex flex-row gap-3 font-semibold">
                <li>
                    <NavLink to={"/"}>
                        Inicio
                    </NavLink>
                </li>
                <li >
                    <NavLink to={"products"}>
                        Suplementos
                    </NavLink>
                </li>
                <li>
                <NavLink to={"products"}>
                    Accesorios
                </NavLink>
                </li>
            </ul>
            <div>
                <Input 
                value={name} 
                focus={()=>{setSearch(true)}} 
                over={()=>{setSearch(false)}} 
                onChange={setName}></Input>
                {search ===true? <ResultSearch name={name} data={data}></ResultSearch> : <></>}
            </div>
            
            <Button color="violet-700" text="Ingresar" action={()=>{console.log("hola")}} key={"button-login"}>

            </Button>
        </nav>
        <main>
            <Outlet></Outlet>
        </main>
    </>
    );
}