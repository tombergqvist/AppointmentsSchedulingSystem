import React from 'react'
import { Component } from 'react'

class Button extends Component{
    render(){
        return(
            <button className='btn' onClick={this.props.onClick}>{this.props.value}</button>
        )
    }
}

export default Button