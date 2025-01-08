import { LastActivity } from "./components/last-activity/LastActivity";
import { SummarytSales } from "./components/summary-sales/SummarySales";
import { Header } from "./components/header/Header";

export function HomeAdminPage()
{
    return (<div className="w-full ml-auto mr-auto flex flex-col px-10 gap-4 pt-4 max-w-[1100px]">
        <h1 className="text-3xl font-bold text-violet-700">Panel de Administrador</h1>
        <Header/>
        <div className="flex flex-row gap-4 flex-wrap">
            <SummarytSales/>
            <LastActivity/>
        </div>
    </div>);
}