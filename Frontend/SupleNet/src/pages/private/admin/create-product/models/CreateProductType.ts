import { z } from "zod";

export const schema = z.object({
    name: z.string().min(3, "El nombre debe tener al menos 3 caracteres").max(85),   
    description: z.string().min(3, "La descripción debe tener al menos 3 caracteres").max(255),
    price: z.number().min(0.01, "El precio debe ser mayor a 0"),
    image: z.instanceof(FileList).refine((files) => files.length > 0, "Debes subir una imagen"),
    brandId: z.string().uuid("Marca invalida"),
    categoryId: z.string().uuid("Categoría invalida"),
    files: z.instanceof(FileList).refine((files) => files.length > 0, "Debes al menos un archivo"),
})

export type CreateProductType = z.infer<typeof schema>;