<template>
    <div>
        <button @click="submit">
            abc
        </button>
    </div>
</template>

<script>
    import axios from '@/axios'
    export default {
        data() {
            return {
                form: {
                    userNameOrEmailAddress: "admin",
                    password: "1q2w3E*"
                }
            }
        },
        methods: {
            submit() {
                let params = new URLSearchParams();
                params.append('userNameOrEmailAddress', 'admin');       //你要传给后台的参数值 key/value
                params.append('password', '1q2w3E*');
                axios.post("api/account/login", params).then(m => {
                    console.log(m);
                });
            }
        },
        mounted() {

        },
    }
</script>