import React from 'react';
import { Link } from 'react-router-dom';
import { ROUTES } from '../routes/routes';

export default function NavBar() {
    return <>
        <div className="p-4 max-w-6xl mx-auto bg-white rounded-b-2xl shadow-lg flex justify-between space-x-4">
            <div className="flex justify-start float-left space-x-4">
                {/* Left  */}
                {/* <Link to={ROUTES.SCRAPER}>Scraper</Link> */}
                <Link to={ROUTES.PLAYLISTS}>Playlists</Link>
            </div>
            <div>
                {/* Between */}
                <div className="font-medium text-4xl">
                    <Link to={ROUTES.LANDING}>Youtube Playlists</Link>
                </div>
            </div>
            <div className="flex justify-end float-right space-x-4">
                {/* Right */}
                <Link to={ROUTES.LOGIN}>LOGIN</Link>
                <Link to={ROUTES.REGISTER}>REGISTER</Link>
            </div>
        </div>
    </>
}