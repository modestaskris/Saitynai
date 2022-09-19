// TODO use .env file to save app config...
export const BaseUrl = 'https://localhost:7266';

const endpointVersion = "/api";

const auth = '/auth'

export const ENDPOINT  = {
    YoutubePlaylists: endpointVersion+'/youtubeplaylists',
    register: endpointVersion + auth +'/register',
    login: endpointVersion + auth +'/login',
}