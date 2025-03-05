const { Blog } = require("../models/blogModel");

const createBlog = async (req, res) => {
  try {
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
    });

    if (newBlog) {
      // return res.json({success : true})     // tesing purpose
      return res.redirect("/blogs");
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
      console.log(getBlogs)
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
