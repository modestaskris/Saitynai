import axios from "axios";
import { BaseUrl } from "./endpoints";

export const AxiosInstance = axios.create({
    baseURL: BaseUrl,
    headers: {'Access-Control-Allow-Origin' : '*',}
});