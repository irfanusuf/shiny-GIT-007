const express = require("express"); // express library ko import kero node module se
const path = require("path"); // import from node modules
const bodyParser = require("body-parser");
const xhbs = require("express-handlebars");
const {
  registerController,
  loginController,
  userProfileController,
} = require("./controllers/userController"); // import function from userController
const { connectDb } = require("./config/connectDb");

// node module standard libarary hai node js ki     // 3rd party libarary

const app = express(); // new instance of express intailized
const Port = 4004;

connectDb(); // connecting mongo db

// graphics engine

// app.set("view engine" , "html")      // default configuration for express

app.set("view engine", "hbs"); // chnaging render engine to hbs
app.set("views", path.join(__dirname, "views", "pages")); // web pages are inside the pages folder
// app.set("partial", path.join(__dirname, "views", "partials"));   // web pages are inside the pages folder

app.engine(
  "hbs",
  xhbs.engine({
    extname: "hbs",
    defaultLayout: "layout",
    layoutsDir: path.join(__dirname, "views", "layouts"),
    partialsDir: path.join(__dirname, "views", "partials"),
  })
);



//middle ware // helping functions which parses incoming data in json  and destructures it for controller

app.use(bodyParser.urlencoded({ extended: true })); // relevant for post methods
// app.use(express.json()); //parsing  json data
app.use(bodyParser.json());

// client tries to get a page and server sends page in response

app.get("/", (req, res) => {
  res.render("index", { title: "Techytechs | Home "  , name : "madhat"});
});

app.get("/register", (req, res) => {
  res.render("register", { title: "Techytechs | Register" });
}); // done

app.get("/login", (req, res) => {
  res.render("login", { title: "Techytechs | Login" });
}); // done
app.get("/about", (req, res) => {
  res.render("about", { title: "Techytechs | About" });
});
app.get("/contact", (req, res) => {
  res.render("contact", { title: "Techytechs | Contact" });
});

app.post("/register", registerController); // done
app.post("/login", loginController); // done

// app.post("/userProfile" , userProfileController)

app.listen(Port, () => {
  console.log(`Server started listening on Port ${Port}`);
});
