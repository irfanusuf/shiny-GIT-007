const { User } = require("../models/userModel");

const getUser = async (req, res) => {
  try {
    const findUser = await User.findOne({ email: "irfanusuf33@gmail.com" }); // db query

    if (findUser) {
      res.render("userProfile", {
        title: "Techytechs | User-profile",
        username: findUser.username,
        email: findUser.email,
      });
    }
  } catch (error) {
    console.log(error);
  }
};

module.exports = getUser;
