const express = require("express");    // express library ko import kero node module se 
const path = require("path")    // import from node modules
const bodyParser = require("body-parser")
const { registerController, loginController, userProfileController } = require("./controllers/userController");    // import function from userController


// node module standard libarary hai node js ki     // 3rd party libarary 

const app = express();    // new instance of express intailized
const Port = 4004


//middle ware // helping functions which parses incoming data in json  and destructures it for controller 

app.use(bodyParser.urlencoded({ extended: true })); // relevant for post methods
// app.use(express.json()); //parsing  json data
app.use(bodyParser.json()) 




// client tries to get a page and server sends page in response 

app.get("/" , (req,res)=>{res.sendFile(path.join(__dirname , "views" , "index.html"))})
app.get("/login" , (req,res)=>{res.sendFile(path.join(__dirname , "views" , "login.html"))})
app.get("/register" , (req,res)=>{res.sendFile(path.join(__dirname , "views" , "register.html"))})
app.get("/about" , (req,res)=>{res.sendFile(path.join(__dirname , "views" , "about.html"))})
app.get("/contact" , (req,res)=>{res.sendFile(path.join(__dirname , "views" , "contact.html"))})



app.post("/register" , registerController)
app.post("/login" , loginController)
app.post("/userProfile" , userProfileController)








app.listen(Port , () =>{console.log(`Server started listening on Port ${Port}`)})



