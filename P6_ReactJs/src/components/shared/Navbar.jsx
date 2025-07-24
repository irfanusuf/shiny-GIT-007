import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import { GiNightSleep } from "react-icons/gi";
import { LuSun } from "react-icons/lu";

const Navbar = ({darkmode , setDarkMode}) => {


    return (
        <div className={ darkmode ? " navbar-dark" : "navbar-light" }>


            <div className='logo'>
                <h3> Logo Here</h3>
            </div>

            <ul>
                <li> <Link to='/'> Home  </Link>   </li>
                <li> <Link to='/user/account'> Account  </Link>    </li>
                <li> <Link to='/about'> About  </Link>    </li>
            </ul>

            <div className='dark_mode_button'>
                <button onClick={()=>{setDarkMode(!darkmode)}}>{!darkmode ?  <GiNightSleep/> :  <LuSun/>}  </button>
            </div>

        </div>
    )
}

export default Navbar