import { configureStore } from "@reduxjs/toolkit";
import { orderReducer, productReducer, userReducer } from "./Reducers";
import userSlice from "./slices/userSlice";
import { pokemonApi } from "./api/pokemonApi";
import { placeHolderApi } from "./api/jsonPlaceHolderApi";



const store = configureStore({

    reducer: {
        user: userReducer,
        product: productReducer,
        order: orderReducer,

        userSlice: userSlice.reducer,
        pokemonApi: pokemonApi.reducer,
        placeHolderApi : placeHolderApi.reducer
    },


    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware().concat(pokemonApi.middleware).concat(placeHolderApi.middleware),



})


export default store