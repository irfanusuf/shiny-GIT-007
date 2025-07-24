import React, { useEffect, useState } from 'react'
import loadingGif from "../assets/loading.gif"

const Home = ({darkmode , setDarkMode}) => {
    const [count, setCount] = useState(0)
    const [loading, setLoading] = useState(true)


    useEffect(() => {

        setTimeout(() => {
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

        <div className={ darkmode ? "home-dark home"  : "home-light home"} >
            {
                loading ?
                    <div>
                        <img src={loadingGif} alt='loading.....' />
                    </div>
                    :
                    <div>
                        <h1>  Welcome from the app </h1>
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

export default Home