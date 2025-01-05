import { Hero } from "./components/hero/Hero";
import { Features } from "./components/features/Features";

export function HomePage()
{
    return(
        <div className="w-full ml-auto mr-auto flex flex-col items-center px-10 gap-4 pt-4 max-w-[1100px]">
            <Hero></Hero>
            <Features/>
        </div>
    );
}