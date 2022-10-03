import { AxiosAuthInstance } from "@/api/axiosInstance"
import { ENDPOINT } from '@/api/endpoints';
import type { AxiosAdapter, AxiosInstance, AxiosResponse } from "axios";

interface ICategory  {
    playlistId: number,
    title: string,
    url: string
}

 interface IPlaylistDTO  {
    categorieName: string, // TODO should use category id...
    playlistName: string,
    url: string
}

interface IRequest{
    status:number;
    msg:string;
    data:any
}

export const PlaylistService = {
    async getList(){
        return await AxiosAuthInstance.get(ENDPOINT.Playlists)
    },
    async create(obj: IPlaylistDTO){
        return await AxiosAuthInstance.post(ENDPOINT.Playlists, obj);
    },
    async get(id:number){
        return await AxiosAuthInstance.get(ENDPOINT.Playlists+ `/${id}`);
    },
    async update(id:number, obj: IPlaylistDTO){
        return await AxiosAuthInstance.put(ENDPOINT.Playlists+ `/${id}`, obj);
    },
    async delete(id:Number){
        return await AxiosAuthInstance.delete(ENDPOINT.Playlists+ `/${id}`);
    },
}

