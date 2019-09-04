import {
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  FormGroup,
  Input,
  Label,
  InputGroup,
  FormFeedback
} from "reactstrap";
import React, { Component } from "react";
import { connect } from "react-redux";
import classnames from "classnames";
import { withRouter } from "react-router-dom";
import get from 'lodash.get';


import * as RegisterClientActions  from "./reducer";
class RegisterClientContainer extends Component {
  state = {
    firstName: "",
    lastName: "",
    middleName: "",
    email: "",
    password: "",
    confirmPassword: "",
    serverErrors: {},
    errors: {},
    sandFormSuccess: false
  };
  setStateByErrors = (name, value) => {
    if (!!this.state.errors[name]) {
      let errors = Object.assign({}, this.state.errors);
      delete errors[name];
      this.setState({
        [name]: value,
        errors
      });
    } else {
      this.setState({
        [name]: value
      });
    }
  };

  onSubmitForm = e => {
    this.setState({
      serverErrors: {}
    });
    const { firstName, lastName, middleName, errors, email, password, confirmPassword } = this.state;
    const regex_password = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{6,24}$/;
    const regex_email = /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/;

    if (!regex_email.test(email)) errors.email = "Не правильний формат електронної пошти!";
    if (email === "") errors.email = "Поле є обов'язковим";
    if (!regex_password.test(password)) errors.password = "Пароль повинен містити не менше 6 символів і складатись із цифр та букв латинського алфавіту верхнього та нижнього регістру";
    if (!regex_password.test(confirmPassword)) errors.confirmPassword = "Пароль повинен містити не менше 6 символів і складатись із цифр та букв латинського алфавіту верхнього та нижнього регістру";
    if (password!== confirmPassword) errors.confirmPassword = "Підтвердіть пароль знову";
    if (confirmPassword === '') errors.confirmPassword = "Поле є обов'язковим";
    if (password === '') errors.password = "Поле є обов'язковим";
    if (firstName === '') errors.firstName= "Поле є обов'язковим";
    if (lastName === '') errors.lastName = "Поле є обов'язковим";
    if (middleName === '') errors.middleName = "Поле є обов'язковим";
    const isValid = Object.keys(errors).length === 0;
    if(isValid){
        const clientModel = {
            lastName,
            firstName,
            middleName,
            email,
            password,
            confirmPassword
        }
        this.registerClientData(clientModel)
        //this.setState({errors: this.props.isError})
    }else{
        this.setState({
            errors
          });
    }


  };
  handleChange = e => {
    this.setStateByErrors(e.target.name, e.target.value);
  };
  render() {
    const{errors} = this.state;
    return (
      <React.Fragment>
        <Card>
          <CardHeader>
            <h3>Реєстрація</h3>
          </CardHeader>
          <form autoComplete="off" onSubmit={this.onSubmitForm}>
            {!!errors.invalid ? <div className="alert alert-danger">{errors.invalid}.</div> : ""}

            <CardBody>
              <FormGroup>
                <Label htmlFor="firstName">Ім'я</Label>
                <InputGroup>
                  <Input
                    invalid={!!errors.firstName}
                    type="text"
                    id="firstName"
                    name="firstName"
                    onChange={this.handleChange}
                    value={this.state.firstName}
                  />
                  <FormFeedback valid={!errors.firstName}>{errors.firstName}</FormFeedback>
                </InputGroup>
              </FormGroup>
              <FormGroup>
                <Label htmlFor="lastName">Прізвище</Label>
                <InputGroup>
                  <Input
                    invalid={!!errors.lastName}
                    type="text"
                    id="lastName"
                    name="lastName"
                    onChange={this.handleChange}
                    value={this.state.lastName}
                  />
                  <FormFeedback valid={!errors.lastName}>{errors.lastName}</FormFeedback>
                </InputGroup>
              </FormGroup>
              <FormGroup>
                <Label htmlFor="middleName">По батькові</Label>
                <InputGroup>
                  <Input
                    invalid={!!errors.middleName}
                    type="text"
                    id="middleName"
                    name="middleName"
                    onChange={this.handleChange}
                    value={this.state.middleName}
                  />
                  <FormFeedback valid={!errors.middleName}>{errors.middleName}</FormFeedback>
                </InputGroup>
              </FormGroup>
              <FormGroup>
                <Label htmlFor="email">Email</Label>
                <InputGroup>
                  <Input
                    invalid={!!errors.email}
                    type="email"
                    id="email"
                    name="email"
                    onChange={this.handleChange}
                    value={this.state.email}
                  />
                  <FormFeedback valid={!errors.email}>{errors.email}</FormFeedback>
                </InputGroup>
              </FormGroup>
              <FormGroup>
                <Label htmlFor="password">Пароль</Label>
                <InputGroup>
                  <Input
                    invalid={!!errors.password}
                    type="password"
                    id="password"
                    name="password"
                    onChange={this.handleChange}
                    value={this.state.password}
                  />
                  <FormFeedback valid={!errors.password}>{errors.password}</FormFeedback>
                </InputGroup>
              </FormGroup>
              <FormGroup>
                <Label htmlFor="confirmPassword">Повтор паролю</Label>
                <InputGroup>
                  <Input
                    invalid={!!errors.confirmPassword}
                    type="password"
                    id="confirmPassword"
                    name="confirmPassword"
                    onChange={this.handleChange}
                    value={this.state.confirmPassword}
                  />
                  <FormFeedback valid={!errors.confirmPassword}>{errors.confirmPassword}</FormFeedback>
                </InputGroup>
              </FormGroup>
            </CardBody>
            <CardFooter>
              <button
                type="submit"
                className="btn btn-success"
              >
                Зареєструватись
              </button>
            </CardFooter>
          </form>
        </Card>        
      </React.Fragment>
    );
  }
}

const mapStateToProps = state => {
    return {
      data: get(state, "registerClient.list.data"),
      isLoading: get(state, "registerClient.list.loading"),
      isError: get(state, "registerClient.list.error")
    };
  };
  const mapDispatchToProps = dispatch => {
    return {
      registerClientData: (model) => {
        dispatch(RegisterClientActions.registerClientData(model));
      }
    };
  };

 const RegisterClient  =connect (mapStateToProps,mapDispatchToProps )(RegisterClientContainer);
export default RegisterClient;
