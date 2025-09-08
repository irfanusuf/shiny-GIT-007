
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Home from './pages/Home'
import Navbar from './components/shared/Navbar'
import Account from './pages/Account'
import { ToastContainer } from 'react-toastify'
import Pokemon from './pages/Pokemon'
import Placeholder from './pages/Placeholder'
import PlaceHolderPhotos from './pages/PlaceHolderPhotos'
import UserDetails from './pages/UserDetails'



const App = () => {


    return (
        <BrowserRouter>
        <ToastContainer/>
        <Navbar/>
            <Routes>
                <Route path='/' element={<Home />} />
                <Route path='/user/account' element={<Account />} />
                <Route path='/user/dashboard' element={<Home />} />

                <Route path='/user/:userId' element = {<UserDetails/>} />



                <Route path='/pokemon' element ={<Pokemon/>} />
                <Route path='/placeholder-posts' element={<Placeholder/>} />
                <Route path='/placeholder-photos' element={<PlaceHolderPhotos/>} />


            </Routes>
        </BrowserRouter>
    )
}

export default App