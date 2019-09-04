import axios from "axios";
import { serverUrl } from "../../../config";

export default class LoginService {
  static Login(model) {
    return axios.post(`${serverUrl}api/user/login`, model)
  }
}
