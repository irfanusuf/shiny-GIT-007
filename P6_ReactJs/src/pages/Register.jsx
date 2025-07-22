import axios from "axios";
import React, { useState } from "react";

const Register = () => {
  const [username, setUsername] = useState("");

  const [email, setEmail] = useState("");

  const [password, setPass] = useState("");


const formBody = {

  username , email , password
}


    const registerHandler =  async () =>{

      try {
        const res = await axios.post("http://localhost:5288/user/register" , formBody)

        if(res.status === 200){
          window.alert(res.data.message)
        }
        
      } catch (error) {

        window.alert("network Error")
        console.error(error)
      }



    }








  return (
    <div className="register">
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

        <button type="button" onClick={registerHandler}> Register </button>
      </form>
    </div>
  );
};

export default Register;
