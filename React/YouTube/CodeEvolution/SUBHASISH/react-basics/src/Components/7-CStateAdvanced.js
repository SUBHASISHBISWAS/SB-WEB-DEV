import React, { Component } from 'react'

export default class CStateAdvanced extends Component {

    constructor(props) {
        super(props)
    
        this.state = { count : 0}
    }
    
    IncrementCount(){

        this.setState({count : this.state.count + 1},()=>{
            console.log(` Callback Count : ${this.state.count}`)
        })
        console.log(this.state.count)
    }
    render() {
        return (
            <div>
                <h1>{this.state.count}</h1>
                <button onClick={()=>this.IncrementCount()}>Increment</button>
            </div>
        )
    }
}
