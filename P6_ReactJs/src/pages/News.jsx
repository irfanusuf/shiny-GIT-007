import axios from "axios";
import React, { useEffect, useState } from "react";

const News = () => {
  const [newsArr, setNewsArr] = useState([]);

  const apiKey = "d75ec0f277194bb6aa1b75d1ebeaf603";
 

  const [searchQuery , setSeacrhQuery] =  useState("world")
  const [loadNews , setLoadNews] = useState(false)
  const [debounceTimeout, setDebounceTimeout] = useState(null);

  const url = `https://newsapi.org/v2/everything?q=${searchQuery}&from=2025-07-28&to=2025-07-28&sortBy=popularity&apiKey=${apiKey}`;

  const fetchNews = async () => {
    try {
      const res = await axios.get(url);

      if (res.status === 200) {
        console.log(res.data);
        setNewsArr(res.data.articles);
      }
    } catch (error) {
      console.error(error);
    }
  };

  const handleChange = (e) => {
    const value = e.target.value;
    setSeacrhQuery (value)

  };

  useEffect(() => {
    fetchNews();
  }, []);



  return (
    <div className="news_container">
      <h2> Latest News around the World</h2>


      <div>
        
         <input placeholder="search" value={searchQuery} onChange={(e)=>{handleChange(e)}}/>


       <button onClick={()=>{setLoadNews(!loadNews)}}> search</button>  
       
       
        </div>

      <div className="news">
        {newsArr.map((news) => (


          <div className="news_card">


            <h1> {news.title} </h1>
            <div className="heading">
           
              <span> published at : {news.publishedAt} </span>
              <span> Author : {news.author} </span>
            </div>

            <img src={news.urlToImage} alt= {news.author} />

            <p>{news.description}   <a href={news.url} target="_blank"> more  </a> </p>
          </div>


        ))}
      </div>
    </div>
  );
};

export default News;
