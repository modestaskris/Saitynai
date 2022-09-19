import { trackPromise } from "react-promise-tracker";
import { AxiosInstance } from "../api/axiosInstance";
import { ENDPOINT } from "../api/endpoints";
import { IYoutubePlaylist } from "../models/youtubePlaylist/interfaces";
import { IYoutubePlaylistCreate } from './../models/youtubePlaylist/interfaces';

export const YoutubeService = {
    async getPlaylists(): Promise<Array<IYoutubePlaylist>>{
        return await (await trackPromise( AxiosInstance.get(ENDPOINT.YoutubePlaylists))).data; // TODO create pipeline through requests to validate data
    },

    async createPlaylist(body:IYoutubePlaylistCreate){
        return await trackPromise(AxiosInstance.post(ENDPOINT.YoutubePlaylists, body));
    },

    getPlaylist(id:number){

    },

    updatePlaylist(id: number){

    },
    
    async deletePlaylist(url: string){
        return await trackPromise(AxiosInstance.delete(ENDPOINT.YoutubePlaylists + "/" + url));
    }
}