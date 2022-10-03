import type { ISong } from "../song/song";

export interface IYoutubePlaylistCreate {
    url:string;
}

export interface IYoutubePlaylist {
    id: string,
    url: string,
    playlistName: string,
    songsCount: number,
    sewSongsCount: number,
    youtubeSongs?: Array<ISong>
}

export const youtubePlaylistCreate: IYoutubePlaylistCreate = {
    url: ''
}