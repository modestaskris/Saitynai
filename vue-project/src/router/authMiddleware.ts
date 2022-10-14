import { AuthService } from "@/services/authService";
import { TokenService } from "@/services/tokenService";

// export default function tokenExists({next, store}: any){
export default function auth({ next, router }: any) {
  const tokenIsValid = TokenService.tokenIsValid();
  if (!tokenIsValid) {
    // TODO: navigate to /login?
    // router.push('/login');
    return;
  }
  return next();
}
