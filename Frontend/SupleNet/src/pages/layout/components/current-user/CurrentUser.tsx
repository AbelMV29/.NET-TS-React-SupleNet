import { Button } from "../../../../components/button/Button";
import { useAuthContext } from "../../../../context/user-context";

export function CurrentUser()
{
    function logOut()
    {
        setValue(null);
        localStorage.removeItem("token");
    }

    const {value, setValue} = useAuthContext();
    if(value)
    {
        return (
            <div className="flex gap-2 items-center">
                <p>Hola {value.name} {value.lastName}</p>
                <a onClick={logOut} className="text-red-500 text-sm underline cursor-pointer">Salir</a>
            </div>
        );
    }

    return(
        <Button text="Ingresar" path="login" key={"button-login"}>
        </Button>
    );
}