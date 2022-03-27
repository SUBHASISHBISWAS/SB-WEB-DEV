import React from 'react'

export default function JSXComponent() {
     
        
        // <div>
        //     <h1>Hello Subhasish</h1>
        // </div>

        // Instaed of above creating Element This Way

        return React.createElement('div',
        {id: 'divTag',className: 'newClass'},
        React.createElement('h1',null,'Hello Subhasish JSX'))
        
    
    
}
