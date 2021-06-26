const express = require("express");
const userController = require("../Controller/user");

const { toEditorSettings } = require("typescript");

const router = express.Router();

router.post("/signup", userController.createUser);

router.post("/login", userController.userLogin);

module.exports = router;
