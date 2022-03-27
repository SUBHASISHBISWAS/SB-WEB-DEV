import React, { Component } from "react";

export default class CReactEventBasics extends Component {
  handelClicked() {
    console.log("clicked");
  }

  render() {
    return (
      <div>
        <button onClick={this.handelClicked}>Click Me Class Component</button>
      </div>
    );
  }
}
