//var Emitter = require("events");
var Emitter = require("./Emitter");
var events = require("./config").events;

var emtr = new Emitter();

emtr.on(events.GREET, function () {
  console.log("Hello i am Listener");
});

emtr.on("Greet", function () {
  console.log("Hello There i am Listener");
});

console.log("Hello There");
emtr.emit("Greet");
