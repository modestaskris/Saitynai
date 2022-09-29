import { AuthService } from "@/services/authService"

// export default function tokenExists({next, store}: any){
export default function auth({next, router}: any){
    const token = AuthService.token();
    if(typeof(token) != 'string'){
        return next();
    }

    // TODO add interface, but shows random errors...
    const parsedToken = AuthService.parsedJwt();

    // If token is expired, user must login again...
    if(parsedToken.exp < Date.now()){
        return router.push({
            name: 'login'
        });
    }
    return next()
}