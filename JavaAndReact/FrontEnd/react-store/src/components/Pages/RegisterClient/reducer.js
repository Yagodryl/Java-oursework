import update from "../../../helpers/update";
import RegisterClientService from "./RegisterClientService";

export const REGISTER_CLIENT_STARTED = "registerClient/REGISTER_CLIENT_STARTED";
export const REGISTER_CLIENT_SUCCESS = "registerClient/REGISTER_CLIENT_SUCCESS";
export const REGISTER_CLIENT_FAILED = "registerClient/REGISTER_CLIENT_FAILED";

const intialState = {
  list: {
    data: {},
    error: {},
    loading: false
  }
};

export const registerClientReducer = (state = intialState, action) => {
  let newState = state;

  switch (action.type) {
    case REGISTER_CLIENT_STARTED: {
      newState = update.set(state, "list.loading", true);
      break;
    }
    case REGISTER_CLIENT_SUCCESS: {
      newState = update.set(state, "list.loading", false);
      newState = update.set(newState, "list.data", action.payload.data);
      break;
    }
    case REGISTER_CLIENT_FAILED: {
      newState = update.set(state, "list.loading", false);
      newState = update.set(newState, "list.error", action.payload.error);
      break;
    }
    default: {
      return newState;
    }
  }
  return newState;
};

export const registerClientData = model => {
  return dispatch => {
    dispatch(RegisterClientActions.started());
    RegisterClientService.registerClient(model)
      .then(response => {
        dispatch(RegisterClientActions.success(response));
      })
      .catch((err) => {
        dispatch(RegisterClientActions.failed(err));
      });
  };
};

export const RegisterClientActions = {
  started: () => {
    return {
      type: REGISTER_CLIENT_STARTED
    };
  },

  success: data => {
    return {
      type: REGISTER_CLIENT_SUCCESS,
      payload: data
    };
  },

  failed: error => {
    return {
      type: REGISTER_CLIENT_FAILED,
      payload: error
    };
  }
};
