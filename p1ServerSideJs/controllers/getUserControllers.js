const { User } = require("../models/userModel");
const jwt = require("jsonwebtoken")





// [authorised route]

const getUser = async (req, res) => {
  try {
 
    const {authToken} = req.cookies

    if(authToken === undefined ) {
     return res.status(401).render("error" , {error : "Forbidden Your are not authentcated to view this page "})    // unAuthenticated
    }
    const secretKey = "thisislekjgoimsecretKey"; // digital signtaure
    const verifytoken = jwt.verify(authToken , secretKey)
    const userId = verifytoken.payload

    const findUser  = await User.findById(userId)   // logged in user object //

    // const findUser = await User.findOne({ email: "irfanusuf33@gmail.com" }); // db query which returns user Object

    if (findUser) {
      res.render("userProfile", {
        title: "Techytechs | User-profile",
        username: findUser.username,
        email: findUser.email,
        password : findUser.password
      });
    }
  } catch (error) {
    console.log(error);
  }
};

module.exports = getUser;
