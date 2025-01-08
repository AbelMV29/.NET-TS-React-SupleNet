import { GlobalShoppingCartContextProvider } from "./context/shopping-cart-context";
import { GlobalAuthContextProvider } from "./context/user-context";
import { Router } from "./Router";

function App() {

  return (
    <GlobalAuthContextProvider>
      <GlobalShoppingCartContextProvider>
        <Router></Router>
      </GlobalShoppingCartContextProvider>
    </GlobalAuthContextProvider>  
  );
}

export default App
