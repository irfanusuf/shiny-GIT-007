import { createRoot } from "react-dom/client";
import "./global.scss";
import { BrowserRouter } from "react-router-dom";
import { Store } from "./context/Store";
import App from "./App";

createRoot(document.getElementById("root")).render(
  <BrowserRouter>
    <Store>

      <App />

    </Store>

  </BrowserRouter>
);
