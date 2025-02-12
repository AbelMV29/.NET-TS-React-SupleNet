import { zodResolver } from "@hookform/resolvers/zod";
import { Controller, useForm } from "react-hook-form";
import { CreateProductType, schema } from "../models/CreateProductType";
import { FormInput } from "../../../../../components/form-input/FormInput";
import { SelectInput } from "../../../../../components/select-input/SelectInput";
import { useFetchNameOrder } from "../../../../../hooks/useFetchNameOrder";
import { Brand } from "../../../../../models/brands";
import { CircularProgress } from "@mui/material";
import { AddProduct } from "../../../../../services/product-service";
import { toastAlert } from "../../../../../utils/util";
import { Button } from "../../../../../components/button/Button";

function onSubmitCreateProduct(data: CreateProductType) {
    console.log(data);
    const controller: AbortController = new AbortController();
    const fetchCreateProduct = async () => {
        try {
            const formData: FormData = new FormData();
            formData.append('name', data.name);
            formData.append('description', data.description);
            formData.append('price', data.price.toString());
            formData.append('image', data.image[0]);
            formData.append('brandId', data.brandId);
            formData.append('categoryId', data.categoryId);
            for (let i = 0; i < data.files.length; i++) {
                formData.append('files', data.files[i]);
            }


            const response = await AddProduct(formData, controller);
            toastAlert("success", response.message!);
        }
        catch (error) {
            const err = error as Error;
            toastAlert("error", err.message);
        }
    }

    fetchCreateProduct();
}


export function CreateProductForm() {
    const { control, handleSubmit, formState: { errors }, setValue, register } = useForm<CreateProductType>(
        {
            resolver: zodResolver(schema),
            defaultValues:
            {
                name: "",
                description: "",
                price: 0,
                brandId: "",
                categoryId: ""
            }
        })
    const { loaded: brandsLoaded, error: brandsError, data: brandsData } = useFetchNameOrder<Brand>('/brands');
    const { loaded: categoriesLoaded, error: categoriesError, data: categoriesData } = useFetchNameOrder<Brand>('/category');
    if (!brandsLoaded || !categoriesLoaded) {
        return <CircularProgress></CircularProgress>
    }

    if (brandsError || categoriesError) {
        return <div>Error: {brandsError || categoriesError}</div>
    }
    
    return (
        <form className="flex flex-col w-[400px] px-2 min-w-[280px] items-center mt-5 gap-3" onSubmit={(handleSubmit(onSubmitCreateProduct))}>
            <h1 className="font-bold text-2xl">Añadir nuevo producto</h1>
            <FormInput
                control={control}
                errorMessage={errors.name?.message}
                name='name'
                label="Nombre"
                placeholder=""
                relative={false}
                type="text"
                key={"name"}></FormInput>
            <Controller
                name="description"
                control={control}
                render={(({ field }) => (
                    <div className="w-full font-semibold gap-1 flex flex-col">
                        <label>Descripción</label>
                        <textarea {...field}
                            rows={3}
                            className="bg-slate-200 p-2 rounded-md outline-none transition-colors duration-500
                    focus:outline focus:outline-2 focus:outline-violet-700 font-semibold w-full resize-none">
                        </textarea>
                    </div>))}>
            </Controller>
            <Controller
                control={control}
                name="price"
                render={(({ field }) => (
                    <div className="w-full font-semibold gap-1 flex flex-col">
                        <label>Descripción</label>
                        <input {...field}
                            onChange={(e) => {
                                const value = parseFloat(e.target.value);
                                console.log(value);
                                setValue("price", isNaN(value) ? 0 : value)
                            }}
                            className="bg-slate-200 p-2 rounded-md outline-none transition-colors duration-500
                    focus:outline focus:outline-2 focus:outline-violet-700 font-semibold w-full resize-none"/>
                    <p className="text-red-600 text-[12px] min-h-[18px]">{errors.price?.message}</p>
                    </div>))}>

            </Controller>
            <SelectInput
                control={control}
                errorMessage={errors.brandId?.message}
                label="Marca"
                name="brandId"
                key={"brandId"}
                data={brandsData}></SelectInput>
            <SelectInput
                control={control}
                errorMessage={errors.categoryId?.message}
                label="Categoría"
                name="categoryId"
                key={"categoriesId"}
                data={categoriesData}></SelectInput>
            <div className="w-full font-semibold gap-1 flex flex-col">
                <label>Image</label>
                <input
                    {...register("image")} accept="image/*"
                    type="file"
                    className="bg-slate-200 p-2 rounded-md outline-none transition-colors duration-500
                    focus:outline focus:outline-2 focus:outline-violet-700 font-semibold w-full resize-none"/>
            </div>
            <div className="w-full font-semibold gap-1 flex flex-col">
                <label>Galería</label>
                <input
                    {...register("files")} accept="image/*, video/*"
                    type="file"
                    multiple
                    className="bg-slate-200 p-2 rounded-md outline-none transition-colors duration-500
                    focus:outline focus:outline-2 focus:outline-violet-700 font-semibold w-full resize-none"/>
            </div>

            <Button text="Crear producto" action={() => { console.log(errors) }} size="medium" type="submit"></Button>
        </form>
    )
}