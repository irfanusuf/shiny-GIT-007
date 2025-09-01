import { configureStore } from "@reduxjs/toolkit";
import { orderReducer, productReducer, userReducer } from "./Reducers";
import userSlice, { getProducts } from "./slices/userSlice";



const store = configureStore({

    reducer : {
        user : userReducer,
        product : productReducer,
        order : orderReducer,
        userSlice : userSlice.reducer,
        productsApi : getProducts.reducer
    }
})


export default store