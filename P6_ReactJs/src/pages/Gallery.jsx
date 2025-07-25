import axios from 'axios'
import React, { useEffect } from 'react'

const Gallery = () => {


    const fetchPics = async () => {

        try {


            const res = await axios.get("https://api.pexels.com/v1/curated", {
                headers: {
                    Authorization: "A18L6UPAOtZeFZ4vLDzj2fO4wTeto2iIb2aqtyo2EA3agRXRdEN6YFRV"
                },
                params: {
                    per_page: 80,
                    page: 1
                }
            })



            if (res.status === 200) {

                console.log(res.data)
            }

        } catch (error) {
            console.error(error)
        }

    }


      useEffect(()=>{
        fetchPics()
      } ,[])




    return (
        <div>Gallery</div>
    )
}

export default Gallery