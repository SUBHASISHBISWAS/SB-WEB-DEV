import React, { Component } from 'react'

export default class CReactProps extends Component {
    render() {
        return (
            <div>
                <h1> Hello {this.props.name} a.k.a {this.props.title} in class component </h1>
            </div>
        )
    }
}
