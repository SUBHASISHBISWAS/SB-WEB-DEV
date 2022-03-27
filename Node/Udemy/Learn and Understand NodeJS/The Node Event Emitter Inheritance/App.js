var EventEmitter = require("events");
var util = require("util");

function Greetr() {
  this.greeting = "Hello World";
}

util.inherits(Greetr, EventEmitter);

Greetr.prototype.greet = function () {
  console.log(this.greeting);
  this.emit("Greet");
};

var gtr = new Greetr();

gtr.on("Greet", function () {
  console.log("Greeting Happened");
});

gtr.greet();

var name = "Subhasish";
var hello = `Hello ${name}`;

console.log(hello);
