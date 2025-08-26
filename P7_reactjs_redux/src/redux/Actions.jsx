import { toast } from "react-toastify";
import { axiosInstance } from "../utils/axiosInstance";


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










// export const registerHandler = (formBody) => async (action)=>{

//     try {
//         action({type : "REQ_USER_API"})

//         const res = await axiosInstance.post("/user/register" , formBody)
//         if(res.status === 200){
//             toast.success(res.data.message)
//             action({type :"SET_USER" ,  username : formBody.username , email : formBody.email })
//         }
//     } catch (error) {


//         action({type : "USER_API_FAILURE"})
//         console.error(error)
//         if(error.status){
//             toast.error(error.response.data.message)
//         }
  
//     }

// }







export const loginHandler = (formBody) => async (action)=>{




}