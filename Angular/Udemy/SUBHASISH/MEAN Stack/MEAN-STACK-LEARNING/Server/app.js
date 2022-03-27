const express = require("express");
const mongoose = require("mongoose");

const postRoutes = require("./routes/post");
const userRoutes = require("./routes/user");

const path = require("path");
mongoose
  .connect(
    "mongodb+srv://subhasish:" +
      process.env.MONGO_ATLAS_PWD +
      "@mumbaicluster.0a4mb.mongodb.net/BlogsDb?retryWrites=true&w=majority",
    { useNewUrlParser: true, useUnifiedTopology: true }
  )
  .then(() => {
    console.log("MongoDb Connected With Express Server");
  })
  .catch((ex) => {
    console.log("Connection Failed");
    console.log(ex);
  });

const app = express();

app.use(express.json());
app.use(
  express.urlencoded({
    extended: true,
  })
);

app.use("/images", express.static(path.join("images")));

// CORS header
app.use((req, res, next) => {
  res.header("Access-Control-Allow-Origin", "*");
  res.setHeader(
    "Access-Control-Allow-Headers",
    "Origin, X-Requested-With, Content-Type, Accept, Authorization"
  );
  res.setHeader(
    "Access-Control-Allow-Methods",
    "GET,POST,PUT,PATCH,DELETE,OPTION"
  );
  next();
});

app.use("/api/posts", postRoutes);
app.use("/api/user", userRoutes);

module.exports = app;
