import { BrowserRouter, Route, Routes } from "react-router";
import { HomePage } from "./pages/public/home/HomePage";
import { NotFoundPage } from "./pages/public/not-found/NotFoundPage";
import { LoginPage } from "./pages/auth/login/LoginPage";
import { LayoutPage } from "./pages/layout/LayoutPage";
import { RegisterPage } from "./pages/auth/register/RegisterPage";
import { HomeAdminPage } from "./pages/private/admin/home-admin/HomeAdminPage";
import { AuthGuard } from "./guards/AuthGuard";
import { WithOutAuthGuard } from "./guards/WithOutAuthGuard";
import { ProductsPage } from "./pages/public/products/ProductsPage";
import { CartPage } from "./pages/private/customer/cart/CartPage";

export function Router()
{
    return(
        <BrowserRouter>
            <Routes>
                <Route element={<LayoutPage></LayoutPage>}>

                    <Route path="/" element={<HomePage/>}></Route>
                    <Route path="*" element={<NotFoundPage/>}></Route>
                    <Route path="products" element={<ProductsPage/>}></Route>
                    <Route element={<WithOutAuthGuard/>}>
                        <Route path="login" element={<LoginPage/>}></Route>
                        <Route path="register" element={<RegisterPage/>}></Route>
                    </Route>            
                    <Route path="customer" element={(<AuthGuard role={"Customer"}></AuthGuard>)}>
                        <Route path="cart" element={(<CartPage></CartPage>)}></Route>
                    </Route>
                    <Route path="admin" element={(<AuthGuard role={"Admin"}></AuthGuard>)}>
                        <Route path="" element={<HomeAdminPage/>}></Route>
                    </Route>
                </Route>
            </Routes>
        </BrowserRouter>
    );
}