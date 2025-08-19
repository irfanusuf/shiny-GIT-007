

export const handlUser = () => (action) => {
    try {
        action({ type: "SET_USER" });
    } catch (error) {
        console.log(error);
    } finally {
        action({ type: "RESET_USER_LOADER" });
    }
};





export const handlProduct = () => (action) => {
    try {
        action({ type: "SET_PRODUCT", productName: "ONION", price: 40, description: "test description " });
    } catch (error) {
        action({ type: "CLEAR_PRODUCT" });

        console.log(error);
    } finally {
        action({ type: "RESET_PRODUCT_LOADER" });
    }
};




//redux thunk 
export const handleGetOrder = () => (action)=>{

try {
    
    action({type : "GET_ORDER" })

} catch (error) {
    console.log(error)
}finally{
    action({type : "RESET_ORDER_LOADER"})
}


}
