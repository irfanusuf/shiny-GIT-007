const { Blog } = require("../models/blogModel");
const jwt = require("jsonwebtoken");
const { User } = require("../models/userModel");

const createBlog = async (req, res) => {
  try {
    const userId = req.userId; // this userid is coming from middle wares

    let user = await User.findById(userId);   // db se user ko dondo 

    if (user !== null) {

      const { blogTitle, blogDescription } = req.body;

      if (blogTitle === "" || blogDescription === "") {
        return res.render("createBlog", {
          title: "create blog",
          errorMessage: "Both Feilds are required",
        });
      }

      const newBlog = await Blog.create({
        blogTitle,
        blogDescription,
        author: userId,
      });


    
      if (newBlog) {

       user.blogs.push(newBlog._id)
       await user.save()
        // return res.json({success : true})     // tesing purpose
        return res.redirect("/blogs");
      }
    }

  } catch (error) {
    console.log(error);
  }
};

const getallBlogs = async (req, res) => {
  try {
    const getBlogs = await Blog.find().lean(); /// reading all the blogs from db // lean is comptabile with hbs

    if (getBlogs) {
      // return res.json({getBlogs})

      return res.render("blogs", { title: "Blogs", blogs: getBlogs });
    } else {
      return res.render("error", {
        error: "Some Error , try again after sometime",
      });
    }
  } catch (error) {
    res.render("error", { error: error.message });
    console.log(error);
  }
};

module.exports = { createBlog, getallBlogs };
