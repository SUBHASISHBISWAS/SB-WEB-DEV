const Post = require("../models/Temperature");

exports.getPosts = (req, res, next) => {
  //+ convert To Number
  console.log("Server Connected");
  return res
    .status(200)
    .json({ message: "Temperature Retrieved Successfully ", temperature: 30 });
  next();
};
