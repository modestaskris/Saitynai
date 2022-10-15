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
                <a className="text-xs">(at least 5 characters)</a>
            </div>
            <input 
                v-model="Password"
                type='password' 
                className="border-gray-900 border-2 p-1 rounded-lg" 
            />
            <div>
                Re-enter password
            </div>
            <input 
                v-model="Repassword"
                type='password' 
                className="border-gray-900 border-2 p-1 rounded-lg" />
            <div className='flex justify-center'>
                <button 
                    @click="register"
                    className='bg-black text-white rounded-lg m-1 p-2 my-3'
                >
                    register
                </button>
            </div>
        </div>
    </div>
    <div className='justify-center flex'>
        <div>
            Already have an account? 
            <RouterLink 
                to='/login'
                className='text-purple-400'>login
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
import type { IUser } from '@/models/user/interface';
import route from '@/router/route';

export default {
    data(){
        return{
            Username: "",
            Password: "",
            Repassword: "",
            MyError: {
                active: false,
                message: ""
            }
        }
    },
    methods: {
        async register(): Promise<void>{
            // Validating password length
            const enoughPasswordLenght = this.Password.length >= 5;
            if(!enoughPasswordLenght){
                this.MyError.active = true;
                this.MyError.message = "Password must be at least 5 characters";
                return;
            }
            // Validating passwords match
            const passowrdsMatch = this.validatePassowrds();
            if(!passowrdsMatch){
                this.Password = '';
                this.Repassword = '';

                this.MyError.active = true;
                this.MyError.message = "Passwords does not match";
                // TODO show error
                return;
            }
            // If passes all validation
            this.MyError.active = false;
            this.MyError.message = "";

            var user:IUser = {
                username: this.Username,
                password: this.Password
            }

            const resp = await AuthService.register(user);
            
            if(resp.status === 201){
                // created
                this.$router.push({ path: route.LOGIN });
            } else if (resp.status === 403){
                // TODO show already exists
            } else {
                // TODO show that error ocured
            }
        },
        validatePassowrds(): Boolean{
            // TS error, expects password and repassword is in export default scope.... it is in data scope
            if(this.Password === this.Repassword)
                return true
            return false;
        }
    },
    // mounted(){
    // },
}
</script>