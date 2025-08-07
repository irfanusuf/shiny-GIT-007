
import { useDispatch } from "../../context/Store";



const Testimonials = () => {


  const {state} = useDispatch()




  return (
    <div>
      <h1> This is testimonial section</h1>

        <p> I want to say i m very thankful to {state.user.username}</p>
        <p>  My email is {state.user && state.user.email}</p>
    </div>
  );
};

export default Testimonials;
