import React from 'react'

const News = () => {



    const apiKey = "d75ec0f277194bb6aa1b75d1ebeaf603"

 const url = `https://newsapi.org/v2/everything?q=apple&from=2025-07-27&to=2025-07-27&sortBy=popularity&apiKey=${apiKey}`
  return (
    <div>News</div>
  )
}

export default News