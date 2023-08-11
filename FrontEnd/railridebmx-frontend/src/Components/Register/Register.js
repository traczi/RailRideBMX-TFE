import React from "react";
import "./Register.css";
import { Formik, Form, Field } from "formik";
import * as Yup from "yup";
import FormValidation from "../FormValidation/FormValidation";

const onRegister = async (data) => {
  try {
    console.log(data);
    const res = await fetch("https://localhost:7134/api/User/Register", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    });
    console.log(res);
  } catch (err) {
    console.log(err);
  }
};

const getCharacterValidationError = (str) => {
  return `Your password must have at least 1 ${str} character`;
};

const SignupSchema = Yup.object().shape({
  firstname: Yup.string()
    .min(2, "Too short!")
    .max(50, "Too long!")
    .required("Required"),
  lastname: Yup.string()
    .min(2, "Too short!")
    .max(50, "Too long!")
    .required("Required"),
  email: Yup.string().email("Invalid email").required("required"),
  password: Yup.string()
    .required("Password required")
    .min(8, "8 charactère minimum")
    .max(15, "15 charactère maximum")
    .matches(/[0-9]/, getCharacterValidationError("digit"))
    .matches(/[a-z]/, getCharacterValidationError("lowercase"))
    .matches(/[A-Z]/, getCharacterValidationError("uppercase")),
  retypePassword: Yup.string()
    .required("required")
    .oneOf([Yup.ref("password")], "Passwords does not match"),
});

const Register = () => {
  return (
    <div className="register-field">
      <div className="title-register">
        <h1>Signup</h1>
      </div>
      <Formik
        initialValues={{
          firstname: "",
          lastname: "",
          email: "",
          password: "",
          retypePassword: "",
        }}
        validationSchema={SignupSchema}
        onSubmit={(values) => {
          onRegister(values);
        }}
      >
        <div className="register-content">
          <Form>
            <FormValidation
              type="text"
              name="firstname"
              title="Firstname"
              className="register-field"
            ></FormValidation>

            <FormValidation
              type="text"
              name="lastname"
              title="Lastname"
              className="register-field"
            ></FormValidation>

            <FormValidation
              type="email"
              name="email"
              title="Email"
              className="register-field"
            ></FormValidation>

            <FormValidation
              type="password"
              name="password"
              title="Password"
              className="register-field"
            ></FormValidation>

            <FormValidation
              type="password"
              name="retypePassword"
              title="Retype your password"
              className="register-field"
            ></FormValidation>
            <button type="submit" className="register-button">
              Register
            </button>
          </Form>
        </div>
      </Formik>
    </div>
  );
};

export default Register;
