import React from 'react'

export const ReactProps = (props) => {
    console.log(props)
    return (
        <div>
        <h1> 
            Hello {props.name} a.k.a {props.title}
        </h1>
        {props.children}
        </div>
        
        
    )
}
