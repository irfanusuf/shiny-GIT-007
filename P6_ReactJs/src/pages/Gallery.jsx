import axios from "axios";
import React, { useEffect, useState } from "react";

const Gallery = () => {
  const [pics, setPics] = useState([]);
  const [page, setPage] = useState(1);
  const [loadNewData , setLoadNewData] = useState(false)

  const fetchPics = async () => {
    try {
      const res = await axios.get("https://api.pexels.com/v1/curated", {
        headers: {
          Authorization:
            "A18L6UPAOtZeFZ4vLDzj2fO4wTeto2iIb2aqtyo2EA3agRXRdEN6YFRV",
        },
        params: {
          per_page: 80,
          page: page,
        },
      });

      if (res.status === 200) {
        setPics(res.data.photos);
        console.log(res.data);
      }
    } catch (error) {
      console.error(error);
    }
  };

  useEffect(() => {
    fetchPics();
  }, [loadNewData]);




  return (
    <div className="picGallery">
      <div className="heading">
        <h2> Gallery </h2>

        <div className="buttons">
          <button
            onClick={() => {
              if (page > 1) {
                setPage((page) => page - 1);
                setLoadNewData(!loadNewData)
              }
            }}
          >
            Previous
          </button>



          <p>{page} </p>
          <button
            onClick={() => {
                if(page<100){
                setPage((page) => page + 1);      
                setLoadNewData(!loadNewData)
                }
            }}
          >
            Next
          </button>
        </div>
      </div>

      <div className="pics_container">
        {pics.map((pic) => (
          <div className="pic_card">
            <img src={pic.src.medium} alt={pic.alt} />
            <h4>{pic.photographer}</h4>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Gallery;
