import { ENDPOINT } from "@/api/endpoints";
import type { IUser } from "@/models/user/interface";
import { AxiosInstance } from "../api/axiosInstance";
import { LocalStorageService } from "./localStorageService";

export const AuthService = {
  async register(body: IUser) {
    // TODO returns success or not
    return await AxiosInstance.post(ENDPOINT.Register, body);
  },

  async login(body: IUser): Promise<string> {
    return await AxiosInstance.post(ENDPOINT.Login, body);
  },

  logout() {
    // TODO use better logic to logout, maybe only delete token...
    LocalStorageService.clear();
  },
};