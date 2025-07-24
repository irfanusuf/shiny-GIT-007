import axios from "axios";
import React, { useState } from "react";
import { MdLogin } from "react-icons/md";
import { Link } from "react-router-dom";
import { toast } from "react-toastify";
import userProfile from "../assets/user.png"

const Account = ({darkmode , setDarkMode}) => {



  const [username, setUsername] = useState("");

  const [email, setEmail] = useState("");

  const [password, setPass] = useState("");

  const [loading, setLoading] = useState(false)

  const [showRegister, setShowRegister] = useState(true)


  const formBody = { username, email, password }


  const registerHandler = async () => {

    try {
      setLoading(true)
      const res = await axios.post("http://localhost:5294/api/User/Register", formBody)

      if (res.status === 200) {
        setLoading(false)
        toast.success(res.data.message)
      }

    } catch (error) {

      toast.error("Network Error")
      setLoading(false)
      console.error(error)
    }
  }





  const loginHandler = async () => {

    try {
      setLoading(true)
      const res = await axios.post("http://localhost:5294/api/User/login", formBody)

      if (res.status === 200) {
        setLoading(false)
        toast.success(res.data.message)
      }

    } catch (error) {

      toast.error("Network Error")
      setLoading(false)
      console.error(error)
    }
  }


  return (


    <>

    <div className={darkmode ? "account-dark account" : "account-light account"}>


{/* " animate__animated animate__backInDown" */}

      {
        showRegister ? <div className= {darkmode ? "regsiter-dark register "  : "register-light register "} >

          <h2 style={{ textAlign: "center" , color : "grey" }}> Register with us  <img src={userProfile} width={50} /> </h2>
          <form>


            <div>
              <label> Username </label>
              <input
                type="text"
                value={username}
                onChange={(e) => {
                  setUsername(e.target.value);
                }}
              />
            </div>



            <div>
              <label> Email </label>
              <input
                type="email"
                value={email}
                onChange={(e) => {
                  setEmail(e.target.value);
                }}
              />
            </div>


            <div>
              <label> Password </label>
              <input
                type="password"
                value={password}
                onChange={(e) => {
                  setPass(e.target.value);
                }}
              />
            </div>

            <div className="links" >
              <p>Already have an account go to <Link onClick={()=>{setShowRegister(false)}}>  Login </Link> </p>
              <p> Checkout our <Link> user agreement policy  </Link>  & <Link> Terms and Conditions</Link> </p>
            </div>

            <button type="button" onClick={registerHandler} disabled={loading} > {loading ? "Wait...." : "Register"} </button>
          </form>
        </div>
          :

          <div className="register animate__animated animate__backInDown">

            <h2 style={{ textAlign: "center" }}> Login your account  <img src={userProfile} width={50} /> </h2>
            <form>



              <div>
                <label> Email </label>
                <input
                  type="email"
                  value={email}
                  onChange={(e) => {
                    setEmail(e.target.value);
                  }}
                />
              </div>


              <div>
                <label> Password </label>
                <input
                  type="password"
                  value={password}
                  onChange={(e) => {
                    setPass(e.target.value);
                  }}
                />
              </div>

              <div className="links" >
                <p>Dont have an accound <Link onClick={()=>{setShowRegister(true)}}> Regeister Here </Link> </p>
                <p> Checkout our <Link> user agreement policy  </Link>  & <Link> Terms and Conditions</Link> </p>
              </div>

              <button type="button" onClick={loginHandler} disabled={loading} > {loading ? "Wait...." : "Login"} </button>
            </form>
          </div>


      }


    </div>



    </>



  );
};

export default Account;
