import React, { useEffect, useState } from "react";
import loadingGif from "./assets/loading.gif";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Navbar from "./components/shared/Navbar";
import Footer from "./components/shared/Footer";
import Home from "./pages/Home";
import Login from "./pages/Login";
import Register from "./pages/Register";
import About from "./pages/About";
import { ToastContainer } from "react-toastify";

// funtion based  component

const App = () => {
  return (
    <>

      <ToastContainer/>

      <BrowserRouter>
        <Navbar />

        <div className="main">
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/about" element={<About />} />
            <Route path="/user/login" element={<Login />} />
            <Route path="/user/register" element={<Register />} />
         
          </Routes>
        </div>

        <Footer />
      </BrowserRouter>
    </>
  );
};

export default App;
