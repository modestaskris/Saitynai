import axios from "axios";
import { BaseUrl } from "./endpoints";
import { AuthService } from './../services/authService';

export const AxiosInstance = axios.create({
    baseURL: BaseUrl,
    headers: {'Access-Control-Allow-Origin' : '*',}
});

const getToken = () => {
    return AuthService.token() || ''
};

export const AxiosAuthInstance = axios.create({
    baseURL: BaseUrl,
    headers: {
        'Authorization': `Bearer ${getToken()}`,
        'Access-Control-Allow-Origin' : '*',
    }
});