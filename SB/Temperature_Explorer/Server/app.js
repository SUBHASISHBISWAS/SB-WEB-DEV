const express = require("express");

const temperatureRoutes = require("./routes/Temperature");

const path = require("path");

const app = express();

app.use(express.json());
app.use(
  express.urlencoded({
    extended: true,
  })
);

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

app.use("/api/temperature", temperatureRoutes);

module.exports = app;
