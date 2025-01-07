import { LineChart } from "@mui/x-charts";

const lineX: string[] = ["Ene", "Feb", "Mar", "Abr", "Jun", "Jul"];
const salesCounts: number[] = [4, 3, 4, 1, 8, 5];
const amounts = [15000, 10000, 14000, 2000, 35000, 15000];

export function SummarytSales() {
    return (
        <div className="bg-white rounded-3xl shadow-2xl w-max p-4 py-5">
            <h2 className="text-xl font-bold text-violet-700">Resumen de ventas</h2>
            <p className="text-slate-500">Pase el mouse sobre los puntos para ver el resumen del mes correspondiente</p>
            <LineChart
                xAxis={[
                    { data: lineX, scaleType: 'point', label:"Meses"},
                ]}
                series={[
                    { data: amounts, label: "Monto recibido", valueFormatter: (value)=>{return `$${value}`}},
                    { data: salesCounts, showMark: false, label: "Cantidad de ventas"}
                ]}
                yAxis={[{
                    valueFormatter: (value)=>`$${value}`
                }]}
                
                height={500}
                className="p-3"
                grid={{horizontal: true}}
            ></LineChart>
        </div>
    );
}