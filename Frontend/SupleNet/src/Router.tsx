import { BrowserRouter, Route, Routes } from "react-router";
import { Navbar } from "./components/navbar/Navbar";
import { HomePage } from "./pages/home/HomePage";
import { NotFoundPage } from "./pages/not-found/NotFoundPage";

export function Router()
{
    return(
        <BrowserRouter>
            <Routes>
                <Route element={<Navbar></Navbar>}>
                    <Route path="/" element={<HomePage></HomePage>}></Route>
                    <Route path="*" element={<NotFoundPage></NotFoundPage>}></Route>
                </Route>
            </Routes>
        </BrowserRouter>
    );
}