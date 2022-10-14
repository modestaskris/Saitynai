import { ENDPOINT } from "@/api/endpoints";
import { AxiosInstance } from "../api/axiosInstance";
import { LocalStorageService } from "./localStorageService";

export const AuthService = {
  async register(body:any) {
    // TODO returns success or not
    return await AxiosInstance.post(ENDPOINT.Register, body);
  },

  async login(body:any): Promise<string> {
    return await AxiosInstance.post(ENDPOINT.Login, body);
  },

  logout() {
    // TODO use better logic to logout, maybe only delete token...
    LocalStorageService.clear();
  },
};