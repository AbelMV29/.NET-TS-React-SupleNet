import { Button } from "../../../../../components/button/Button";
import "./Hero.css"

export function Hero()
{
    return (
        <div id="hero" className="w-full px- flex flex-col items-start gap-2 justify-end pb-4 pl-4 bg-no-repeat xl:h-[400px] max-h-[400px] rounded-xl bg-cover bg-center ">
            <h2 className="font-bold text-4xl text-white">Proteinas de la más alta calidad</h2>
            <Button text="Ver ahora" type="button"></Button>
        </div>
    );

}