const { User } = require("../models/userModel");

const registerController = async (req, res) => {
  try {
    const { username, email, password } = req.body;

    if (username === "" || email === "" || password === "") {
      return res.json({
        success: false,
        message: "All credentials Required !",
      });
    }

    const findUser = await User.findOne({ email });

    if (findUser) {
      return res.json({
        success: true,
        message: "User Already exits!",
      });
    }

    const newUser = await User.create({
      username: username,
      email: email,
      password: password,
    });

    if (newUser) {
      return res.json({
        success: true,
        message: "User account Created succesfully",
      });
    } else {
      return res.json({
        success: false,
        message: "Some Error ",
      });
    }
  } catch (error) {
    console.log(error);
  }
};

const loginController = (req, res) => {
  res.send("something to login thuis is login");
};

const userProfileController = (req, res) => {
  res.send("This is userProfile");
};

module.exports = { registerController, loginController, userProfileController };
