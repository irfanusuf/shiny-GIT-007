import { configureStore } from "@reduxjs/toolkit";
import { orderReducer, productReducer, userReducer } from "./Reducers";



const store = configureStore({

    reducer : {
        user : userReducer,
        product : productReducer,
        order : orderReducer
    }
})


export default store