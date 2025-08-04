
import { useContext, useState } from "react";
import Register from "../components/molecules/Register";
import Login from "../components/molecules/Login";
import { Context } from "../Store";

const Account = () => {


  const [showRegister, setShowRegister] = useState(true);

  const {darkMode} = useContext(Context)

  return (
    <div
      className={darkMode ? "account-dark account" : "account-light account"}
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
