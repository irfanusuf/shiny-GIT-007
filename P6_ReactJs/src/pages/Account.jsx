
import { useState } from "react";
import Register from "../components/molecules/Register";
import Login from "../components/molecules/Login";

const Account = ({ darkmode }) => {
  const [showRegister, setShowRegister] = useState(true);

  return (
    <div
      className={darkmode ? "account-dark account" : "account-light account"}
    >
      {showRegister ? (
        <Register darkmode={darkmode} setShowRegister={setShowRegister} />
      ) : (
        <Login darkmode={darkmode} setShowRegister={setShowRegister} />
      )}
    </div>
  );
};

export default Account;
