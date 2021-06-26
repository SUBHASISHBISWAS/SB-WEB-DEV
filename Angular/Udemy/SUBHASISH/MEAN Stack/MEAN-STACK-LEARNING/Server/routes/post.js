const express = require("express");
const multer = require("multer");
const postController = require("../Controller/posts");

const checkAuth = require("../middleware/check-auth");

const router = express.Router();
const MIME_TYPE_MAP = {
  "image/png": "png",
  "image/jpeg": "jpg",
  "image/jpg": "jpg",
};
const storage = multer.diskStorage({
  destination: (req, file, cb) => {
    const isValid = MIME_TYPE_MAP[file.mimetype];
    let error = new Error("Invalid Mime Type");
    if (isValid) {
      error = null;
    }
    cb(error, "server/images");
  },
  filename: (req, file, cb) => {
    const name = file.originalname.toLocaleLowerCase().split(" ").join("-");
    const ext = MIME_TYPE_MAP[file.mimetype];
    cb(null, name + "-" + Date.now() + "." + ext);
  },
});
router.get("", postController.getPosts);

router.get("/:id", postController.getPost);

router.post(
  "",
  checkAuth,
  multer({ storage: storage }).single("image"),
  postController.createPosts
);

router.put(
  "/:id",
  checkAuth,
  multer({ storage: storage }).single("image"),
  postController.updatePost
);

router.delete("/:id", checkAuth, postController.deletePost);

module.exports = router;
