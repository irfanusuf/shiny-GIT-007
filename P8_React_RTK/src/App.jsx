
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Home from './pages/Home'
import Navbar from './components/shared/Navbar'
import Account from './pages/Account'
import { ToastContainer } from 'react-toastify'






const App = () => {


    return (
        <BrowserRouter>
        <ToastContainer/>
        <Navbar/>
            <Routes>
                <Route path='/' element={<Home />} />
                <Route path='/user/account' element={<Account />} />
                <Route path='/user/dashboard' element={<Home />} />

    
            </Routes>
        </BrowserRouter>
    )
}

export default App