sayHello = function () {
  console.log("Hello");
};

function Greet(fn) {
  fn();
}

Greet(sayHello);

Greet(function () {
  console.log("Hello Subhasish");
});
