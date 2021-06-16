const jwt = require("jsonwebtoken");
const { ModuleResolutionKind } = require("typescript");

module.exports = (req, res, next) => {
  try {
    const token = req.headers.authorization.split(" ")[1];
    jwt.verify(token, "longer_string_need_to_passed");
    next();
  } catch (error) {
    res.status(401).json({ message: "Authorization Failed BADLY" });
  }
};
