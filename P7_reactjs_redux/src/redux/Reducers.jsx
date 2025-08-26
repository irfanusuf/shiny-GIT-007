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
    builder.addCase("REQ_USER_API" , (state , action) =>{
        state.loading = true
    })

    builder.addCase("SET_USER", (state, action) => {
        state.loading = false
        state.username =  action.username
        state.email = action.email
    });

    builder.addCase("USER_API_FAILURE", (state, action) => {
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