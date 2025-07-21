import React, { useEffect, useState } from 'react'
import loadingGif from "./assets/loading.gif"



// funtion based  component 

const App = () => {
    const [count, setCount] = useState(0)
    const [username, setusername] = useState("")
    const [loading, setLoading] = useState(true)


    useEffect(() => {

        setTimeout(() => {
            setusername("Irfan sir")
            setLoading(false)
        }, 3000);

    })

    const handleIncrement = () => {
        setCount(count => count + 1)
    }


    const handleDecrement = () => {
        setCount(count => count - 1)
    }

    return (

        <div className='main'>
            {
                loading ?
                    <div>
                        <img src={loadingGif} alt='loading.....' />
                    </div>
                    :
                    <div>
                        <h1>  Welcome from the app {username}  </h1>
                        <h2>   This is function based component  </h2>
                        <h2> This is the counter </h2>
                        <h2> {count} </h2>
                        <div>
                            <button onClick={handleDecrement}> decrement  </button>
                            <button onClick={handleIncrement}> increment  </button>
                        </div>
                    </div>
            }
        </div>

    )



}





export default App