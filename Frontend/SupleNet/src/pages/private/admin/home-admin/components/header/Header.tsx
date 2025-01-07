import CategoryIcon from '@mui/icons-material/Category';
import SupervisedUserCircleIcon from '@mui/icons-material/SupervisedUserCircle';
import AttachMoneyIcon from '@mui/icons-material/AttachMoney';
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart';
import { CardDashboard, CardDashboardProps } from '../card-dashboard/CardDasboard';

const cards: CardDashboardProps[] = [
    {
        title: "Productos",
        value: '124',
        description: <p>Total productos</p>,
        icon: <CategoryIcon className='text-green-500'/>,
        path: ""
    },
    {
        title: "Cantidad de Ventas",
        value: '320',
        description: <p>Total de ventas realizadas</p>,
        icon: <AddShoppingCartIcon className='text-green-500'/>,
        path: ""
    },
    {
        title: "Ganancias",
        value: '$1,250.00',
        description: <p>Total de ganancias</p>,
        icon: <AttachMoneyIcon className='text-green-500'/>,
        path: ""
    },
    {
        title: "Cantidad de Usuarios",
        value: '1800',
        description: <p>Total de usuarios registrados</p>,
        icon: <SupervisedUserCircleIcon className='text-green-500'/>,
        path: ""
    }
];

export function Header() {
    return (
        <div className="flex justify-evenly flex-wrap xl:grid xl:grid-cols-4 gap-4 w-full">
            {cards.map((card, index) => (
                <CardDashboard key={index} {...card} />
            ))}
        </div>
    );
}
