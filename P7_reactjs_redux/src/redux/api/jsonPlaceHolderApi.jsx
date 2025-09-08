import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";





export const placeHolderApi = createApi({
    reducerPath : "placeHolderApi",
    baseQuery : fetchBaseQuery({baseUrl : "https://jsonplaceholder.typicode.com/"}),
    endpoints : (builder) => ({
        getPosts : builder.query({
            query : () => "posts"
        }),
        getPhotos : builder.query({
            query : () => "photos"
        }),
        getUsers : builder.query({
            query : () => "users"
        }),
        getUserById : builder.query({
            query : (id) => `users/${id}`
        })
    })
    
}) 




export const {useGetPostsQuery , useGetPhotosQuery , useGetUsersQuery , useGetUserByIdQuery} = placeHolderApi