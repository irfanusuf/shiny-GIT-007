import { useEffect, useState } from 'react'
import loadingGif from "../assets/loading.gif"
import HeroSection from '../components/molecules/HeroSection'
import { useDispatch } from '../context/Store'




const Home = () => {



    const {state } = useDispatch()   // store 

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

        <div className={ state.darkMode ? "home-dark home"  : "home-light home"} >
            {
                loading ?
                    <div className='loading_container'>
                        <img src={loadingGif} alt='loading.....' />
                    </div>
                    :
                    <div className='test'>
                        <h1> Welcome from the app {state.user.username} </h1>
                        <h2> This is function based component  </h2>
                        <h2> This is the counter </h2>
                        <h2> {count} </h2>
                        <div>
                            <button onClick={handleDecrement}> decrement  </button>
                            <button onClick={handleIncrement}> increment  </button>
                        </div>
                        <HeroSection/>
                    </div>
            }
        </div>

    )

}

export default Home