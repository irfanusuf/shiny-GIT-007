const express = require("express")    // express library ko import kero node module se 


// node module standard libarary hai node js ki     // 3rd party libarary 

const app = express();    // new instance of express intailized
const Port = 4000

app.get("/" , (req,res)=>{ res.send("hello from the server")})
app.get("/login" , (req,res)=>{res.send("Develeoper are shengith")})
app.get("/register" , (req,res)=>{res.send("cant register right now server is busy")})
app.get("/userProfile" , (req,res)=>{res.send("no userProfile found")})


app.listen(Port , () =>{console.log(`Server started listening on Port ${Port}`)})



