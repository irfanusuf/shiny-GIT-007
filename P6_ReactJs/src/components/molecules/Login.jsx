
import{ useContext, useState } from 'react'
import userProfile from "../../assets/user.png";
import { Link } from 'react-router-dom';
import { Context } from '../../Store';

const Login = ({ setShowRegister }) => {


    const {loading , loginHandler } = useContext(Context)

    const [email, setEmail] = useState("");
    const [password, setPass] = useState("");
    const formBody = { email, password }

    return (
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
                    <p>Dont have an accound <Link onClick={() => { setShowRegister(true) }}> Regeister Here </Link> </p>
                    <p> Checkout our <Link> user agreement policy  </Link>  & <Link> Terms and Conditions</Link> </p>
                </div>
                <button type="button" onClick={() => { loginHandler(formBody) }} disabled={loading} > {loading ? "Wait...." : "Login"} </button>
            </form>
        </div>

    )
}

export default Login