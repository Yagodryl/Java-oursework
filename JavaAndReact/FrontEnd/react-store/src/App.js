import React, { Component } from "react";
import { HashRouter as Router, Route, Switch } from "react-router-dom";

const loading = () => <div className="animated fadeIn pt-3 text-center">Loading...</div>;

//pages
const RegisterClient = React.lazy(() => import("./components/Pages/RegisterClient/RegisterClient"));
const Login = React.lazy(()=> import("./components/Pages/Login/Login"));
class App extends Component {
  render() {
    return (
      <Router>
        <React.Suspense fallback={loading()}>
          <Switch>
            <Route exact path="/register" name="RegisterClient" render={props => <RegisterClient {...props} />} />
            <Route exact path="/login" name="Login" render={props => <Login {...props} />} />

          </Switch>
        </React.Suspense>
      </Router>
    );
  }
}

export default App;
