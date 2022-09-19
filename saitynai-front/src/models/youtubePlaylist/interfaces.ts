import { IYoutubeSong } from "../youtubeSong/interfaces";

export interface IYoutubePlaylistCreate {
    url:string;
}

export interface IYoutubePlaylist {
    id: string,
    url: string,
    playlistName: string,
    songsCount: number,
    sewSongsCount: number,
    youtubeSongs?: Array<IYoutubeSong>
}