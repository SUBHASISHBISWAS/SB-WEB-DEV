import React, { Component } from 'react'

export default class CBulkSetSateUpdate extends Component {

    constructor(props) {
        super(props)
    
        this.state = { count : 0}
    }
    IncrementCount(){

        //React combine multiple set State call to single setState call 
        //and update the state once so instead of increment 5 it does only 
        //1 increment …so solve this pass setState a Function 
        this.setState((prevState, props )=>({ count : prevState.count+ 1 }),()=>
        {
            console.log(` Callback Count : ${this.state.count}`)
        })
        // this.setState({count : this.state.count + 1},()=>{
        //     console.log(` Callback Count : ${this.state.count}`)
        // })
        console.log(this.state.count)
    }
    MultipleIncrement()
    {
        this.IncrementCount()
        this.IncrementCount()
        this.IncrementCount()
        this.IncrementCount()
        this.IncrementCount()
    }


    render() {
        return (
            <div>
                <h1>{this.state.count}</h1>
                <button onClick={()=>this.MultipleIncrement()}>Increment</button>
            </div>
        )
    }
}
