import axios from 'axios';
import { host } from "../config.js";
const url_user = `${host}/Users`;

export const GetUser = () => {
    return axios.get(url_user);
}