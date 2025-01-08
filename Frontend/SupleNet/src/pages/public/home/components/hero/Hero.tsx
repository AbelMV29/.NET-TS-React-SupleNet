import { Button } from "../../../../../components/button/Button";
import "./Hero.css"

export function Hero()
{
    return (
        <div id="hero" className="w-full flex flex-col items-start gap-2 justify-end pb-4 pl-4 aspect-[20/6] bg-no-repeat rounded-xl bg-cover bg-center border-violet-700 border-[1px]">
            <h2 className="font-bold text-4xl text-white">Proteinas de la más alta calidad</h2>
            <Button text="Ver ahora" type="button"></Button>
        </div>
    );

}