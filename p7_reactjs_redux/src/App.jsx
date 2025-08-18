import React from 'react'
import { handlProduct, handlUser } from './redux/Actions'
import { useDispatch } from 'react-redux'

const App = () => {

    const dispatch = useDispatch()



    return (
        <div>




            <h1> React with CRA and Redux</h1>



            <button onClick={() => {
                console.log("button Clicked")
                dispatch(handlUser())
            }} >   SIMULATE USER API CALL </button>




            <button onClick={()=>{
                dispatch(handlProduct())
            }}> 
                SIMULATE PRODUCT API CALL
            </button>
        </div>
    )
}

export default App