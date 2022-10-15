import { AxiosAuthInstance } from "@/api/axiosInstance";
import { LocalStorageService } from "./localStorageService";

const tokenKey = "yps_jwt_token";

export const TokenService = {
  parseJwt(token: string) {
    var base64Url = token.split(".")[1];
    var base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
    var jsonPayload = decodeURIComponent(
      window
        .atob(base64)
        .split("")
        .map(function (c) {
          return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
        })
        .join("")
    );
    return JSON.parse(jsonPayload);
  },

  parsedJwtToken() {
    const token = this.token();
    if (!token) {
      return;
    }
    const parsedJwt = this.parseJwt(token);
    parsedJwt.exp = parsedJwt.exp * 1000;
    return parsedJwt;
  },

  saveToken(value: string): void {
    LocalStorageService.save(tokenKey, value);
  },

  tokenExists(): boolean {
    return LocalStorageService.exists(tokenKey);
  },

  token(): string | null {
    var token = LocalStorageService.get(tokenKey);
    if (this.tokenExists() && typeof token == "string") {
      // TODO test
      return token;
    }
    return null;
  },

  tokenIsValid() {
    const token = this.token();
    if (typeof token !== "string") {
      return false;
    }
    const parsedToken = this.parsedJwtToken();
    if (parsedToken === null || parsedToken.exp < Date.now()) {
      return false;
    }
    return true;
  },

  async fetchToken(): Promise<string> {
    const token: string = await (
      await AxiosAuthInstance().get("/api/auth/token")
    ).data;
    return token;
  },

  async updateToken(){
    const token = await this.fetchToken();
    console.log(`New token: ${token}`);
    TokenService.saveToken(token);
  },

  async updateTokenInterval() {
    const tokenIsValid = TokenService.tokenIsValid();
    if (tokenIsValid) {
      console.log("Starting token update...");
      try {
        this.updateToken();
        setInterval(async () => {
          this.updateToken();
        // }, 4 * 60 * 1000); // refreshes every minute
        }, 1 * 60 * 1000); // refreshes every minute
      } catch (err) {
        throw new Error("Exception occured while updating token");
      }
    } else {
      console.error("Token is not valid...");
    }
  },
};
