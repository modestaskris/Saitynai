import React, { useState } from 'react';
import { NavLink } from 'react-router-dom';
import { IUser } from '../../models/user/interface';
import { ROUTES } from '../../routes/routes';
import { AuthService } from '../../services/authService';

export default function LoginPage() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const onLoginClick = () => {
        // TODO validate input
        // check password match
        // TODO validate input

        sendRequest(username, password);
    }

    const sendRequest = async (uname: string, pass: string) => {
        const user: IUser = {
            username: uname,
            password: pass
        }

        const token = await AuthService.login(user);

        console.log("Request sent");
    }

    const onChangeInput = (value: string, setter: any) => {
        setter(value);
    }

    const inputStyle = 'border-gray-900 border-2 p-0 rounded-lg';

    return <>
        <div className='justify-center flex mx-auto'>
            <div>
                <div>
                    Username
                </div>
                <input className={inputStyle} onChange={(e) => {
                    onChangeInput(e.target.value, setUsername);
                }}></input>
                <div>
                    Password
                </div>
                <input type='password' className={inputStyle} onChange={(e) => {
                    onChangeInput(e.target.value, setPassword);
                }}></input>
                <div className='flex justify-center'>
                    <button onClick={() => onLoginClick()} className='bg-black text-white rounded-lg m-1 p-2 my-3'>
                        Login
                    </button>
                </div>
            </div>
        </div>
        <div className='justify-center flex'>
            <div>
                Do not have an account? <NavLink to={ROUTES.REGISTER} className='text-purple-400'>register</NavLink>
            </div>
        </div>
    </>
}