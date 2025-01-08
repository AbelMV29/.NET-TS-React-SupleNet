export interface Result<T>
{
    isSuccess: boolean,
    message : string | null,
    data: T,
    httpStatusCode: number
}