import React from 'react'
import { Link } from 'react-router-dom'

const Navbar = () => {
    return (
        <div className='navbar'>


            <div className='logo'>
                <h3> Logo Here</h3>
            </div>

            <ul>
                <li> <Link to='/'> Home  </Link>   </li>
                <li> <Link to='/user/register'> Register  </Link>    </li>
                <li> <Link to='/user/login'> Login  </Link>    </li>
                <li> <Link to='/about'> About  </Link>    </li>
            </ul>

        </div>
    )
}

export default Navbar