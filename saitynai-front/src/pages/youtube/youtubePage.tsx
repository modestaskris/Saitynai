import React, { useEffect, useState } from 'react';
import { IYoutubePlaylist } from '../../models/youtubePlaylist/interfaces';
import { YoutubeService } from '../../services/youtubeService';
import YoutubePlaylist from './components/youtubePlaylist';
import { IYoutubePlaylistCreate } from './../../models/youtubePlaylist/interfaces';

export default function YoutubePage() {

    const [playlists, setPlaylists] = useState<Array<IYoutubePlaylist>>([]);

    const [newUrl, setNewurl] = useState('');

    function createPlaylist() {
        var createPlaylistBody: IYoutubePlaylistCreate = {
            url: newUrl
        }
        YoutubeService.createPlaylist(createPlaylistBody);
        getPlaylists();
    }

    useEffect(() => {
        // TODO uncomment fetching of playlists
        // getPlaylists();
    }, [])

    async function getPlaylists() {
        const tempPlaylists = await YoutubeService.getPlaylists();
        setPlaylists(tempPlaylists);
    }

    return <>
// TODO uncomment fetching of playlists


        <div>
            <div>
                Add new playlist:
                <input className='bg-slate-100 rounded-md m-2' value={newUrl} onChange={(e) => {
                    setNewurl(e.currentTarget.value);
                }}>
                </input>
                <button type='button' onClick={() => { createPlaylist() }} className='bg-red-300 px-2 rounded-lg'>
                    Add
                </button>
            </div>
            <div>
                User`s playlists:
                <hr />
                <ul>
                    {playlists && playlists.map(x => <>
                        <YoutubePlaylist value={x} />
                    </>)}
                </ul>
            </div>
        </div>
    </>
}