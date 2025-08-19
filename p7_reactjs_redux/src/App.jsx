import React from 'react'

import { handleGetOrder, handlProduct, handlUser } from './redux/Actions'

import { useDispatch, useSelector } from 'react-redux'

const App = () => {

    const  dispatch = useDispatch()


   const productState = useSelector((state) => state.product)
   const userState = useSelector((state) => state.user)
   const orderState = useSelector((state) => state.order)





    return (
        <div>

            <h1> React with CRA and Redux</h1>




            <h1> The Product we are buying today is {productState.productName}</h1>
            <h3> The Buyer of the product is {userState.username}</h3>
            <h3> The orderId is {orderState.orderId}</h3>




            <button onClick={() => {
                console.log("button Clicked")
                dispatch(handlUser())
            }} >   SIMULATE USER API CALL </button>




            <button onClick={()=>{
                dispatch(handlProduct())
            }}> 
                SIMULATE PRODUCT API CALL
            </button>



            <button onClick={()=>{
               dispatch(handleGetOrder())     
            }}>
                SIMULATE ORDER API CALL
            </button>


        </div>
    )
}

export default App