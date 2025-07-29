import React, { useEffect, useState } from "react";
import loadingGif from "./assets/loading.gif";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Navbar from "./components/shared/Navbar";
import Footer from "./components/shared/Footer";
import Home from "./pages/Home";

import Account from "./pages/Account";
import About from "./pages/About";
import { ToastContainer } from "react-toastify";
import { linkArr } from "./data/data";
import PageNotFound from "./pages/PageNotFound";
import Gallery from "./pages/Gallery";
import News from "./pages/News";

// funtion based  component

const App = () => {


  const username = "Tajamul"
  const email = "email@gmail.com"

  const [darkmode, setDarkMode] = useState(false)


  return (
    <>

      <ToastContainer />

      <BrowserRouter>
        <Navbar darkmode={darkmode} setDarkMode={setDarkMode} />


        <Routes>

          <Route path="*" element={<PageNotFound />} />

          {/* {linkArr.map((element) => (
            <Route
              key={element.address}
              path={element.address}
              element={React.createElement(element.name, { darkmode, setDarkMode })}
            />
          ))} */}


          <Route path="/" element={<Home />} />

          <Route path="/about" element={<About />} />
          <Route path="/gallery" element={<Gallery />} />
          <Route path="/news" element={<News />} />
          <Route path="/user/account" element={<Account darkmode={darkmode} setDarkMode={setDarkMode} />} /> 

        </Routes>


        <Footer />
      </BrowserRouter>
    </>
  );
};

export default App;
