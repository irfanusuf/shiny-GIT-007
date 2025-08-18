import { configureStore } from "@reduxjs/toolkit";
import { productReducer, userReducer } from "./Reducers";



const store = configureStore({

    reducer : {
        user : userReducer,
        product : productReducer
    }
})



export default store