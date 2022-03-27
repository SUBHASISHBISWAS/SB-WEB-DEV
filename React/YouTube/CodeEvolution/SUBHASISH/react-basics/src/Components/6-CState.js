import React, { Component } from 'react'

export default class CState extends Component {

    constructor(props) {
        super(props)
    
        this.state = { message : 'Welcome Visitor'}
    }
    
    ChangeState(){

        this.setState({message : 'Welcome Subhasish'})
    }
    render() {
        return (
            <div>
                <h1>{this.state.message}</h1>
                <button onClick={()=>this.ChangeState()}>Change State</button>
            </div>
        )
    }
}
