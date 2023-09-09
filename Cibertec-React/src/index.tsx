import * as React from "react";
import * as ReactDOM from "react-dom";
import 'url-search-params-polyfill';

import {Hello} from "./components/Hello";
import { CustomersApp } from "./routes";

ReactDOM.render(
    <CustomersApp/>,
    document.getElementById("cibertec-app")
);

// <Hello compiler="Webpack" framework="React"/>,