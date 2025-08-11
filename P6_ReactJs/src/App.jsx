
import { Route, Routes } from "react-router-dom";
import Navbar from "./components/shared/Navbar";
import Footer from "./components/shared/Footer";
import Home from "./pages/Home";
import Account from "./pages/Account";
import About from "./pages/About";
import { ToastContainer } from "react-toastify";
import PageNotFound from "./pages/PageNotFound";
import Gallery from "./pages/Gallery";
import News from "./pages/News";
import Dashboard from "./pages/Dashboard";
import IsAuthorised from "./Auth/IsAuthorised";


// funtion based  component

const App = () => {

  return (
    <>
      <ToastContainer />
        <Navbar/>
        <Routes>
          <Route path="*" element={<PageNotFound />} />
          <Route path="/" element={ <Home/>} />
          <Route path="/about" element={<About />} />

          
          <Route path="/gallery" element={  <IsAuthorised><Gallery/></IsAuthorised>  } />
          <Route path="/news" element={<News />} />





          <Route path="/user/account" element={<Account/>} /> 



          <Route path="/user/dashboard" element={<IsAuthorised><Dashboard/></IsAuthorised>}/> 

        </Routes>
        <Footer />
    </>
  );
};

export default App;
