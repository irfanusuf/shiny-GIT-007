import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import loadingGif from "../assets/loading.gif";

const IsAuthorised = ({ children }) => {
  const token = localStorage.getItem("Authorization_Token");
  const navigate = useNavigate();
  const [auth, setAuth] = useState(false);

  useEffect(() => {
    if (!token || token === undefined || token === null || token === "") {
      setAuth(false);
      navigate("/user/account");
    } else {
      setTimeout(() => {
        setAuth(true);
      }, 3000);
      // api call kernay backend ko with token
    }
  }, [token]);

  if (auth) {
    return children;
  } else {
    return (
      <div>
        <img src={loadingGif} />
      </div>
    );
  }
};

export default IsAuthorised;
