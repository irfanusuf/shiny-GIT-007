
import {useState } from "react";
import Register from "../components/molecules/Register";
import Login from "../components/molecules/Login";
import { useSelector } from "react-redux";



const Account = () => {

  const userState =  useSelector((state) => state.user)

  const [showRegister, setShowRegister] = useState(true);


  return (
    <div
      className={userState.darkMode ? "account-dark account" : "account-light account"}
    >
      {showRegister ? (
        <Register  setShowRegister={setShowRegister}  userState ={userState} />
      ) : (
        <Login  setShowRegister={setShowRegister} userState ={userState} />
      )}
    </div>
  );
};

export default Account;
