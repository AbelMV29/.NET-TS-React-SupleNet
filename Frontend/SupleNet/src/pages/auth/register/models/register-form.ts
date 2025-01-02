import { z } from "zod";

export const schema = z.object(
    {
        email: z.string().email("El correo electrónico tiene un formato invalido"),
        password:z.string()
        .min(6, "La contraseña debe tener minimo 6 caracteres")
        .max(15, "La contraseña debe tener minimo 15 caracteres")
        .regex(
            /^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).{6,15}$/,
            "La contraseña debe tener entre 6 y 15 caracteres, incluir al menos una letra mayúscula, una letra minúscula, un número y un carácter especial."
        ),
        confirmPassword: z.string(),
        name: z.string().nonempty("El nombre es obligatorio"),
        lastName: z.string().nonempty("El apellido es obligatorio"),
        phoneNumber: z.string().regex(
            /^\+54 \d{1,2} \d{1,4} \d{8}$/,
            `El número de teléfono debe comenzar con +54, seguido de 1 o 2 dígitos, luego 1 a 4 dígitos, y finalmente 8 dígitos.
            Ejemplo: +54 9 11 12345678`
          )
    }
).refine(schema=>schema.password === schema.confirmPassword,
    {
        message:"Las contraseñas deben coincidir",
        path:['confirmPassword']
    }
);

export type RegisterFormType = z.infer<typeof schema>;