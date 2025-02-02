import { useForm } from "react-hook-form";
import { LoginFormType, schema } from "../../models/login-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { LoginService } from "../../../../../services/auth-service";
import { Button } from "../../../../../components/button/Button";
import { Link } from "react-router";
import { useState } from "react";
import VisibilityIcon from '@mui/icons-material/Visibility';
import VisibilityOffIcon from '@mui/icons-material/VisibilityOff';
import { FormInput } from "../../../../../components/form-input/FormInput";
import { useAuthContext } from "../../../../../context/user-context";
import { toastAlert } from "../../../../../utils/util";

export function LoginForm() {
  const { control, handleSubmit, formState: { errors } } = useForm<LoginFormType>({
    resolver: zodResolver(schema),
    defaultValues:
    {
      email: "",
      password: ""
    }
  });
  const [showpwd, setShowpwd] = useState(false);
  const {setValue} = useAuthContext();

  function signIn(data: LoginFormType) {
    const controller: AbortController = new AbortController();
    const fetchSignIn = async () => {
      try {
        const result = await LoginService(data, controller);
        setValue(result.data);
        toastAlert('success', result.message ?? '');
      } catch (err) {
        const error = err as Error;
        toastAlert('error', error.message);
      }
    }
    fetchSignIn();

    return (() => {
      controller.abort();
    });
  }

  return (
    <form className="flex flex-col w-[400px] px-2 min-w-[280px] items-center mt-5 gap-3" onSubmit={handleSubmit(signIn)}>
      <h1 className="font-bold text-2xl">Ingresar</h1>
      <FormInput label="Correo electrónico" control={control} errorMessage={errors.email?.message} name="email"
        placeholder="example@mail.com" type="text" relative={false}>
      </FormInput>
      <FormInput label="Contraseña" control={control} errorMessage={errors.password?.message} name="password"
        placeholder="********" type={showpwd ? 'text' : 'password'} relative={true}>
        <button className="absolute right-0 top-9 pr-3"
          type="button"
          onClick={() => { setShowpwd(!showpwd) }}>
          {showpwd ? <VisibilityIcon /> : <VisibilityOffIcon />}
        </button>
      </FormInput>
      <p className="text-slate-500">¿Usuario nuevo? <Link to={"/register"} className="text-violet-700 underline">Registrate</Link></p>
      <Button text="Iniciar sesión" action={() => { }} type="submit"></Button>
    </form>
  );
}