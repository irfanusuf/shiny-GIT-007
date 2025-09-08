
import { useNavigate } from 'react-router-dom'
import {  useGetUsersQuery } from '../redux/api/jsonPlaceHolderApi'

const PlaceHolderPhotos = () => {


    const { data, isLoading, error } = useGetUsersQuery()
    const navigate = useNavigate()


    return (
        <div>

          <h1> PlaceHolderPhotos  </h1>  

          <h3>  {isLoading ? "Loading..." : "Data fetched Succesfully!"} </h3>

          <div>

            {data && data.map((user)=>(<div style={{width : "300px" , border : "1px solid black" , margin : "20px auto " , padding : "20px"}}> 


                <h1> {user.name} </h1>

                <button onClick={()=>{
                    navigate(`/user/${user.id}`)
                }}> Get details </button>
            </div>))}

          </div>

        </div>
    )
}

export default PlaceHolderPhotos