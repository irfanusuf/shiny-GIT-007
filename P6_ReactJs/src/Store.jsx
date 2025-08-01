import React, { createContext, useState } from "react";
import App from "./App";

export const Context = createContext();

export const Store = () => {
  const [store, setStore] = useState({
    username: "Tehleem",
    email: "example@gmail.com",
    darkMode: false,
  });

  const setDarkMode = () => {
    setStore((prev) => ({ ...prev, darkMode: !store.darkMode }));
  };

  return (
    <Context.Provider value={{ ...store, setDarkMode }}>
      <App />
    </Context.Provider>
  );
};
