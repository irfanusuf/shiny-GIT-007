const registerController = (req, res) => {
  try {
    const { username, email, password } = req.body;

    if (username === "" || email === "" || password === "") {
      return res.json({
        success: false,
        message: "All credentials Required !",
      });
     
    }

    console.log(req.body)
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
