import { createReducer } from "@reduxjs/toolkit";

const userIntialState = {
    username: "",
    email: "",
    loading: false,
};



const productIntialState = {
    loading: false,
    productName: "",
    price: "",
    description: "",
};



const orderIntialState ={
    loading : false,
    orderId : "",
    addressId : "",
    orderValue : 0
}


export const userReducer = createReducer(userIntialState, (builder) => {
    builder.addCase("SET_USER", (state, action) => {
        state.loading = true;
        state.username = "irfan ";
        state.email = "irfanusuf33@gmail.com";
    });

    builder.addCase("RESET_USER_LOADER", (state, action) => {
        state.loading = false
    })

});



export const productReducer = createReducer(productIntialState, (builder) => {
    builder.addCase("SET_PRODUCT", (state, action) => {
        state.loading = true;
        state.productName = action.productName;
        state.price = action.price;
        state.description = action.description;
    });




    builder.addCase("CLEAR_PRODUCT", (state, action) => {
        state.productName = "";
        state.price = "";
        state.description = "";
    })



    builder.addCase("RESET_PRODUCT_LOADER", (state, action) => {
        state.loading = false
    })




});



export const orderReducer =  createReducer(orderIntialState  , (builder)=>{

    builder.addCase("GET_ORDER" , (state , action)=>{
        state.loading = true
        
        state.orderId = "kjasdhjssiuyqweiodcxhkchasidgasidu"
    })


    builder.addCase("RESET_ORDER_LOADER" , (state , action)=>{
        state.loading = false
    
    })
})