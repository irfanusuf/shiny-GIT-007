import React, { useContext } from 'react'
import { Context } from '../../Store'


const Footer = () => {


  const {username} = useContext(Context)


  
  return (
    <div className='footer'>


      <h3> All Rights Reserved 2025  {username}</h3>



    </div>
  )
}

export default Footer