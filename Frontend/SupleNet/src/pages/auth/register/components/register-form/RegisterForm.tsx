import { useForm } from "react-hook-form";
import { RegisterFormType, schema } from "../../models/register-form";
import VisibilityIcon from '@mui/icons-material/Visibility';
import VisibilityOffIcon from '@mui/icons-material/VisibilityOff';
import { zodResolver } from "@hookform/resolvers/zod";
import { FormInput } from "../../../../../components/form-input/FormInput";
import { useState } from "react";
import { Button } from "../../../../../components/button/Button";
import { Link, useNavigate } from "react-router";
import { RegisterService } from "../../../../../services/auth-service";
import { toast } from "sonner";

export function RegisterForm() {
  const { control, handleSubmit, formState: { errors } } = useForm<RegisterFormType>({
    resolver: zodResolver(schema),
    defaultValues:
    {
      email: "",
      password: "",
      confirmPassword: "",
      lastName: "",
      name: "",
      phoneNumber: ""
    }
  });
  const [showpwd, setShowpwd] = useState(false);
  const [showConfirmpwd, setShowConfirmpwd] = useState(false);
  const navigate = useNavigate();

  function signUp(data: RegisterFormType) {
    const controller: AbortController = new AbortController();

    const fetchSignUp = async () => {
      try {
        const result = await RegisterService(data, controller);
        toast.success(result.message, { duration: 3000, className: "bg-violet-700 text-white font-bold" });
        navigate('/login');
      } catch (err) {
        const error = err as Error;
        toast.error(error.message, { duration: 3000, className: "bg-red-500 text-white font-bold" });
      }
    }
    fetchSignUp();

    return (() => {
      controller.abort();
    });
  }

  return (
    <form className="flex flex-col w-[410px] px-2 min-w-[280px] items-center mt-5 gap-3" onSubmit={handleSubmit(signUp)}>
      <h1 className="font-bold text-2xl">Registro</h1>
      <div className="flex lg:flex-row flex-col gap-2 w-full">
        <FormInput label="Nombre/s" control={control} errorMessage={errors.name?.message} name="name"
          placeholder="Nombre" type="text" relative={false}></FormInput>

        <FormInput label="Apellido/s" control={control} errorMessage={errors.lastName?.message} name="lastName"
          placeholder="Apellido" type="text" relative={false}></FormInput>
      </div>

      <FormInput label="Correo electrónico" control={control} errorMessage={errors.email?.message} name="email"
        placeholder="example@mail.com" type="text" relative={false}>
      </FormInput>

      <div className="flex lg:flex-row flex-col gap-2 w-full">
        <FormInput label="Contraseña" control={control} errorMessage={errors.password?.message} name="password"
          placeholder="********" type={showpwd ? 'text' : 'password'} relative={true}>
          <button className="absolute right-0 top-9 pr-3"
            type="button"
            onClick={() => { setShowpwd(!showpwd) }}>
            {showpwd ? <VisibilityIcon /> : <VisibilityOffIcon />}
          </button>
        </FormInput>

        <FormInput label="Confirmar contraseña" control={control} errorMessage={errors.confirmPassword?.message} name="confirmPassword"
          placeholder="********" type={showConfirmpwd ? 'text' : 'password'} relative={true}>
          <button className="absolute right-0 top-9 pr-3"
            type="button"
            onClick={() => { setShowConfirmpwd(!showConfirmpwd) }}>
            {showConfirmpwd ? <VisibilityIcon /> : <VisibilityOffIcon />}
          </button>
        </FormInput>
      </div>

      <FormInput label="Télefono" control={control} errorMessage={errors.phoneNumber?.message} name="phoneNumber"
        placeholder="+54 9 11 12345678" type="text" relative={true}>
      </FormInput>

      <p className="text-slate-500">¿Ya tienes una cuenta? <Link to={"/login"} className="text-violet-700 underline">Inicia sesión</Link></p>
      <Button text="Registrarse" action={() => { }} type="submit"></Button>
    </form>
  );
}