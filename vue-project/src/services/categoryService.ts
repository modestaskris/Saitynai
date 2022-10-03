import { AxiosAuthInstance } from "@/api/axiosInstance"
import { ENDPOINT } from '@/api/endpoints';
import { parse } from "@babel/parser";
import type { AxiosAdapter, AxiosInstance, AxiosResponse } from "axios";

interface ICategory  {
    categoryId: number,
    name: string
}

interface ICategoryDTO  {
    name: string
}

interface IRequest{
    status:number;
    msg:string;
    data:any
}

export const CategoryService ={
    async getList(){
        return await AxiosAuthInstance.get(ENDPOINT.Categories)
    },
    async getPlaylists(categId:number){
        return await AxiosAuthInstance.get(ENDPOINT.Categories + `/${categId}` + '/playlists')
    },
    async create(obj: ICategoryDTO){
        return await AxiosAuthInstance.post(ENDPOINT.Categories, obj);
    },
    async get(id:number){
        return await AxiosAuthInstance.get(ENDPOINT.Categories+ `/${id}`);
    },
    async update(id:Number, obj: ICategoryDTO){
        return await AxiosAuthInstance.put(ENDPOINT.Categories+ `/${id}`, obj);
    },
    async delete(id:Number){
        return await AxiosAuthInstance.delete(ENDPOINT.Categories+ `/${id}`);
    },
}

