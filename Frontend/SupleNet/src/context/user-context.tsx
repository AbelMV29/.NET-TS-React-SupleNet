import { createContext, ReactNode, useContext, useState } from "react";
import { ResolveToken } from "../services/auth-service";

interface UserAuthContextType{
    value: UserAuthContext | null,
    setValue: React.Dispatch<React.SetStateAction<UserAuthContext | null>>
}

export interface UserAuthContext {
    "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier" : string,
    name: string,
    lastName: string,
    email: string,
    "http://schemas.microsoft.com/ws/2008/06/identity/claims/role": Role,
    exp: number,
    iss: string
}

export type Role = 'Customer' | 'Admin' | null;

export const AuthContext = createContext<UserAuthContextType>({setValue: ()=>{}, value:null})

export function useAuthContext() : UserAuthContextType{
    const context = useContext(AuthContext);

    return context;
}

export function GlobalAuthContextProvider({children}: {children : ReactNode})
{
    const [value, setValue] = useState<UserAuthContext | null>(localStorage.getItem("token")? ResolveToken(localStorage.getItem("token")!) : null);

    return (
        <AuthContext.Provider value={{value, setValue}}>{children}</AuthContext.Provider>
    );
}