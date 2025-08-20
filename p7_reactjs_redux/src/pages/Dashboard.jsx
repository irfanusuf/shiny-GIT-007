import React from 'react'
import { useDispatch } from '../context/Store'

const Dashboard = () => {



  const {state} = useDispatch()
  return (
    <div>
        <h1>  this is a Secure Dashboard    user id is  {state.userId}</h1>

        <h3> Only a  logged in user is authorised is to see this page</h3>
    </div>
  )
}

export default Dashboard