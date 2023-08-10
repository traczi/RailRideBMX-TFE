import React from "react";
import {Field} from 'formik'

const ValidationForm = (errors, touched, title, name, type, className) => {
    return(
        <div>   
            <p>{title}</p>
            <Field type={type} name={name} className={className}/>
            {errors.name && touched.name}
            <div>{errors.name}</div>
        </div>
    )
}

export default ValidationForm