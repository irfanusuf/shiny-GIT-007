import { createRoot } from "react-dom/client";
import "./global.scss";
import { BrowserRouter } from "react-router-dom";
import { Store } from "./Store";

createRoot(document.getElementById("root")).render(
  <BrowserRouter>
    <Store/> 
  </BrowserRouter>
);
