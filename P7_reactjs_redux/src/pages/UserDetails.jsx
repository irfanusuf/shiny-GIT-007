
import { useGetUserByIdQuery } from '../redux/api/jsonPlaceHolderApi'
import { useParams } from 'react-router-dom'

const UserDetails = () => {



    const {userId} = useParams()

  const  {data , isLoading , error} = useGetUserByIdQuery(userId)

  return (
    <div>
        
        
     <h1> UserDetails  </h1>   
        
        
        
        
        
        </div>
  )
}

export default UserDetails