import { TokenService } from "@/services/tokenService";
import axios from "axios";
import { BaseUrl } from "./endpoints";

export const AxiosInstance = axios.create({
  baseURL: BaseUrl,
  headers: { "Access-Control-Allow-Origin": "*" },
});

const getToken = () => {
  // TODO: token() throws exception;
  var token = TokenService.token();
  // var token = "";
  return token;
};

export const AxiosAuthInstance = axios.create({
  baseURL: BaseUrl,
  headers: {
    Authorization: `Bearer ${getToken()}`,
    "Access-Control-Allow-Origin": "*",
  },
});
