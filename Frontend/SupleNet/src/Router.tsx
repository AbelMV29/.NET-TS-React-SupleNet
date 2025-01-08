import { BrowserRouter, Route, Routes } from "react-router";
import { HomePage } from "./pages/public/home/HomePage";
import { NotFoundPage } from "./pages/public/not-found/NotFoundPage";
import { LoginPage } from "./pages/auth/login/LoginPage";
import { LayoutPage } from "./pages/layout/LayoutPage";
import { RegisterPage } from "./pages/auth/register/RegisterPage";
import { AuthGuard, WithOutGuard } from "./guards/AuthGuard";
import { HomeAdminPage } from "./pages/private/admin/home-admin/HomeAdminPage";
import { LayOutAdminPage } from "./pages/private/admin/layout-admin/LayoutAdminPage";
import { ProductsPage } from "./pages/public/products/ProductsPage";

export function Router()
{
    return(
        <BrowserRouter>
            <Routes>
                <Route element={<LayoutPage></LayoutPage>}>

                    <Route path="/" element={<HomePage></HomePage>}></Route>
                    <Route path="*" element={<NotFoundPage></NotFoundPage>}></Route>
                    <Route path="products" element={<ProductsPage></ProductsPage>}></Route>
                    <Route element={<WithOutGuard></WithOutGuard>}>
                        <Route path="login" element={<LoginPage></LoginPage>}></Route>
                        <Route path="register" element={<RegisterPage></RegisterPage>}></Route>
                    </Route>            

                    <Route path="admin" element={(<AuthGuard role={"Admin"}></AuthGuard>)}>
                        <Route element={(<LayOutAdminPage/>)}>
                            <Route path="" element={<HomeAdminPage></HomeAdminPage>}></Route>
                        </Route>
                    </Route>
                </Route>
            </Routes>
        </BrowserRouter>
    );
}