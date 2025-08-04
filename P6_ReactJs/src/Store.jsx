import  { createContext, useState } from "react";
import App from "./App";
import axios from "axios";
import { toast } from "react-toastify";

export const Context = createContext();

export const Store = () => {
  const [store, setStore] = useState({
    username: "Tehleem",
    email: "example@gmail.com",
    darkMode: false,
    loading: false,
    pics: [],
  });

  const setDarkMode = () => {
    setStore((prev) => ({ ...prev, darkMode: !store.darkMode }));
  };

  const fetchPics = async (page) => {
    try {
      const res = await axios.get("https://api.pexels.com/v1/curated", {
        headers: {
          Authorization:
            "A18L6UPAOtZeFZ4vLDzj2fO4wTeto2iIb2aqtyo2EA3agRXRdEN6YFRV",
        },
        params: {
          per_page: 80,
          page: page,
        },
      });

      if (res.status === 200) {
        setStore((prev) => ({ ...prev, pics: res.data.photos }));

        console.log(res.data);
      }
    } catch (error) {
      console.error(error);
    }
  };

  const loginHandler = async (formBody) => {
    try {
      setStore ((prev) => ({...prev , loading :true}))
      const res = await axios.post(
        "http://localhost:5294/api/User/login",
        formBody
      );

      if (res.status === 200) {
        setStore ((prev) => ({...prev , loading :false}))
        toast.success(res.data.message);
      }
    } catch (error) {
      toast.error("Network Error");
      console.error(error);
    }
  };

  return (
    <Context.Provider
      value={{
        ...store,
        setDarkMode, fetchPics, loginHandler
      }}
    >
      <App />
    </Context.Provider>
  );
};
