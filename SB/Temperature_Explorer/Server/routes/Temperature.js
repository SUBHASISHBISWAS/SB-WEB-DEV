import express from "express";
import getTemperature from "../Controller/Temperature.js";

const router = express.Router();
router.get("", getTemperature);

export default router;
