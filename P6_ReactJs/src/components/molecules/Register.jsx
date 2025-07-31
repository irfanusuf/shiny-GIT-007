import axios from 'axios'
import  { useState } from 'react'
import { Link } from "react-router-dom";
import { toast } from "react-toastify";
import userProfile from "../../assets/user.png";

const Register = ({darkmode , setShowRegister}) => {


    const [username, setUsername] = useState("");

    const [email, setEmail] = useState("");

    const [password, setPass] = useState("");


    const [loading, setLoading] = useState(false)

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



    return (
        <div className={darkmode ? "regsiter-dark register " : "register-light register "} >

            <h2 style={{ textAlign: "center", color: "grey" }}> Register with us  <img src={userProfile} width={50} /> </h2>
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
                    <p>Already have an account go to <Link onClick={() => { setShowRegister(false) }}>  Login </Link> </p>
                    <p> Checkout our <Link> user agreement policy  </Link>  & <Link> Terms and Conditions</Link> </p>
                </div>

                <button type="button" onClick={registerHandler} disabled={loading} > {loading ? "Wait...." : "Register"} </button>
            </form>
        </div>
    )
}

export default Register