import React from 'react';
import { IYoutubePlaylist } from '../../../models/youtubePlaylist/interfaces';
import { YoutubeService } from './../../../services/youtubeService';

interface IYtPlaylistComponent {
    value: IYoutubePlaylist;
}

export default function YoutubePlaylist(props: IYtPlaylistComponent) {
    

    function deletePlaylist(){
        YoutubeService.deletePlaylist(props.value.url);
    }

    // fetches somewhere information about playlist
    return <>
        <div className='flex mx-0 justify-between'>
            <div>
                <a href={props.value.url} className='text-red-500'>{props.value.playlistName}</a>
                <div>
                    total songs: {props.value.songsCount}| new songs: {props.value.sewSongsCount}
                </div>
                <hr />
            </div>
            <ManagePlaylist delete={deletePlaylist}/>
        </div>
    </>
}

interface IManagePlaylist{
    delete:CallableFunction
}

function ManagePlaylist(props: IManagePlaylist) {
    return <>
        <button onClick={() => {props.delete()}} className='px-2 m-1 bg-red-700 rounded-md align-middle text-white border-red'>
            Delete
        </button>
    </>
}