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
        )
    }
);

export type LoginFormType = z.infer<typeof schema>;