<template>
    <div className='justify-center flex mx-auto'>
        <div>
            <div>
                Username
            </div>
            <input
                v-model="Username"
                className="border-gray-900 border-2 p-1 rounded-lg"/>
            <div>
                Password
            </div>
            <input 
                v-model="Password"
                type='password' 
                className="border-gray-900 border-2 p-1 rounded-lg" 
            />
            <div className='flex justify-center'>
                <button 
                    @click="login"
                    className='bg-black text-white rounded-lg m-1 p-2 my-3'
                >
                    login
                </button>
            </div>
        </div>
    </div>
    <div className='justify-center flex'>
        <div>
            Do not have an account? 
            <RouterLink 
                to='/register'
                className='text-purple-400'>register
            </RouterLink>
        </div>
    </div>
    <div
        v-if="MyError.active"
        class="justify-center flex"
    >
        <div class="text-red-400">
            <hr class="border-red-500 w-50 mt-5"/>
            {{MyError.message}}
        </div>
    </div>
</template>

<script lang="ts">
import { AuthService } from '@/services/authService';
import type { IUser } from '@/models/user/user';
import ROUTE from '../router/route';
import { defineComponent } from 'vue';
import { TokenService } from '@/services/TokenService';

export default defineComponent({
    data(){
        return{
            Username: "",
            Password: "",
            MyError: {
                active: false,
                message: ""
            }
        }
    },
    methods: {
        async login(): Promise<void>{
            // this.MyError.active = false;
            // this.MyError.message = "";
            // TODO send request here
            const user: IUser = {
                username: this.Username,
                password: this.Password
            }
            const resp = await AuthService.login(user);
            if(resp.status == 200){
                // TODO save token...
                TokenService.saveToken(resp.data);
                this.$router.push({path: ROUTE.CATEGORIES});
            } else {
                // todo show errors...
            }
        },
        validatePassowrds(): Boolean{
            // TS error, expects password and repassword is in export default scope.... it is in data scope
            if(this.Password === this.Repassword)
                return true
            return false;
        }
    },
})
</script>