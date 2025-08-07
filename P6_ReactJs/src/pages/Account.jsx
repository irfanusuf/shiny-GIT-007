
import {useState } from "react";
import Register from "../components/molecules/Register";
import Login from "../components/molecules/Login";
import {  useDispatch } from "../context/Store";


const Account = () => {


  const [showRegister, setShowRegister] = useState(true);

  const {state} = useDispatch()

  return (
    <div
      className={state.darkMode ? "account-dark account" : "account-light account"}
    >
      {showRegister ? (
        <Register  setShowRegister={setShowRegister} />
      ) : (
        <Login  setShowRegister={setShowRegister} />
      )}
    </div>
  );
};

export default Account;
