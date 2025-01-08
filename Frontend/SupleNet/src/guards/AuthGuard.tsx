import { Outlet, useNavigate } from "react-router";
import { Role, useAuthContext } from "../context/user-context";
import { useEffect } from "react";

export function AuthGuard({role}: {role: Role})
{
    const {value} = useAuthContext();

    const navigate = useNavigate();

    useEffect(()=>
    {
        if(!value)
        {
            navigate("login");
            return;
        }
        if(value["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] !== role)
        {
            navigate("*");
            return;
        }
    }, [value, navigate, role])

    if(!value || value["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] !== role)
        return null;

    return (<Outlet></Outlet>);
}

export function WithOutGuard()
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