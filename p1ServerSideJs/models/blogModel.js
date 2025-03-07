const mongoose = require("mongoose");

const Blog = mongoose.model("Blog", {
  blogTitle: { type: String, require: true },
  blogDescription: { type: String, require: true },
  blogPicture: { type: String },
  author: { type: mongoose.Schema.Types.ObjectId, ref: "User" },
  category : {type : String},

  likes: [{ type: mongoose.Schema.Types.ObjectId, ref: "User" }],
  comments: [
    {
      text: { type: String },
      userId: { type: mongoose.Schema.Types.ObjectId, ref: "User" },
    },
  ],
});

module.exports = { Blog };






