import React, { useEffect, useState } from "react";
import loadingGif from "./assets/loading.gif";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Navbar from "./components/shared/Navbar";
import Footer from "./components/shared/Footer";
import Home from "./pages/Home";

import Account from "./pages/Account";
import About from "./pages/About";
import { ToastContainer } from "react-toastify";

// funtion based  component

const App = () => {


 const username  = "Tajamul"
 const email = "email@gmail.com"

    const [darkmode , setDarkMode] = useState(false)


  return (
    <>

      <ToastContainer/>

      <BrowserRouter>
        <Navbar  darkmode ={darkmode} setDarkMode={setDarkMode} />

  
          <Routes>
            <Route path="/" element={<Home darkmode ={darkmode} setDarkMode={setDarkMode}/>} />



            <Route path="/about" element={<About />} />
    
            <Route path="/user/account" element={<Account darkmode ={darkmode} setDarkMode={setDarkMode} />} />
         
          </Routes>
      

        <Footer />
      </BrowserRouter>
    </>
  );
};

export default App;
