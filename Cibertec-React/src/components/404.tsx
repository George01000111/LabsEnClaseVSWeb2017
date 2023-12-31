import * as React from 'react';

export default function NotFound(){
    return(
        <div className="container-fluid container-login">
        <div className="row full-height-row">
            <div className="col-sm-12">
                <div className="text-center">
                    <h1 className="page-not-found">Pagina no encontrada :(
                        <br/>
                        <small className="page-not-found-small">Necesitas volver atras</small>
                    </h1>
                </div>
            </div>
        </div>
    </div>
    );
}