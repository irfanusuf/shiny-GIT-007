import React from 'react'
import Testimonials from './Testimonials'

const HeroSection = ({username}) => {
  return (
    <div>
        <h1> This is a hero Section</h1>



        <Testimonials username={username}/>
    </div>
  )
}

export default HeroSection