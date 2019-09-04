import axios from "axios";
import {serverUrl} from "../../../config"

export default class RegisterClientService{
    static registerClient(model){
        return(
            axios.post(`${serverUrl}api/Account/register`, model)
        )
    }
}