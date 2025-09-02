import { configureStore } from "@reduxjs/toolkit";
import { orderReducer, productReducer, userReducer } from "./Reducers";
import userSlice from "./slices/userSlice";
import { pokemonApi } from "./api/pokemonApi";



const store = configureStore({

    reducer: {
        user: userReducer,
        product: productReducer,
        order: orderReducer,

        userSlice: userSlice.reducer,
        pokemonApi: pokemonApi.reducer
    },


    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware().concat(pokemonApi.middleware),



})


export default store