import { Role, useAuthContext, UserAuthContext } from "../context/user-context";
import { LoginResponse } from "../models/auth";
import { Result } from "../models/common";
import { LoginFormType } from "../pages/auth/login/models/login-form";
import { RegisterFormType } from "../pages/auth/register/models/register-form";
import { supleNetInstanceAxios } from "./common-service";


export async function LoginService(loginModel: LoginFormType, controller: AbortController): Promise<Result<UserAuthContext>> {

    return supleNetInstanceAxios
        .post<Result<LoginResponse>>("/auth/login", loginModel, { signal: controller.signal })
        .then((response) => {
            const userLogged: UserAuthContext = ResolveToken(response.data.data.token);
            localStorage.setItem("token", response.data.data.token);

            return {
                data: userLogged,
                isSuccess: response.data.isSuccess,
                message: response.data.message,
                httpStatusCode: response.data.httpStatusCode,
            };
        })
        .catch((error) => {
            console.log(error);
            throw new Error(error.response.data ?? "Ocurrió un error inesperado");
        });
}

export async function RegisterService(registerModel: RegisterFormType, controller: AbortController): Promise<Result<object>> {
    return supleNetInstanceAxios
        .post<Result<object>>("/auth/register", registerModel, { signal: controller.signal })
        .then((response) => {
            return {
                data: response.data.data,
                isSuccess: response.data.isSuccess,
                message: response.data.message,
                httpStatusCode: response.data.httpStatusCode,
            };
        })
        .catch((error) => {
            console.error(error);
            throw new Error(error.response?.data?.message || "Ocurrió un error inesperado");
        });
}


export function ResolveToken(token: string): UserAuthContext {
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
}

export function GetRole(): Role {
    const { value } = useAuthContext();
    const role = value?.["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] as Role | undefined;

    return !role ? null : role;
}