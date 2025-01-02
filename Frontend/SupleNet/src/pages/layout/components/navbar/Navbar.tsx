import { NavLink } from "react-router";
import { Input } from "../../../../components/input/Input";
import { ResultSearch } from "../../components/result-search/ResultSearch";
import { useState } from "react";
import { CurrentUser } from "../current-user/CurrentUser";

export function Navbar()
{
    const [search, setSearch] = useState(false);
    const [name, setName] = useState("");

    return(
        <nav className="flex flex-row gap-8 justify-between items-center lg:px-20 2xl:px-40 py-3 border-b-violet-700 border-b-[1px]">
            <h1 className="font-bold text-2xl text-violet-700">SupleNet</h1>
            <ul className="flex flex-row gap-5 font-semibold capitalize">
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
            <div className="w-[350px]">
                <Input 
                placeholder="Buscar producto..."
                value={name} 
                focus={()=>{setSearch(true)}} 
                over={()=>{setSearch(false)}} 
                onChange={setName}></Input>
                {search ===true? <ResultSearch name={name}></ResultSearch> : <></>}
            </div>
            <CurrentUser></CurrentUser>
        </nav>
        
    );
}