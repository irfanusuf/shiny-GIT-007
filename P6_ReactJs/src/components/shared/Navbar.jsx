import React, { useContext, useState } from 'react'
import { Link } from 'react-router-dom'
import { GiNightSleep } from "react-icons/gi";
import { LuSun } from "react-icons/lu";
import { linkArr } from '../../data/data';
import { Context } from '../../Store';

const Navbar = () => {

    const {darkMode , setDarkMode} = useContext(Context)

    return (
        <div className={darkMode ? " navbar-dark" : "navbar-light"}>


            <div className='logo'>
                <h3> Logo Here</h3>
            </div>

            <ul>
                {linkArr.map((element) => <li> <Link to={element.address}> {element.name}  </Link>  </li>)}
            </ul>

            <div className='dark_mode_button'>
                <button onClick={setDarkMode}>{!darkMode ? <GiNightSleep /> : <LuSun />}  </button>
            </div>

        </div>
    )
}

export default Navbar