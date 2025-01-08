interface ResultSearchItemProps
{
    name: string,
    price?: number,
    image?:string
}

export function ResultSearchItem({name, image}: ResultSearchItemProps)
{
    return(
    <div className="flex flex-row gap-2">
        <img src={image} className="w-5"/>
        <p>{name}</p>
    </div>
    );
}