import { AxiosAuthInstance } from "@/api/axiosInstance"
import { ENDPOINT } from '@/api/endpoints';
import type { AxiosAdapter, AxiosInstance, AxiosResponse } from "axios";

interface ISongDTO {
    playlistId: Number,
    url: String
}

export const SongService = {
    async getList(){
        return await AxiosAuthInstance().get(ENDPOINT.Songs)
    },
    async getPlaylistList(id: number){
        return await AxiosAuthInstance().get(ENDPOINT.Playlists + `/${id}` + '/songs')
    },
    async create(obj: ISongDTO){
        return await AxiosAuthInstance().post(ENDPOINT.Songs, obj);
    },
    async get(id:number){
        return await AxiosAuthInstance().get(ENDPOINT.Songs+ `/${id}`);
    },
    async update(id:Number, obj: ISongDTO){
        return await AxiosAuthInstance().put(ENDPOINT.Songs+ `/${id}`, obj);
    },
    async delete(id:Number){
        return await AxiosAuthInstance().delete(ENDPOINT.Songs+ `/${id}`);
    },
}

