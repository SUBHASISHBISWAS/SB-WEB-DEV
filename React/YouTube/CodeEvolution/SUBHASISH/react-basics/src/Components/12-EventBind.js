import React, { Component } from "react";

export default class EventBind extends Component {
  constructor(props) {
    super(props);

    this.state = { message: "Welcome" };
    //this.handelClicked = this.handelClicked.bind(this);
  }
  //   handelClicked() {
  //     this.setState((prevState, props) => ({ message: "GoodBye!!!" }));
  //   }
  handelClicked = () => {
    this.setState((prevState, props) => ({ message: "GoodBye!!!" }));
  };
  render() {
    return (
      <div>
        <div>{this.state.message}</div>
        {/* Way-1 to bind this */}
        {/* <button onClick={this.handelClicked}>ChnageStateCC</button> */}

        {/* way 2 to binding this */}
        {/* <button onClick={() => this.handelClicked()}>ChnageStateCC</button> */}

        {/* Way-3 Do binding in constructor and pass hadler pointer here */}
        <button onClick={this.handelClicked}>ChnageStateCC</button>
      </div>
    );
  }
}
