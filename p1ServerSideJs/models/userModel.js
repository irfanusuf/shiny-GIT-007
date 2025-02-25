const mongoose = require("mongoose");



// data schema // 


const User = mongoose.model("User", {
  username: String,
  email: String,
  password: String,
});


module.exports = {User}