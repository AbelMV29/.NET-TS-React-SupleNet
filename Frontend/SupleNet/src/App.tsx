import { GlobalAuthContextProvider } from "./context/user-context";
import { Router } from "./Router";

function App() {

  return (
    <GlobalAuthContextProvider>
      <Router></Router>
    </GlobalAuthContextProvider>  
  );
}

export default App
