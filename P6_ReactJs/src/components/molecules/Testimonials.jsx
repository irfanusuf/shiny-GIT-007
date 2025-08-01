import React, { useContext } from "react";
import { Context } from "../../Store";


const Testimonials = () => {


  const {username , email , darkMode} = useContext(Context)




  return (
    <div>
      <h1> This is testimonial section</h1>

        <p> I want to say i m very thankful to {username}</p>
        <p>  My email is {email}</p>
    </div>
  );
};

export default Testimonials;
