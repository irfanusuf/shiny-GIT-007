
import { useContext, useEffect, useState } from "react";
import { Context } from "../Store";

const Gallery = () => {
  
  const [page, setPage] = useState(1);

  const [loadNewData , setLoadNewData] = useState(false)



   const {pics , fetchPics} = useContext(Context)

  useEffect(() => {
    fetchPics(page);
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
