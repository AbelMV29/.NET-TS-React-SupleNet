import { Hero } from "./components/hero/Hero";
import { Features } from "./components/features/Features";

export function HomePage()
{
    return(
        <div className="w-full flex flex-col px-2 lg:px-32 2xl:px-72 gap-4">
            <Hero></Hero>
            <Features/>
        </div>
    );
}