const Post = require("../models/Temperature");

const TemperatureDb = require("/Users/subhasish/Documents/APPLE/SUBHASISH/Development/GIT/Interstellar/SB-WEB-DEV/SB/Temperature_Explorer/Server/config");

exports.getPosts = (req, res, next) => {
  //+ convert To Number
  console.log("Server Connected");
  TemperatureDb.Add({ Temperature: 40 });
  return res
    .status(200)
    .json({ message: "Temperature Retrieved Successfully ", temperature: 30 });
  next();
};
