const express = require("express");
const User = require("../models/user");
const bcrypt = require("bcrypt");
const jwt = require("jsonwebtoken");
const user = require("../models/user");
const { toEditorSettings } = require("typescript");

const router = express.Router();

router.post("/signup", (req, res, next) => {
  bcrypt.hash(req.body.password, 10).then((hash) => {
    const user = new User({
      email: req.body.email,
      password: hash,
    });
    user
      .save()
      .then((result) => {
        res.status(201).json({ message: "User Created", result: result });
      })
      .catch((err) => {
        res.status(500).json({ error: err });
      });
  });
});

router.post("/login", (req, res, next) => {
  fetchedUser: User;
  User.findOne({ email: req.body.email })
    .then((user) => {
      if (!user) {
        return res
          .status(401)
          .json({ message: "Authentication Failed-User Not Available" });
      }
      fetchedUser = user;
      return bcrypt.compare(req.body.password, user.password);
    })
    .then((result) => {
      if (!result) {
        return res.status(401).json({ message: "Authentication Failed" });
      }

      const token = jwt.sign(
        { email: fetchedUser.email, userId: fetchedUser._id },
        "longer_string_need_to_passed",
        { expiresIn: "1h" }
      );
      console.log("Hello Hi");
      return res.status(200).json({ token: token });
    })
    .catch((err) => {
      return res
        .status(401)
        .json({ message: "Authentication Failed-While Creating Token" });
    });
});
module.exports = router;
