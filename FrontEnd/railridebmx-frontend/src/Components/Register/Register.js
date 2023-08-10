import React from "react";
import './Register.css'
import {Formik, Form, Field} from 'formik'
import * as Yup from 'yup'
import ValidationForm from "../FormValidation/FormValidation";

const getCharacterValidationError = (str) => {
    return `Your password must have at least 1 ${str} character`;
  };

const SignupSchema = Yup.object().shape({
    firstname: Yup.string()
        .min(2, 'Too short!')
        .max(50, 'Too long!')
        .required('Required'),
    lastname: Yup.string()
        .min(2, 'Too short!')
        .max(50, 'Too long!')
        .required('Required'),
    email: Yup.string().email('Invalid email').required('required'),
    password: Yup.string().required('Password required')
        .min(8, '8 charactère minimum')
        .max(15, '15 charactère maximum')
        .matches(/[0-9]/, getCharacterValidationError("digit"))
        .matches(/[a-z]/, getCharacterValidationError("lowercase"))
        .matches(/[A-Z]/, getCharacterValidationError("uppercase")),
    retypePassword: Yup.string().required('required')
    .oneOf([Yup.ref("password")], "Passwords does not match"),
});


const Register = () => {
    return(
        <div className="register-field">
            <div className="title-register">
                <h1>Signup</h1>
            </div>
            <Formik
            initialValues={{
                firstname: '',
                lastname: '',
                email: '',
                password: '',
                retypePassword: '',
            }}
            validationSchema={SignupSchema}
            onSubmit={values => {
                console.log(values);
            }}
            >
                {({errors, touched}) => (
                <div className="register-content">
                    <Form>
                        <p>firstname</p>
                        <Field name="firstname" className="register-field"/>
                        {errors.firstname && touched.firstname}
                        <div>{errors.firstname}</div>
                        <p>Lastname</p>
                        <Field name="lastname" className="register-field"/>
                        {errors.lastname && touched.lastname}
                        <div>{errors.lastname}</div>
                        <p>Email</p>
                        <Field name="email" type="email" className="register-field"/>
                        {errors.email && touched.email}
                        <div>{errors.email}</div>
                        <p>Password</p>
                        <Field name="password" type="password" className="register-field"/>
                        {errors.password && touched.password}
                        <div>{errors.password}</div>
                        <p>Retype your password</p>
                        <Field name="retypePassword" type="password" className="register-field"/>
                        {errors.retypePassword && touched.retypePassword}
                        <div>{errors.retypePassword}</div>
                        {/* <ValidationForm errors= {errors} touched= {touched} title= "test" name= "firstname" type="text" className="register-field" /> */}
                        <button type="submit" className="register-button">Register</button>
                    </Form>
                </div>
                )}            
            </Formik>
        </div>
    )
}

export default Register