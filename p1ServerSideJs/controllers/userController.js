const { User } = require("../models/userModel");
const bcrypt = require("bcrypt");





const registerController = async (req, res) => {
  try {
    const { username, email, password } = req.body;

    if (username === "" || email === "" || password === "") {
      return res.json({
        success: false,
        message: "All credentials Required !",
      });
    }

    const findUser = await User.findOne({ email }); // db query which finds user in data base

    if (findUser) {
      return res.json({
        success: true,
        message: "User Already exits!",
      });
    }
    const encryptPass = await bcrypt.hash(password, 10);

    const newUser = await User.create({
      username: username,
      email: email,
      password: encryptPass,
    });

    if (newUser) {
      return res.json({
        success: true,
        message: "User account Created succesfully",
      });
    } else {
      return res.json({
        success: false,
        message: "Some Error . please try after sometime!",
      });
    }
  } catch (error) {
    console.log(error);
  }
};




const loginController = async (req, res) => {
  try {
    const { email, password } = req.body;

    if (email === "" || password === "") {
      return res.json({
        success: false,
        message: "All credentials Required !",
      });
    }

    const finduser = await User.findOne({ email });

    if (!finduser) {
      return res.json({
        success: false,
        message: "User Not Found!",
      });
    }

    const comparePass = await bcrypt.compare(password, finduser.password);

    if (comparePass) {
      return res.json({
        success: true,
        message: "Logged in succesfully!",
      });
    } else {
      return res.json({
        success: false,
        message: "PassWord Incorrect",
      });
    }
  } catch (error) {
    console.log(error);
  }
};





const userProfileController = (req, res) => {
  res.send("This is userProfile");
};

module.exports = { registerController, loginController, userProfileController };
