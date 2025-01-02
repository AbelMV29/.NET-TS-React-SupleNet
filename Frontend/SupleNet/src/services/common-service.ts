import { Result } from "../models/common";
import axios from 'axios';

export const supleNetInstanceAxios = axios.create({
    baseURL: import.meta.env.VITE_API_BASE,
});

supleNetInstanceAxios.interceptors.request.use((request)=>
    {
        const token = localStorage.getItem("token");
        if(token)
            request.headers.Authorization = `Bearer ${token}`;
    
        return request;
    }, (error) => {
        return Promise.reject(error);
    });

export async function GetByNameOrder<T>(url:string, controller: AbortController) : Promise<Result<T[]>>
{
    return supleNetInstanceAxios.get<Result<T[]>>(url, {signal: controller.signal})
    .then(response=>
    {
        return response.data;
    }
    );
}