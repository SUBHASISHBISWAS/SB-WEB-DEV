const express = require("express");

const temperatureController = require("../Controller/Temperature");

const router = express.Router();

router.get("", temperatureController.getPosts);

module.exports = router;
