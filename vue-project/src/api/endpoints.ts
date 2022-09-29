// TODO use .env file to save app config...
export const BaseUrl = 'https://localhost:7266';

const endpointVersion = "/api";
const auth = '/auth'

export const ENDPOINT  = {
    // Auth
    Register: endpointVersion + auth +'/register',
    Login: endpointVersion + auth +'/login',
    // Other
    Categories: endpointVersion+'/category',
}