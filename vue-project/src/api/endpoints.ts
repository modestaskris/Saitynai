// TODO use .env file to save app config...
// export const BaseUrl = 'https://localhost:7266';
export const BaseUrl = 'https://saitynai20221106170850.azurewebsites.net/';


const endpointVersion = "/api";
const auth = '/auth'
export const ENDPOINT  = {
    // Auth
    Register: endpointVersion + auth +'/register',
    Login: endpointVersion + auth +'/login',
    // Other
    Categories: endpointVersion+'/category',
    Playlists: endpointVersion+'/playlists',
    Songs: endpointVersion+'/songs',
    Users: endpointVersion+'/users',
}