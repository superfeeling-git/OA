<template>
    <div>
<<<<<<< HEAD
        <button @click="submit">
            abc
        </button>
=======

>>>>>>> master
    </div>
</template>

<script>
    import axios from '@/axios'
    export default {
        data() {
            return {
<<<<<<< HEAD
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

=======

            }
        },
        mounted() {
            axios.get("/api/identity/roles/all").then(m => {

            });
>>>>>>> master
        },
    }
</script>