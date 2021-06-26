const express = require("express");

const postController = require("../Controller/posts");

const checkAuth = require("../middleware/check-auth");
const saveImage = require("../middleware/images");

const router = express.Router();

router.get("", postController.getPosts);

router.get("/:id", postController.getPost);

router.post("", checkAuth, saveImage, postController.createPosts);

router.put("/:id", checkAuth, saveImage, postController.updatePost);

router.delete("/:id", checkAuth, postController.deletePost);

module.exports = router;
