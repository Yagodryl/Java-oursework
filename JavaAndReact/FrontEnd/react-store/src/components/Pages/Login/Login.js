import React, { Component } from "react";
import { Card, CardBody, CardFooter, CardHeader, FormGroup, Input, Label, InputGroup, FormFeedback } from "reactstrap";
import PropTypes from "prop-types";
import { connect } from "react-redux";
import get from "lodash.get";
import * as loginActions from "./reducer";
import { Redirect, withRouter } from "react-router-dom";

const propTypes = {
  login: PropTypes.func.isRequired,
  loading: PropTypes.bool.isRequired,
  failed: PropTypes.bool.isRequired,
  success: PropTypes.bool.isRequired,
  history: PropTypes.func.isRequired
};

const defaultProps = {};
class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: "",
      password: "",
      errors: {},
      loading: false,
      done: false
    };
  }
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
  handleChange = e => {
    this.setStateByErrors(e.target.name, e.target.value);
  };
  onSubmitForm = e => {
    e.preventDefault();
    const { email, password } = this.state;

    let errors = {};

    if (email === "") errors.email = "Поле не може бути пустим!";
    if (password === "") errors.password = "Поле не може бути пустим!";

    const isValid = Object.keys(errors).length === 0;

    if (isValid) {
      const model = {
        Email: email,
        Password: password
      };
      this.props
        .login(model)
        .then(response => {
          this.setState({ done: true });
        })
        .catch(err => {
          this.setState({ errors: err.data });
        });
    } else {
      console.log("errors");
      this.setState({ errors });
    }
  };
  render() {
    const { errors, loading, data, done } = this.state;

    const content = (
      <Card>
        <CardHeader>
          <h3>Login</h3>
        </CardHeader>
        <form autoComplete="off" onSubmit={this.onSubmitForm}>
          <CardBody>
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
          </CardBody>
          <CardFooter>
            <button type="submit" className="btn btn-success">
              Login
            </button>
          </CardFooter>
        </form>
      </Card>
    );

    return <React.Fragment>
       <div className="row">
                        <div className="col-12 col-sm-12">
                            {content}
                        </div>
                    </div>
    </React.Fragment>;
  }
}

export default Login;
