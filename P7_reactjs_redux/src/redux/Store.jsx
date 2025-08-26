import { configureStore } from "@reduxjs/toolkit";
import { orderReducer, productReducer, userReducer } from "./Reducers";
import userSlice from "./slices/userSlice";



const store = configureStore({

    reducer : {
        user : userReducer,
        product : productReducer,
        order : orderReducer,
        handleUser : userSlice.reducer
    }
})


export default store