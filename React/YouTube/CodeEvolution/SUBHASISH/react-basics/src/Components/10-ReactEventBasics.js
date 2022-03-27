import React from "react";

export default function ReactEventBasics() {
  function handelClicked() {
    console.log("clicked");
  }
  return (
    <div>
      <button onClick={handelClicked}>Click Me</button>
    </div>
  );
}
