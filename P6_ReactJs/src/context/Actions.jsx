import axios from "axios";
import { toast } from "react-toastify";
import { axiosInstance } from "../utils/axiosInstance";

// actions
export const setDarkMode = (dispatch) => {
  dispatch({ type: "TOGGLE_DARK_MODE" });
};

export const fetchPics = async (page, dispatch) => {
  try {
    dispatch({ type: "SET_LOADING", payload: true });

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
      dispatch({ type: "SET_LOADING", payload: false });
      dispatch({ type: "SET_PICS", payload: res.data.photos });
    }
  } catch (error) {
    console.error(error);
    toast.error("Network Error!");
  }
};

export const loginHandler = async (formBody, dispatch) => {
  try {
    dispatch({ type: "SET_LOADING", payload: true });

    const res = await axios.post(
      "http://localhost:5294/api/User/login",
      formBody
    );

    if (res.status === 200) {
      dispatch({ type: "SET_LOADING", payload: false });
      // dispatch({ type: "SET_USER", payload: res.data.payload })  // payload persistance is only for time if the app is not reloaded ....

      localStorage.setItem("Authorization_Token", res.data.payload); // 5mb
      // sessionStorage     // 5mb    // data persist for the time when the browser is open
      toast.success(res.data.message);
      return true;
    }
  } catch (error) {
    if (error.status) {
      toast.error(error.response.data.message);
    } else {
      toast.error("Network Error");
    }

    dispatch({ type: "SET_LOADING", payload: false });
    console.error(error);
    return false;
  }
};

export const registerHandler = async (formBody, dispatch) => {
  try {
    dispatch({ type: "SET_LOADING", payload: true });
    const res = await axios.post(
      "http://localhost:5294/api/User/Register",
      formBody
    );

    if (res.status === 200) {
      dispatch({ type: "SET_LOADING", payload: false });
      toast.success(res.data.message);
    }
  } catch (error) {
    toast.error("Network Error");
    dispatch({ type: "SET_LOADING", payload: false });
    console.error(error);
  }
};


export const verifyUser = async (token , dispatch) =>{
try {
  const res = await axiosInstance.get(`/user/verify?token=${token}`)
  if(res.status === 200){
    dispatch({type : "SET_USER" , payload : res.data.payload})
    return true
  }else{
    return false
  }
  

} catch (error) {
  console.error(error)
  return false
}



}