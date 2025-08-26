
import { useState } from 'react'
import userProfile from "../../assets/user.png";
import { Link, useNavigate } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import { loginHandler } from '../../redux/Actions';


const Login = ({ setShowRegister , userState }) => {


    const dispatch = useDispatch()
    const navigate = useNavigate()
    


    const [email, setEmail] = useState(userState.email);


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
                <button type="button"
                    onClick={async () => {
                        const login = await  dispatch(loginHandler(formBody)) 

                        if (login) {
                            navigate("/user/dashboard")
                        }
                    }}
                    disabled={userState.loading} >
                    {userState.loading ? "Wait...." : "Login"} </button>
            </form>
        </div>

    )
}

export default Login