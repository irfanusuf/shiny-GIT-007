
import { Link } from 'react-router-dom'
import { GiNightSleep } from "react-icons/gi";
import { LuSun } from "react-icons/lu";
import { linkArr } from '../../data/data';
import {  useDispatch } from '../../context/Store';
import { setDarkMode } from '../../context/Actions';


const Navbar = () => {

    const {state , dispatch } =    useDispatch()


    return (
        <div className={state.darkMode ? " navbar-dark" : "navbar-light"}>


            <div className='logo'>
                <h3> Logo Here</h3>
            </div>

            <ul>
                {linkArr.map((element) => <li key={element.name}> <Link to={element.address}> {element.name}  </Link>  </li>)}
            </ul>

            <div className='dark_mode_button'>
                <button onClick={  ()=>{ setDarkMode(dispatch)  } }>{!state.darkMode ? <GiNightSleep /> : <LuSun />}  </button>
            </div>

        </div>
    )
}

export default Navbar