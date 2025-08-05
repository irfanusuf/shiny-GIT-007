import { createContext, useReducer } from "react";
import axios from "axios";
import { toast } from "react-toastify";
import App from "../App";



export const Context = createContext();

export const Store = () => {


  const initialState = {
    user: {},
    darkMode: false,
    loading: false,
    pics: [],
    orders: [],
    products: [],
    address: {}
  }


  function reducer(state, action) {

    switch (action.type) {

      case "TOGGLE_DARK_MODE":
        return { ...state, darkMode: !state.darkMode };

      case "SET_LOADING":
        return { ...state, loading: action.payload };

      case "SET_PICS":
        return { ...state, pics: action.payload };

      case "SET_USER":
        return { ...state, user: action.payload };

      case "SET_ORDERS":
        return { ...state, orders: action.payload };

      case "SET_PRODUCTS":
        return { ...state, products: action.payload };

      case "SET_ADDRESS":
        return { ...state, address: action.payload };

      default:
        return state;
    }
  }


  const [state, dispatch] = useReducer(reducer, initialState);


  const setDarkMode = () => {
    dispatch({ type: "TOGGLE_DARK_MODE" })

  };

  const fetchPics = async (page) => {
    try {

      dispatch({ type: "SET_LOADING", payload: true })
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

        dispatch({ type: "SET_LOADING", payload: false })
        dispatch({ type: "SET_PICS", payload: res.data.photos })
      }
    } catch (error) {

      console.error(error);
      toast.error("Network Error!")
    }
  };

  const loginHandler = async (formBody) => {
    try {
      dispatch({ type: "SET_LOADING", payload: true })

      const res = await axios.post(
        "http://localhost:5294/api/User/login",
        formBody
      );

      if (res.status === 200) {
        dispatch({ type: "SET_LOADING", payload: false })

        dispatch({ type: "SET_USER", payload: res.data.payload })
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
        ...state,
        setDarkMode, fetchPics, loginHandler
      }}
    >
      <App/>
    </Context.Provider>
  );
};











