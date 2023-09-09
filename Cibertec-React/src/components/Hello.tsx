import * as React from "react";

export interface HelloProps{
    compiler: string;
    framework: string;
}

export class Hello extends React.Component<HelloProps, any>{
    render(){
        return <h1>¡Hola desde {this.props.compiler} y {this.props.framework}!</h1>
    }
}