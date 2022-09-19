import { trackPromise } from 'react-promise-tracker';
import { AxiosInstance } from '../api/axiosInstance';
import { ENDPOINT } from '../api/endpoints';
import { IUser } from './../models/user/interface';

export const AuthService = {
    async register(body:IUser){
        // TODO returns success or not
        return await trackPromise(AxiosInstance.post(ENDPOINT.register, body));
    },

    async login(body:IUser): Promise<string>{
        // TODO returns token;
        return await trackPromise(AxiosInstance.post(ENDPOINT.login, body));
    },

    getUser(id:number){
        console.log("AuthService getUser not implemented");
    },

    updateUser(id: number){
        console.log("AuthService updateUser not implemented");
    },
    
    async deleteUser(url: string){
        console.log("AuthService updateUser not implemented");
    }
}