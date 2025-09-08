import React from 'react'
import { useGetPostsQuery } from '../redux/api/jsonPlaceHolderApi'

const Placeholder = () => {


    const {data , isLoading , error} = useGetPostsQuery()
    



  return (
    <div>

    <h1> Demo of place Holder Fake Api </h1>
    <h3>  {isLoading ? "Loading ...." : "data fetched Succesfully"} </h3>
    <h3> {error && error.message} </h3>

    <div style={{display : 'flex' , flexWrap : 'wrap'}}>


         {data &&   data.map((post) => (<div style={{width : "400px" , border : "1px solid black ", margin : "20px auto" , padding : "20px"}}>  

            <span> {post.id} </span>
            <h1> {post.title}</h1>
            <p> {post.body} </p>


        </div>) )}


    </div>



    </div>
  )
}

export default Placeholder