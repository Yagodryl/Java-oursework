import update from "../../../helpers/update";
import LoginService from "./LoginService";

export const LOGIN_STARTED = "login/LOGIN_STARTED";
export const LOGIN_SUCCESS = "login/LOGIN_SUCCESS";
export const LOGIN_FAILED = "login/LOGIN_FAILED";

const initialState = {
  post: {
    loading: false,
    success: false,
    failed: false
  }
};

export const loginReducer = (state = initialState, action) => {
  let newState = state;

  switch (action.type) {
    case LOGIN_STARTED: {
      newState = update.set(state, "post.loading", true);
      newState = update.set(newState, "post.success", false);
      newState = update.set(newState, "post.failed", false);
      break;
    }
    case LOGIN_SUCCESS: {
      newState = update.set(state, "post.loading", false);
      newState = update.set(newState, "post.failed", false);
      newState = update.set(newState, "post.success", true);
      break;
    }
    case LOGIN_FAILED: {
      newState = update.set(state, "post.loading", false);
      newState = update.set(newState, "post.success", false);
      newState = update.set(newState, "post.failed", true);
      break;
    }
    default: {
      return newState;
    }
  }

  return newState;
};

export const loginData = model => {
  return dispatch => {
    dispatch(loginActions.started());
    LoginService.Login(model)
      .then(response => {
        dispatch(loginActions.success());
        return new Promise(resolve => {
          resolve(response);
        });
      })
      .catch(err => {
        dispatch(loginActions.failed());
        throw err.response;
      });
  };
};

export const loginActions = {
  started: () => {
    return {
      type: LOGIN_STARTED
    };
  },
  success: () => {
    return {
      type: LOGIN_SUCCESS
    };
  },
  failed: () => {
    return {
      type: LOGIN_FAILED
    };
  }
};
