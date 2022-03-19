<template>
    <div>
        <com-b></com-b>
        <com-c></com-c>
        <button @click="getToken">获取Token</button>
        <button @click="callApi">访问接口</button>
        {{result}}
    </div>
</template>

<script>
    import axios from '../axios'
    export default {
        components: {
            ComB: () => { return import('./comb'); },
            ComC: {
                template: `<div>{{message}}</div>`,
                data() {
                    return {
                        message: '组件内容'
                    }
                },
            }
        },
        data() {
            return {
                abp: {
                    grant_type: "password",
                    client_id: "bookStore_App",
                    //scope: "BookStore",
                    //client_secret: "1q2w3e*",
                    username: "admin",
                    password: "666666",
                    "__tenant":"49d9ce43-3b60-38e3-816e-3a02908ad8b8"           
                },
                login: {
                    userNameOrEmailAddress: "admin",
                    password: "1q2w3E*",
                    rememberMe: true
                },
                result: {}
            }
        },
        methods: {
            getToken() {
                var qs = require('qs');
                axios.post('connect/token', qs.stringify(this.abp), {
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'                        
                    }
                }).then(m => {
                    localStorage.setItem('token', m.data.access_token);
                });
            },
            callApi() {
                axios.get('api/app/book',{
                    headers: {'authorization': `Bearer ${localStorage.getItem('token')}`}
                }).then(m => {
                    console.log(m);
                });

            }
        },
        mounted() {
            // axios.post('api/account/login', this.login).then(m => {
            //     console.log(m);
            // });
        },
    }
</script>