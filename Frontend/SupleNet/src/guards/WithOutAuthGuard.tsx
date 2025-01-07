import { useEffect } from "react";
import { useNavigate, Outlet } from "react-router";
import { useAuthContext } from "../context/user-context";

export function WithOutAuthGuard()
{
    const {value} = useAuthContext();

    const navigate = useNavigate();
    useEffect(()=>
    {
        if(value?.["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] === 'Customer')
            navigate("/");
        else if(value?.["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] === 'Admin')
            navigate("admin")
    })

    if(value)
        return null;
    return (<Outlet></Outlet>);
}