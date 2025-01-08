import { FeatureItem } from "../feature-item/FeatureItem";
import Accessorios from "../../../../../assets/Sogas.png"
import Aminoacidos from "../../../../../assets/BCAA.png"
import Proteina from "../../../../../assets/Protein.png"
import Equipamiento from "../../../../../assets/Ligas.png"

export function Features()
{

    return(<section className="flex flex-col items-center gap-9 w-full">
        <h2 className="font-bold text-3xl text-violet-700">Productos Destacados</h2>

        <div className="flex flex-row justify-center lg:flex-nowrap lg:justify-between  flex-wrap w-full gap-8">
            <FeatureItem image={Accessorios} name="Accesorios" path="" key={"acces"}/>
            <FeatureItem image={Aminoacidos} name="Aminoacidos" path="" key={"bcaa"}/>
            <FeatureItem image={Proteina} name="Proteina" path="" key={"protein"}/>
            <FeatureItem image={Equipamiento} name="Equipamiento" path="" key={"eslastic"}/>
        </div>
    </section>);
}