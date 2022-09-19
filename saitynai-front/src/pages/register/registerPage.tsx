import React, { useState } from 'react';
import { IUser } from '../../models/user/interface';
import { AuthService } from './../../services/authService';

export default function RegisterPage() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [password2, setPassword2] = useState('');

    const onRegisterClick = () => {
        // TODO validate input
        // check password match

        const validPasswords = validatePasswords(password, password2);
        console.log(`Passwords are ${validPasswords}`);

        if(!validPasswords){
            // todo show error
            return;
        }
        // TODO show that passwords are correct

        sendRequest(username, password);
    }

    const validatePasswords = (first: string, second: string): boolean => {
        if (first === second) {
            return true;
        }
        return false;
    }

    const sendRequest = (uname:string, pass:string) => {
        const user:IUser = {
            username: uname,
            password: pass
        }

        AuthService.register(user);


        console.log("Request sent successfully");
    }

    const onChangeInput = (value: string, setter: any) => {
        setter(value);
    }

    const buttonStyle = 'border-gray-900 border-2 p-0 rounded-lg';

    return <>
        <div className='justify-center flex mx-auto'>
            <div>
                <div>
                    Username
                </div>
                <input className={buttonStyle} onChange={(e) => {
                    onChangeInput(e.target.value, setUsername);
                }}></input>
                <div>
                    Password
                </div>
                <input type='password' className={buttonStyle} onChange={(e) => {
                    onChangeInput(e.target.value, setPassword);
                }}></input>
                <div>
                    Re-enter password
                </div>
                <input type='password' className={buttonStyle} onChange={(e) => {
                    onChangeInput(e.target.value, setPassword2);
                }}></input>
                <div className='flex justify-center'>
                    <button onClick={() => onRegisterClick()} className='bg-black text-white rounded-lg m-1 p-2 my-3'>
                        register
                    </button>
                </div>
            </div>
        </div>
    </>
}